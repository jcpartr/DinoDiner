namespace DinoDiner.Data.Sides
{
    /// <summary>
    /// Class representing the Mezzeorealla Stick menu item 
    /// </summary>
    public class MezzorellaSticks : DinoMenuItem
    {

        /// <summary>
        /// Name of the Mezzorella Sticks Item
        /// </summary>
        /// <returns>"[Size] Mezzorella Sticks"</returns>
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
                return size + " Mezzorella Sticks";
            }
        }

        /// <summary>
        /// Price of the Mezzorella Sticks depending on size
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
        /// Calories of the Mezzorella Sticks
        /// </summary>
        /// <exception cref="Exception">Thrown if no serving size selected</exception>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case ServingSize.Small: { return 530; }
                    case ServingSize.Medium: { return 620; }
                    case ServingSize.Large: { return 730; }
                    default: throw new Exception("Serving Size Not Selected");
                }
            }
        }

        /// <summary>
        /// Serving Size of the Mezzorella Sticks
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
