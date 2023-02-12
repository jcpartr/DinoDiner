namespace DinoDiner.Data.Entrees
{
    /// <summary>
    /// Class representing the Deinonychus Double Burger
    /// </summary>
    public class DeinonychusDouble : Burger
    {
        public DeinonychusDouble() : base("Deinonychus Double", 2, false, false, true, false, true, true, false, false, false, true, false, true) { }

        /// <summary>
        /// Returns a newly made list of nonstandard options
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> changes = new List<string>();
                if (Patties != 2)
                {
                    changes.Add($"Use {Patties} Patties");
                }
                if (Ketchup)
                {
                    changes.Add("Add Ketchup");
                }
                if (Mustard)
                {
                    changes.Add("Add Mustard");
                }
                if (!Pickle)
                {
                    changes.Add("No Pickles");
                }
                if (Mayo)
                {
                    changes.Add("Add Mayo");
                }
                if (!BBQ)
                {
                    changes.Add("No BBQ Sauce");
                }
                if (!Onion)
                {
                    changes.Add("No Onions");
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
                if (!SwissCheese)
                {
                    changes.Add("No Swiss Cheese");
                }
                if (Bacon)
                {
                    changes.Add("Add Bacon");
                }
                if (!Mushrooms)
                {
                    changes.Add("No Mushrooms");
                }
                return changes;
            }
        }
    }
}
