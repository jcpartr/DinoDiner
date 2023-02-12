namespace DinoDiner.Data.Entrees
{
    /// <summary>
    /// Class representing the Carnotaurus cheese burger
    /// </summary>
    public class CarnotaurusCheeseburger : Burger
    {
        public CarnotaurusCheeseburger() : base("Carnotaurus Cheeseburger", 1, true, false, true, false, false, false, true, false, true, false, false, false) { }

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
                if (BBQ)
                {
                    changes.Add("Add BBQ Sauce");
                }
                if (Onion)
                {
                    changes.Add("Add Onions");
                }
                if (!Tomato)
                {
                    changes.Add("No Tomato");
                }
                if (Lettuce)
                {
                    changes.Add("Add Lettuce");
                }
                if (!AmericanCheese)
                {
                    changes.Add("No American Cheese");
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
