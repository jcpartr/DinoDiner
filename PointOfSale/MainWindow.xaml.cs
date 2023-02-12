using DinoDiner.Data;
using DinoDiner.PointOfSale.PaymentControls;
using RoundRegister;
using System.Windows;

namespace DinoDiner.PointOfSale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Order Collection
        /// </summary>
        private Order _order;

        /// <summary>
        /// Order Control Reference
        /// </summary>
        private OrderControl _orderControl;

        /// <summary>
        /// Reference to the CashDrawerProcessor
        /// </summary>
        private CashDrawerProcessor _processor;

        /// <summary>
        /// Initializer
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _order = new();
            _orderControl = new(_order);
            this.DisplayContainer.Child = _orderControl;
            OrderControlEventSetup();
            _processor = new(0.0m); //To Avoid Null Errors
        }

        //Order and Menu Functions
        /// <summary>
        /// Sets up the events for the OrderControl
        /// </summary>
        private void OrderControlEventSetup()
        {
            _orderControl.CancelOrderButton.Click += CancelOrderButton_Click;
            _orderControl.CompleteOrderButton.Click += CompleteOrderButton_Click;
        }

        /// <summary>
        /// Cancel Order Button Event Handler
        /// </summary>
        /// <param name="sender">Cancel button</param>
        /// <param name="e">Arguments</param>
        private void CancelOrderButton_Click(object sender, RoutedEventArgs e)
        {
            ResetOrder();
        }

        /// <summary>
        /// Complete Order Button Event Handler
        /// </summary>
        /// <param name="sender">Cancel button</param>
        /// <param name="e">Arguments</param>
        private void CompleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayPaymentOptions();
        }

        /// <summary>
        /// Resets the order and returns to the menu
        /// </summary>
        private void ResetOrder()
        {
            _order = new();
            _orderControl = new(_order);
            this.DisplayContainer.Child = _orderControl;
            OrderControlEventSetup();
        }

        //Payment Options Functions
        /// <summary>
        /// Displays the Payment Options Selection
        /// </summary>
        private void DisplayPaymentOptions()
        {
            PaymentOptionsControl options = new PaymentOptionsControl(_order);
            options.CashButton.Click += CashButton_Click;
            options.CardButton.Click += CardButton_Click;
            options.ReturnButton.Click += ReturnButton_Click;
            this.DisplayContainer.Child = options;
        }

        /// <summary>
        /// EventHandler for PaymentOptionsControl Cash Button
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Arguments</param>
        private void CashButton_Click(object sender, RoutedEventArgs e)
        {
            _processor = new(_order.Total);
            CashPaymentControl cash = new CashPaymentControl(_processor);
            cash.FinalizeButton.Click += FinalizeCashButton_Click;
            cash.ReturnButton.Click += ReturnButton_Click;
            this.DisplayContainer.Child = cash;
        }

        /// <summary>
        /// Event Handler for Finalize Button on Cash Payments
        /// </summary>
        /// <param name="sender">Finalize Button</param>
        /// <param name="e">Arguments</param>
        private void FinalizeCashButton_Click(object sender, RoutedEventArgs e)
        {
            PrintReceipt(true, _processor.ChangeOwed);
            ResetOrder();
        }

        /// <summary>
        /// EventHandler for PaymentOptionsControl Card Button
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Arguments</param>
        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            CardTransactionResult result = CardReader.RunCard();
            switch (result)
            {
                case CardTransactionResult.Approved:
                    MessageBox.Show("Transaction Approved....");
                    PrintReceipt(false, 0.00m);
                    ResetOrder();
                    break;
                case CardTransactionResult.Declined:
                    MessageBox.Show("Card Declined.... Try Again.");
                    break;
                case CardTransactionResult.ReadError:
                    MessageBox.Show("Card Read Error.... Try Again.");
                    break;
                case CardTransactionResult.InsufficientFunds:
                    MessageBox.Show("Insuffient Funds On Card.");
                    break;
                case CardTransactionResult.IncorrectPin:
                    MessageBox.Show("Incorrect Pin.");
                    break;
            }
        }

        /// <summary>
        /// EventHandler for PaymentOptionsControl Return Button
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Arguments</param>
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.DisplayContainer.Child = _orderControl;
        }

        /// <summary>
        /// Prints the Receipt using the RoundRegister Library
        /// </summary>
        /// <param name="isCash">Bool if cash was used to pay</param>
        /// <param name="change">Change Owed</param>
        private void PrintReceipt(bool isCash, decimal change)
        {
            string orderNum = "Order #" + _order.Number.ToString();

            string underscores = new('_', (36 - orderNum.Length) / 2);

            orderNum = underscores + orderNum + underscores;

            //Order Number
            PrintReceiptLine(orderNum);
            //Date and Time
            PrintReceiptLine("Placed on " + _order.PlacedAt.ToShortDateString() + " at " + _order.PlacedAt.ToShortTimeString());
            
            
            PrintReceiptLine("Order Summary:");
            //List of All items and customizations
            foreach (DinoMenuItem item in _order)
            {
                PrintReceiptLine(item.Name);
                foreach(string s in item.SpecialInstructions)
                {
                    PrintReceiptLine(" " + s);
                }
                string price = "$" + item.Price;
                PrintReceiptLine(new string('.', 35 - price.Length) + price);
            }
            //Subtotal
            PrintReceiptLine("Payment Details:");
            PrintReceiptLine("Subtotal: $" + _order.Subtotal.ToString());
            //Total
            PrintReceiptLine("Total: $" + _order.Total.ToString());
            //Payment method
            if (isCash)
            {
                PrintReceiptLine("Payment Method: Cash");
            } else
            {
                PrintReceiptLine("Payment Method: Card");
            }
            PrintReceiptLine("Change Owed: $" + change.ToString());

            //Cut the tape
            ReceiptPrinter.CutTape();
        }

        /// <summary>
        /// Recursive function to print a line on a receipt
        /// </summary>
        /// <param name="s">String to be printed</param>
        private void PrintReceiptLine(string s)
        {
            if (s.Length <= 40)
            {
                ReceiptPrinter.PrintLine(s);
                return;
            }
            ReceiptPrinter.PrintLine(s.Substring(0, 40));
            PrintReceiptLine(s.Substring(40));
        }


    }
}

