namespace DinoDiner.Data.Entrees
{
    /// <summary>
    /// Class representing the T-Rex Triple Burger
    /// </summary>
    public class TRexTripleBurger : Burger
    {
        /// <summary>
        /// Constructor for the T-Rex Triple
        /// </summary>
        public TRexTripleBurger() : base("T-Rex Triple Burger", 3, true, false, true, true, false, true, true, true, false, false, false, false) { }

        /// <summary>
        /// Returns a newly made list of nonstandard options
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> changes = new List<string>();
                if (Patties != 3)
                {
                    changes.Add($"Use {Patties} Patties");
                }
                if (!Ketchup)
                {
                    changes.Add("No Ketchup");
                }
                if (Mustard)
                {
                    changes.Add("Add Mustard");
                }
                if (!Pickle)
                {
                    changes.Add("No Pickles");
                }
                if (!Mayo)
                {
                    changes.Add("No Mayo");
                }
                if (BBQ)
                {
                    changes.Add("Add BBQ Sauce");
                }
                if (!Onion)
                {
                    changes.Add("No Onions");
                }
                if (!Tomato)
                {
                    changes.Add("No Tomato");
                }
                if (!Lettuce)
                {
                    changes.Add("No Lettuce");
                }
                if (AmericanCheese)
                {
                    changes.Add("Add American Cheese");
                }
                if (SwissCheese)
                {
                    changes.Add("Add Swiss Cheese");
                }
                if (Bacon)
                {
                    changes.Add("Add Bacon");
                }
                if (Mushrooms)
                {
                    changes.Add("Add Mushrooms");
                }
                return changes;
            }
        }
    }
}
