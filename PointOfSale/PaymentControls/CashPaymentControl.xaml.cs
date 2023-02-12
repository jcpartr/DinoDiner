using DinoDiner.Data;
using DinoDiner.PointOfSale.PaymentControls;
using System.Windows;
using System.Windows.Controls;

namespace DinoDiner.PointOfSale
{
    /// <summary>
    /// Interaction logic for CashPaymentControl.xaml
    /// </summary>
    public partial class CashPaymentControl : UserControl
    {
        /// <summary>
        /// Reference to the CashDrawerProcessor
        /// </summary>
        private CashDrawerProcessor _processor;
        
        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="processor">CashDrawerProcessor</param>
        public CashPaymentControl(CashDrawerProcessor processor)
        {
            InitializeComponent();
            this.DataContext = processor;
            _processor = processor;
            SetLabelsText();
            SetupAmountControls();
        }

        /// <summary>
        /// Sets up the buttons and databinding for each BillAmountControl and CoinAmountControl
        /// </summary>
        private void SetupAmountControls()
        {
            //Hundreds
            HundredsControl.PaidAmount.SetBinding(TextBlock.TextProperty, "PaidHundreds");
            HundredsControl.IncreaseButton.Tag = "PaidHundreds";
            HundredsControl.IncreaseButton.Click += IncreasePaidAmount_Click;
            HundredsControl.DecreaseButton.Tag = "PaidHundreds";
            HundredsControl.DecreaseButton.Click += DecreasePaidAmount_Click;
            HundredsControl.ChangeAmount.SetBinding(TextBlock.TextProperty, "ChangeHundreds");
            //Fifties
            FiftiesControl.PaidAmount.SetBinding(TextBlock.TextProperty, "PaidFifties");
            FiftiesControl.IncreaseButton.Tag = "PaidFifties";
            FiftiesControl.IncreaseButton.Click += IncreasePaidAmount_Click;
            FiftiesControl.DecreaseButton.Tag = "PaidFifties";
            FiftiesControl.DecreaseButton.Click += DecreasePaidAmount_Click;
            FiftiesControl.ChangeAmount.SetBinding(TextBlock.TextProperty, "ChangeFifties");
            //Twenties
            TwentiesControl.PaidAmount.SetBinding(TextBlock.TextProperty, "PaidTwenties");
            TwentiesControl.IncreaseButton.Tag = "PaidTwenties";
            TwentiesControl.IncreaseButton.Click += IncreasePaidAmount_Click;
            TwentiesControl.DecreaseButton.Tag = "PaidTwenties";
            TwentiesControl.DecreaseButton.Click += DecreasePaidAmount_Click;
            TwentiesControl.ChangeAmount.SetBinding(TextBlock.TextProperty, "ChangeTwenties");
            //Tens
            TensControl.PaidAmount.SetBinding(TextBlock.TextProperty, "PaidTens");
            TensControl.IncreaseButton.Tag = "PaidTens";
            TensControl.IncreaseButton.Click += IncreasePaidAmount_Click;
            TensControl.DecreaseButton.Tag = "PaidTens";
            TensControl.DecreaseButton.Click += DecreasePaidAmount_Click;
            TensControl.ChangeAmount.SetBinding(TextBlock.TextProperty, "ChangeTens");
            //Fives
            FivesControl.PaidAmount.SetBinding(TextBlock.TextProperty, "PaidFives");
            FivesControl.IncreaseButton.Tag = "PaidFives";
            FivesControl.IncreaseButton.Click += IncreasePaidAmount_Click;
            FivesControl.DecreaseButton.Tag = "PaidFives";
            FivesControl.DecreaseButton.Click += DecreasePaidAmount_Click;
            FivesControl.ChangeAmount.SetBinding(TextBlock.TextProperty, "ChangeFives");
            //Twos
            TwosControl.PaidAmount.SetBinding(TextBlock.TextProperty, "PaidTwos");
            TwosControl.IncreaseButton.Tag = "PaidTwos";
            TwosControl.IncreaseButton.Click += IncreasePaidAmount_Click;
            TwosControl.DecreaseButton.Tag = "PaidTwos";
            TwosControl.DecreaseButton.Click += DecreasePaidAmount_Click;
            TwosControl.ChangeAmount.SetBinding(TextBlock.TextProperty, "ChangeTwos");
            //Ones
            OnesControl.PaidAmount.SetBinding(TextBlock.TextProperty, "PaidOnes");
            OnesControl.IncreaseButton.Tag = "PaidOnes";
            OnesControl.IncreaseButton.Click += IncreasePaidAmount_Click;
            OnesControl.DecreaseButton.Tag = "PaidOnes";
            OnesControl.DecreaseButton.Click += DecreasePaidAmount_Click;
            OnesControl.ChangeAmount.SetBinding(TextBlock.TextProperty, "ChangeOnes");
            //DollarCoins
            DollarCoinsControl.PaidAmount.SetBinding(TextBlock.TextProperty, "PaidDollarCoins");
            DollarCoinsControl.IncreaseButton.Tag = "PaidDollarCoins";
            DollarCoinsControl.IncreaseButton.Click += IncreasePaidAmount_Click;
            DollarCoinsControl.DecreaseButton.Tag = "PaidDollarCoins";
            DollarCoinsControl.DecreaseButton.Click += DecreasePaidAmount_Click;
            DollarCoinsControl.ChangeAmount.SetBinding(TextBlock.TextProperty, "ChangeDollarCoins");
            //HalfDollarCoins
            HalfDollarCoinsControl.PaidAmount.SetBinding(TextBlock.TextProperty, "PaidHalfDollarCoins");
            HalfDollarCoinsControl.IncreaseButton.Tag = "PaidHalfDollarCoins";
            HalfDollarCoinsControl.IncreaseButton.Click += IncreasePaidAmount_Click;
            HalfDollarCoinsControl.DecreaseButton.Tag = "PaidHalfDollarCoins";
            HalfDollarCoinsControl.DecreaseButton.Click += DecreasePaidAmount_Click;
            HalfDollarCoinsControl.ChangeAmount.SetBinding(TextBlock.TextProperty, "ChangeHalfDollarCoins");
            //Quarters
            QuartersControl.PaidAmount.SetBinding(TextBlock.TextProperty, "PaidQuarters");
            QuartersControl.IncreaseButton.Tag = "PaidQuarters";
            QuartersControl.IncreaseButton.Click += IncreasePaidAmount_Click;
            QuartersControl.DecreaseButton.Tag = "PaidQuarters";
            QuartersControl.DecreaseButton.Click += DecreasePaidAmount_Click;
            QuartersControl.ChangeAmount.SetBinding(TextBlock.TextProperty, "ChangeQuarters");
            //Dimes
            DimesControl.PaidAmount.SetBinding(TextBlock.TextProperty, "PaidDimes");
            DimesControl.IncreaseButton.Tag = "PaidDimes";
            DimesControl.IncreaseButton.Click += IncreasePaidAmount_Click;
            DimesControl.DecreaseButton.Tag = "PaidDimes";
            DimesControl.DecreaseButton.Click += DecreasePaidAmount_Click;
            DimesControl.ChangeAmount.SetBinding(TextBlock.TextProperty, "ChangeDimes");
            //Nickles
            NicklesControl.PaidAmount.SetBinding(TextBlock.TextProperty, "PaidNickles");
            NicklesControl.IncreaseButton.Tag = "PaidNickles";
            NicklesControl.IncreaseButton.Click += IncreasePaidAmount_Click;
            NicklesControl.DecreaseButton.Tag = "PaidNickles";
            NicklesControl.DecreaseButton.Click += DecreasePaidAmount_Click;
            NicklesControl.ChangeAmount.SetBinding(TextBlock.TextProperty, "ChangeNickles");
            //Pennies
            PenniesControl.PaidAmount.SetBinding(TextBlock.TextProperty, "PaidPennies");
            PenniesControl.IncreaseButton.Tag = "PaidPennies";
            PenniesControl.IncreaseButton.Click += IncreasePaidAmount_Click;
            PenniesControl.DecreaseButton.Tag = "PaidPennies";
            PenniesControl.DecreaseButton.Click += DecreasePaidAmount_Click;
            PenniesControl.ChangeAmount.SetBinding(TextBlock.TextProperty, "ChangePennies");
        }

