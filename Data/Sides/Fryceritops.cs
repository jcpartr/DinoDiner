namespace DinoDiner.Data.Sides
{
    /// <summary>
    /// Class representing the Fryceritops Menu item
    /// </summary>
    public class Fryceritops : DinoMenuItem
    {
        /// <summary>
        /// Name of the Fryceritops Item
        /// </summary>
        /// <returns>"[Size] Fryceritops"</returns>
        /// <exception cref="Exception">Thrown if no serving size selected</exception>
        public override string Name
        {
            get
            {
                string size = "";
                switch (Size)
                {
                    case ServingSize.Small: { size = "Small"; break; }
                    case ServingSize.Medium: { size = "Medium"; break; }
                    case ServingSize.Large: { size = "Large"; break; }
                    default: throw new Exception("Serving Size Not Selected");
                }
                return size + " Fryceritops";
            }
        }

        /// <summary>
        /// Price of the Fryceritops depending on size
        /// </summary>
        /// <exception cref="Exception">Thrown if no serving size selected</exception>
        public override decimal Price
        {
            get
            {
                switch (Size)
                {
                    case ServingSize.Small: return 3.50m;
                    case ServingSize.Medium: return 4.00m;
                    case ServingSize.Large: return 5.00m;
                    default: throw new Exception("Serving Size Not Selected");
                }
            }
        }

        /// <summary>
        /// Calories of the Fryceritops depending on Size and Sauce
        /// </summary>
        /// <exception cref="Exception">Thrown if no serving size selected</exception>
        public override uint Calories
        {
            get
            {
                uint cal = 0;
                switch (Size)
                {
                    case ServingSize.Small: { cal = 365; break; }
                    case ServingSize.Medium: { cal = 465; break; }
                    case ServingSize.Large: { cal = 510; break; }
                    default: throw new Exception("Serving Size Not Selected");
                }
                if (Sauce) cal += 80;
                return cal;
            }
        }

        /// <summary>
        /// Bool if Salt is added
        /// </summary>
        public bool Salt
        {
            get { return _salt; }
            set
            {
                _salt = value;
                OnPropertyChanged("Salt");
                OnPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// Private value for Salt
        /// </summary>
        private bool _salt = true;

        /// <summary>
        /// Bool if Sauce is added
        /// </summary>
        public bool Sauce
        {
            get { return _sauce; }
            set
            {
                _sauce = value;
                OnPropertyChanged("Sauce");
                OnPropertyChanged("Calories");
                OnPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// Private value for Sauce
        /// </summary>
        private bool _sauce = false;

        /// <summary>
        /// Serving Size of the Fryceritops
        /// </summary>
        public ServingSize Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged("Size");
                OnPropertyChanged("Calories");
                OnPropertyChanged("Price");
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Private value for Size
        /// </summary>
        private ServingSize _size;

        /// <summary>
        /// Changes to the normal menu item
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> changes = new List<string>();
                if (!Salt) { changes.Add("No Salt"); }
                if (Sauce) { changes.Add("Add Sauce"); }
                return changes;
            }
        }


    }
}
