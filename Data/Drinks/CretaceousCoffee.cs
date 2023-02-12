namespace DinoDiner.Data.Drinks
{
    /// <summary>
    /// Class representing the Cretaceous Coffee Drink
    /// </summary>
    public class CretaceousCoffee : DinoMenuItem
    {
        /// <summary>
        /// Name of the coffee
        /// </summary>
        public override string Name
        {
            get
            {
                if (Size == ServingSize.Small) { return "Small Cretaceous Coffee"; }
                if (Size == ServingSize.Medium) { return "Medium Cretaceous Coffee"; }
                if (Size == ServingSize.Large) { return "Large Cretaceous Coffee"; }
                else throw new Exception("Size Not Selected!");
            }
        }
        /// <summary>
        /// Price of the coffee
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (Size == ServingSize.Small) { return .75m; }
                if (Size == ServingSize.Medium) { return 1.25m; }
                if (Size == ServingSize.Large) { return 2.00m; }
                throw new Exception("Size Not Selected!");
            }
        }
        /// <summary>
        /// Calories in the coffee
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Cream) { return 64; }
                return 0;
            }
        }

        /// <summary>
        /// Size of the coffee
        /// </summary>
        public ServingSize Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged("Size");
                OnPropertyChanged("Price");
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Private value for Size
        /// </summary>
        private ServingSize _size;
        /// <summary>
        /// Bool if the coffee is served with cream
        /// </summary>
        public bool Cream
        {
            get { return _cream; }
            set
            {
                _cream = value;
                OnPropertyChanged("Cream");
                OnPropertyChanged("Calories");
                OnPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// List of nonstandard changes
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                _specialinstructions = new();
                if (Cream)
                {
                    _specialinstructions.Add("Add Cream");
                }
                return _specialinstructions;
            }
        }

        /// <summary>
        /// Private list of nonstandard changes
        /// </summary>
        private List<string> _specialinstructions = new List<string>();

        /// <summary>
        /// Private value for Cream
        /// </summary>
        private bool _cream = false;
    }
}
