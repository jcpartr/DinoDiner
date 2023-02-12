namespace DinoDiner.Data.Entrees
{
    /// <summary>
    /// Class representing a burger menu item
    /// </summary>
    public abstract class Burger : DinoMenuItem
    {
        /// <summary>
        /// Public uint of patties on burger
        /// </summary>
        public uint Patties
        {
            get { return _patties; }
            set
            {
                _patties = value;
                OnPropertyChanged("Patties");
                OnPropertyChanged("Price");
                OnPropertyChanged("Calories");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for Patties
        /// </summary>
        private uint _patties;

        /// <summary>
        /// Bool if Ketchup is on the burger
        /// </summary>
        public bool Ketchup
        {
            get { return _ketchup; }
            set
            {
                _ketchup = value;
                OnPropertyChanged("Ketchup");
                OnPropertyChanged("Price");
                OnPropertyChanged("Calories");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for Ketchup
        /// </summary>
        private bool _ketchup;

        /// <summary>
        /// Bool if Mustard is on the burger
        /// </summary>
        public bool Mustard
        {
            get { return _mustard; }
            set
            {
                _mustard = value;
                OnPropertyChanged("Mustard");
                OnPropertyChanged("Price");
                OnPropertyChanged("Calories");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for Mustard
        /// </summary>
        private bool _mustard;

        /// <summary>
        /// Bool if Pickles is on the burger
        /// </summary>
        public bool Pickle
        {
            get { return _pickle; }
            set
            {
                _pickle = value;
                OnPropertyChanged("Pickle");
                OnPropertyChanged("Price");
                OnPropertyChanged("Calories");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for Pickle
        /// </summary>
        private bool _pickle;

        /// <summary>
        /// Bool if Mayo is on the burger
        /// </summary>
        public bool Mayo
        {
            get { return _mayo; }
            set
            {
                _mayo = value;
                OnPropertyChanged("Mayo");
                OnPropertyChanged("Price");
                OnPropertyChanged("Calories");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for Mayo
        /// </summary>
        private bool _mayo;

        /// <summary>
        /// Bool if BBQ is on the burger
        /// </summary>
        public bool BBQ
        {
            get { return _bbq; }
            set
            {
                _bbq = value;
                OnPropertyChanged("BBQ");
                OnPropertyChanged("Price");
                OnPropertyChanged("Calories");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for BBQ
        /// </summary>
        private bool _bbq;

        /// <summary>
        /// Bool if Onions are on the burger
        /// </summary>
        public bool Onion
        {
            get { return _onion; }
            set
            {
                _onion = value;
                OnPropertyChanged("Onion");
                OnPropertyChanged("Price");
                OnPropertyChanged("Calories");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for Onions
        /// </summary>
        private bool _onion;

        /// <summary>
        /// Bool if Tomato is on the burger
        /// </summary>
        public bool Tomato
        {
            get { return _tomato; }
            set
            {
                _tomato = value;
                OnPropertyChanged("Tomato");
                OnPropertyChanged("Price");
                OnPropertyChanged("Calories");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for Tomato
        /// </summary>
        private bool _tomato;

        /// <summary>
        /// Bool if Lettuce is on the burger
        /// </summary>
        public bool Lettuce
        {
            get { return _lettuce; }
            set
            {
                _lettuce = value;
                OnPropertyChanged("Lettuce");
                OnPropertyChanged("Price");
                OnPropertyChanged("Calories");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for Lettuce
        /// </summary>
        private bool _lettuce;

        /// <summary>
        /// Bool if AmericanCheese is on the burger
        /// </summary>
        public bool AmericanCheese
        {
            get { return _americanCheese; }
            set
            {
                _americanCheese = value;
                OnPropertyChanged("AmericanCheese");
                OnPropertyChanged("Price");
                OnPropertyChanged("Calories");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for AmericanCheese
        /// </summary>
        private bool _americanCheese;

        /// <summary>
        /// Bool if SwissCheese is on the burger
        /// </summary>
        public bool SwissCheese
        {
            get { return _swissCheese; }
            set
            {
                _swissCheese = value;
                OnPropertyChanged("SwissCheese");
                OnPropertyChanged("Price");
                OnPropertyChanged("SpecialInstructions");
                OnPropertyChanged("Calories");
            }
        }
        /// <summary>
        /// Private value for SwissCheese
        /// </summary>
        private bool _swissCheese;

        /// <summary>
        /// Bool if Bacon is on the burger
        /// </summary>
        public bool Bacon
        {
            get { return _bacon; }
            set
            {
                _bacon = value;
                OnPropertyChanged("Bacon");
                OnPropertyChanged("Price");
                OnPropertyChanged("SpecialInstructions");
                OnPropertyChanged("Calories");
            }
        }
        /// <summary>
        /// Private value for Bacon
        /// </summary>
        private bool _bacon;

        /// <summary>
        /// Bool if AmericanCheese is on the burger
        /// </summary>
        public bool Mushrooms
        {
            get { return _mushrooms; }
            set
            {
                _mushrooms = value;
                OnPropertyChanged("Mushrooms");
                OnPropertyChanged("Price");
                OnPropertyChanged("Calories");
                OnPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Private value for AmericanCheese
        /// </summary>
        private bool _mushrooms;

        /// <summary>
        /// Name of the burger
        /// </summary>
        public override string Name { get; }

        /// <summary>
        /// Calculates and returns the price of the burger
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 1.50m * Patties;
                if (Ketchup) { price += .20m; }
                if (Mustard) { price += .20m; }
                if (Pickle) { price += .20m; }
                if (Mayo) { price += .20m; }
                if (BBQ) { price += .10m; }
                if (Onion) { price += .40m; }
                if (Tomato) { price += .40m; }
                if (Lettuce) { price += .30m; }
                if (AmericanCheese) { price += .25m; }
                if (SwissCheese) { price += .25m; }
                if (Bacon) { price += .50m; }
                if (Mushrooms) { price += .40m; }
                return price;
            }
        }

        /// <summary>
        /// Calories of the burger
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cal = 204 * Patties;
                if (Ketchup) { cal += 19; }
                if (Mustard) { cal += 3; }
                if (Pickle) { cal += 7; }
                if (Mayo) { cal += 94; }
                if (BBQ) { cal += 29; }
                if (Onion) { cal += 44; }
                if (Tomato) { cal += 22; }
                if (Lettuce) { cal += 5; }
                if (AmericanCheese) { cal += 104; }
                if (SwissCheese) { cal += 106; }
                if (Bacon) { cal += 43; }
                if (Mushrooms) { cal += 4; }
                return cal;
            }
        }

        /// <summary>
        /// Constructor for the burger menu item.
        /// </summary>
        /// <param name="name">Name of the burger</param>
        /// <param name="patties">Number of Patties</param>
        /// <param name="ketchup">Bool if Ketchup</param>
        /// <param name="mustard">Bool if Mustard</param>
        /// <param name="pickle">Bool if Pickles</param>
        /// <param name="mayo">Bool if Mayo</param>
        /// <param name="bbq">Bool if BBQ</param>
        /// <param name="onion">Bool if Onions</param>
        /// <param name="tomato">Bool if Tomatoes</param>
        /// <param name="lettuce">Bool if Lettuce</param>
        /// <param name="americanCheese">Bool if American Cheese</param>
        /// <param name="swissCheese">Bool if Swiss Cheese</param>
        /// <param name="bacon">Bool if Bacon</param>
        /// <param name="mushrooms">Bool if Mushrooms</param>
        public Burger(string name, uint patties, bool ketchup, bool mustard, bool pickle, bool mayo, bool bbq, bool onion, bool tomato, bool lettuce, bool americanCheese, bool swissCheese, bool bacon, bool mushrooms)
        {
            Name = name;
            Patties = patties;
            Ketchup = ketchup;
            Mustard = mustard;
            Pickle = pickle;
            Mayo = mayo;
            BBQ = bbq;
            Onion = onion;
            Tomato = tomato;
            Lettuce = lettuce;
            AmericanCheese = americanCheese;
            SwissCheese = swissCheese;
            Bacon = bacon;
            Mushrooms = mushrooms;
        }
    }
}