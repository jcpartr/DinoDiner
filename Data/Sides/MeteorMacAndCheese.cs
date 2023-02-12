namespace DinoDiner.Data.Sides
{
    /// <summary>
    /// Class representing the Meteor Mac and Cheese Side
    /// </summary>
    public class MeteorMacAndCheese : DinoMenuItem
    {

        /// <summary>
        /// Name of the Meteor Mac and Cheese Item
        /// </summary>
        /// <returns>"[Size] Meteor Mac and Cheese"</returns>
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
                return size + " Meteor Mac & Cheese";
            }
        }

        /// <summary>
        /// Price of the Meteor Mac and Cheese depending on size
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
        /// Calories of the Meteor Mac and Cheese
        /// </summary>
        /// <exception cref="Exception">Thrown if no serving size selected</exception>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case ServingSize.Small: { return 425; }
                    case ServingSize.Medium: { return 510; }
                    case ServingSize.Large: { return 700; }
                    default: throw new Exception("Serving Size Not Selected");
                }
            }
        }

        /// <summary>
        /// Serving Size of the Meteor Mac and Cheese
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
                //Size is in name already
                return changes;
            }
        }
    }
}