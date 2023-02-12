namespace DinoDiner.Data.Entrees
{
    /// <summary>
    /// Class representing the Brontowurst Menu Item
    /// </summary>
    public class Brontowurst : DinoMenuItem
    {
        /// <summary>
        /// Name of the Brontowurst Menu Item
        /// </summary>
        public override string Name { get; } = "Brontowurst";

        /// <summary>
        /// Price of the Brontowurst Menu Item
        /// </summary>
        public override decimal Price { get; } = 5.86m;

        /// <summary>
        /// Calories of the Brontowurst Menu Item
        /// </summary>
        public override uint Calories { get; } = 512;

        /// <summary>
        /// Bool if there are Onions, defaults to true
        /// </summary>
        public bool Onions
        {
            get { return _onions; }
            set
            {
                _onions = value;
                OnPropertyChanged("Onions");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for Onions
        /// </summary>
        private bool _onions = true;

        /// <summary>
        /// Bool if there are Peppers, default to true
        /// </summary>
        public bool Peppers
        {
            get { return _peppers; }
            set
            {
                _peppers = value;
                OnPropertyChanged("Peppers");
                OnPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// Private value for Peppers
        /// </summary>
        private bool _peppers = true;

        /// <summary>
        /// Changes to the normal menu item
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> changes = new List<string>();
                if (!Peppers) { changes.Add("Hold Peppers"); }
                if (!Onions) { changes.Add("Hold Onions"); }
                return changes;
            }
        }
    }
}
