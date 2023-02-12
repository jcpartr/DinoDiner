using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace DinoDiner.Data
{
    /// <summary>
    /// Class Representing an Order
    /// </summary>
    public class Order : ObservableCollection<DinoMenuItem>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Order()
        {
            CollectionChanged += CollectionChangedEventListener;
            Number = _nextOrderNumber;
            _nextOrderNumber++;
        }

        /// <summary>
        /// Event Listener for collection changes
        /// </summary>
        /// <param name="sender">Collection</param>
        /// <param name="e">Arguments</param>
        void CollectionChangedEventListener(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Subtotal)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Tax)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Total)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Calories)));

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems == null) { return; }
                    foreach (DinoMenuItem item in e.NewItems)
                    {
                        item.PropertyChanged += CollectionItemChangedEventListener;
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems == null) { return; }
                    foreach (DinoMenuItem item in e.OldItems)
                    {
                        item.PropertyChanged -= CollectionItemChangedEventListener;
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    throw new NotImplementedException("NotifyCollectionChangedAction.Replace Not Implemented");
                case NotifyCollectionChangedAction.Move:
                    throw new NotImplementedException("NotifyCollectionChangedAction.Move Not Implemented");
                case NotifyCollectionChangedAction.Reset:
                    throw new NotImplementedException("NotifyCollectionChangedAction.Reset Not Implemented");
            }

        }

        /// <summary>
        /// Event Listener For Items in Collection Changing
        /// </summary>
        /// <param name="sender">MenuItem</param>
        /// <param name="e">Arguments</param>
        void CollectionItemChangedEventListener(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Price")
            {
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Subtotal)));
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Tax)));
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Total)));
            }
            if (e.PropertyName == "Calories")
            {
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Calories)));
            }
        }

        /// <summary>
        /// Next order number
        /// </summary>
        private static uint _nextOrderNumber = 1;


        /// <summary>
        /// Order Number
        /// </summary>
        public uint Number { private set; get; }

        /// <summary>
        /// Time when order was placed
        /// </summary>
        public DateTime PlacedAt { get; } = DateTime.Now;

        /// <summary>
        /// Current Sales Tax Rate
        /// </summary>
        public decimal SalesTaxRate { get; set; } = 0.09m;

        /// <summary>
        /// Order Total Before Taxes
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal subtotal = 0m;
                foreach (DinoMenuItem item in this)
                {
                    subtotal += item.Price;
                }
                return subtotal;
            }
        }

        /// <summary>
        /// Taxes on the Order
        /// </summary>
        public decimal Tax
        {
            get
            {
                return Math.Round(Subtotal * SalesTaxRate, 2);
            }
        }

        /// <summary>
        /// Subtotal + Taxes
        /// </summary>
        public decimal Total
        {
            get
            {
                return Math.Round(Subtotal + Tax, 2);
            }
        }

        /// <summary>
        /// Total Calories in the order
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cal = 0;
                foreach (DinoMenuItem item in this)
                {
                    cal += item.Calories;
                }
                return cal;
            }
        }

    }
}
