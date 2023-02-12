namespace DinoDiner.Data.Sides
{
    /// <summary>
    /// Class representing the Triceritots Menu item
    /// </summary>
    public class Triceritots : DinoMenuItem
    {
        /// <summary>
        /// Name of the Triceritots Item
        /// </summary>
        /// <returns>"[Size] Triceritots"</returns>
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
                return size + " Triceritots";
            }
        }

        /// <summary>
        /// Price of the Triceritots depending on size
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
                    case ServingSize.Large: return 5.25m;
                    default: throw new Exception("Serving Size Not Selected");
                }
            }
        }

        /// <summary>
        /// Calories of the Triceritots
        /// </summary>
        /// <exception cref="Exception">Thrown if no serving size selected</exception>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case ServingSize.Small: { return 351; }
                    case ServingSize.Medium: { return 409; }
                    case ServingSize.Large: { return 583; }
                    default: throw new Exception("Serving Size Not Selected");
                }
            }
        }

        /// <summary>
        /// Serving Size of the Triceritots
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
                //Size is already in name
                return changes;
            }
        }
    }
}
