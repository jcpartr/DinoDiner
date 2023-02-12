namespace DinoDiner.Data.Entrees
{
    /// <summary>
    /// Class representing the Dinonuggets Menu Item
    /// </summary>
    public class DinoNuggets : DinoMenuItem
    {
        /// <summary>
        /// Name of the Menu Item
        /// </summary>
        /// <returns>"[Number of Nuggets] Dino Nuggets"</returns>
        public override string Name
        {
            get
            {
                return Count + " Dino Nuggets";
            }
        }

        /// <summary>
        /// Price of the nuggets ordered
        /// </summary>
        /// <returns>$0.25 per nugget</returns>
        public override decimal Price
        {
            get
            {
                return .25m * Count;
            }
        }

        /// <summary>
        /// Calories of the nuggets ordered
        /// </summary>
        /// <returns>61 calories per nugget</returns>
        public override uint Calories
        {
            get
            {
                return 61 * Count;
            }
        }

        /// <summary>
        /// Number of nuggets ordered, defaults to 6
        /// </summary>
        public uint Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged("Count");
                OnPropertyChanged("Calories");
                OnPropertyChanged("Price");
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// private value for Count
        /// </summary>
        private uint _count = 6;

        /// <summary>
        /// Changes to the normal menu item
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                //Count change is in name already
                return new List<string>();
            }
        }


    }
}