        /// <summary>
        /// Event Handler for Increasing the amount given by customer
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Arguments</param>
        private void IncreasePaidAmount_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.Tag)
                {
                    case "PaidHundreds":
                        _processor.PaidHundreds++;
                        break;
                    case "PaidFifties":
                        _processor.PaidFifties++;
                        break;
                    case "PaidTwenties":
                        _processor.PaidTwenties++;
                        break;
                    case "PaidTens":
                        _processor.PaidTens++;
                        break;
                    case "PaidFives":
                        _processor.PaidFives++;
                        break;
                    case "PaidTwos":
                        _processor.PaidTwos++;
                        break;
                    case "PaidOnes":
                        _processor.PaidOnes++;
                        break;
                    case "PaidDollarCoins":
                        _processor.PaidDollarCoins++;
                        break;
                    case "PaidHalfDollarCoins":
                        _processor.PaidHalfDollarCoins++;
                        break;
                    case "PaidQuarters":
                        _processor.PaidQuarters++;
                        break;
                    case "PaidDimes":
                        _processor.PaidDimes++;
                        break;
                    case "PaidNickles":
                        _processor.PaidNickles++;
                        break;
                    case "PaidPennies":
                        _processor.PaidPennies++;
                        break;
                }
            }
        }

        /// <summary>
        /// Event Handler for Increasing the amount given by customer
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Arguments</param>
        private void DecreasePaidAmount_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.Tag)
                {
                    case "PaidHundreds":
                        if(_processor.PaidHundreds > 0) _processor.PaidHundreds--;
                        break;
                    case "PaidFifties":
                        if (_processor.PaidFifties > 0) _processor.PaidFifties--;
                        break;
                    case "PaidTwenties":
                        if (_processor.PaidTwenties > 0) _processor.PaidTwenties--;
                        break;
                    case "PaidTens":
                        if (_processor.PaidTens > 0) _processor.PaidTens--;
                        break;
                    case "PaidFives":
                        if (_processor.PaidFives > 0) _processor.PaidFives--;
                        break;
                    case "PaidTwos":
                        if (_processor.PaidTwos > 0) _processor.PaidTwos--;
                        break;
                    case "PaidOnes":
                        if (_processor.PaidOnes > 0) _processor.PaidOnes--;
                        break;
                    case "PaidDollarCoins":
                        if (_processor.PaidDollarCoins > 0) _processor.PaidDollarCoins--;
                        break;
                    case "PaidHalfDollarCoins":
                        if (_processor.PaidHalfDollarCoins > 0) _processor.PaidHalfDollarCoins--;
                        break;
                    case "PaidQuarters":
                        if (_processor.PaidQuarters > 0) _processor.PaidQuarters--;
                        break;
                    case "PaidDimes":
                        if (_processor.PaidDimes > 0) _processor.PaidDimes--;
                        break;
                    case "PaidNickles":
                        if (_processor.PaidNickles > 0) _processor.PaidNickles--;
                        break;
                    case "PaidPennies":
                        if (_processor.PaidPennies > 0) _processor.PaidPennies--;
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the Label Text for each Bill and Coin control
        /// </summary>
        private void SetLabelsText()
        {
            HundredsControl.BillLabel.Text = "$100";
            FiftiesControl.BillLabel.Text = "$50";
            TwentiesControl.BillLabel.Text = "$20";
            TensControl.BillLabel.Text = "$10";
            FivesControl.BillLabel.Text = "$5";
            TwosControl.BillLabel.Text = "$2";
            OnesControl.BillLabel.Text = "$1";

            DollarCoinsControl.CoinLabel.Text = "$1";
            HalfDollarCoinsControl.CoinLabel.Text = "50𝇍";
            QuartersControl.CoinLabel.Text = "25𝇍";
            DimesControl.CoinLabel.Text = "10𝇍";
            NicklesControl.CoinLabel.Text = "5𝇍";
            PenniesControl.CoinLabel.Text = "1𝇍";
        }


    }
}
