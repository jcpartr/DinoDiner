namespace DinoDiner.Data.Entrees
{
    /// <summary>
    /// A class representing a Prehistoric PBJ sandwich
    /// </summary>
    public class PrehistoricPBJ : DinoMenuItem
    {
        /// <summary>
        /// Name of the Sandwich
        /// </summary>
        public override string Name { get; } = "Prehistoric PBJ";

        /// <summary>
        /// The price of the PBJ
        /// </summary>
        public override decimal Price { get; } = 3.75m;

        /// <summary>
        /// The calories of the PBJ
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 148;
                if (PeanutButter) calories += 188;
                if (Jelly) calories += 62;
                return calories;
            }
        }

        /// <summary>
        /// Indicates if the PBJ was made with peanut butter
        /// </summary>
        public bool PeanutButter
        {
            get { return _peanutButter; }
            set
            {
                _peanutButter = value;
                OnPropertyChanged("Calories");
                OnPropertyChanged("PeanutButter");
                OnPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// Private value for PeanutButter
        /// </summary>
        private bool _peanutButter = true;

        /// <summary>
        /// Indicates the PBJ was made with jelly
        /// </summary>
        public bool Jelly
        {
            get { return _jelly; }
            set
            {
                _jelly = value;
                OnPropertyChanged("Calories");
                OnPropertyChanged("Jelly");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for Jelly
        /// </summary>
        private bool _jelly = true;
        /// <summary>
        /// Indicates the PBJ is served toasted
        /// </summary>
        public bool Toasted
        {
            get { return _toasted; }
            set
            {
                _toasted = value;
                OnPropertyChanged("Toasted");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for Toasted
        /// </summary>
        private bool _toasted = true;

        /// <summary>
        /// Changes to the normal menu item
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> changes = new List<string>();
                if (!Toasted) { changes.Add("Do Not Toast"); }
                if (!Jelly) { changes.Add("No Jelly"); }
                if (!PeanutButter) { changes.Add("No Peanutbutter"); }
                return changes;

            }
        }
    }
}