namespace DinoDiner.Data.Entrees
{
    /// <summary>
    /// Class for AllosaurusAllAmericanBurger
    /// </summary>
    public class AllosaurusAllAmericanBurger : Burger
    {
        public AllosaurusAllAmericanBurger() : base("Allosaurus All-American Burger", 1, true, true, true, false, false, false, false, false, false, false, false, false) { }

        /// <summary>
        /// Returns a newly made list of nonstandard options
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> changes = new List<string>();
                if (Patties != 1)
                {
                    changes.Add($"Use {Patties} Patties");
                }
                if (!Ketchup)
                {
                    changes.Add("No Ketchup");
                }
                if (!Mustard)
                {
                    changes.Add("No Mustard");
                }
                if (!Pickle)
                {
                    changes.Add("No Pickles");
                }
                if (Mayo)
                {
                    changes.Add("Add Mayo");
                }
                if (BBQ)
                {
                    changes.Add("Add BBQ Sauce");
                }
                if (Onion)
                {
                    changes.Add("Add Onions");
                }
                if (Tomato)
                {
                    changes.Add("Add Tomato");
                }
                if (Lettuce)
                {
                    changes.Add("Add Lettuce");
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
