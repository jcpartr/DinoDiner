namespace DinoDiner.Data.Entrees
{
    /// <summary>
    /// Class for the Veloci-Wraptor Menu Item
    /// </summary>
    public class VelociWraptor : DinoMenuItem
    {
        /// <summary>
        /// Name of the Veloci-Wraptor Menu item
        /// </summary>
        public override string Name { get; } = "Veloci-Wraptor";

        /// <summary>
        /// Price of the Veloci-Wraptor Menu Item
        /// </summary>
        public override decimal Price { get; } = 6.25m;

        /// <summary>
        /// Calories of the Veloci-Wraptor
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cal = 732;
                if (!Dressing) cal -= 94;
                if (!Cheese) cal -= 22;
                return cal;
            }
        }
        /// <summary>
        /// Bool if Dressing is added
        /// </summary>
        public bool Dressing
        {
            get { return _dressing; }
            set
            {
                _dressing = value;
                OnPropertyChanged("Calories");
                OnPropertyChanged("Dressing");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for Dressing
        /// </summary>
        private bool _dressing = true;
        /// <summary>
        /// Boolean if Cheese is added
        /// </summary>
        public bool Cheese
        {
            get { return _cheese; }
            set
            {
                _cheese = value;
                OnPropertyChanged("Calories");
                OnPropertyChanged("Cheese");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for Cheese
        /// </summary>
        private bool _cheese = true;

        /// <summary>
        /// Changes to the normal menu item
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> changes = new List<string>();
                if (!Cheese) { changes.Add("No Cheese"); }
                if (!Dressing) { changes.Add("No Dressing"); }
                return changes;
            }
        }
    }
}
