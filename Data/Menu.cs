using DinoDiner.Data.Drinks;
using DinoDiner.Data.Entrees;
using DinoDiner.Data.Sides;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DinoDiner.Data
{
    /// <summary>
    /// Class for interfacing with the website
    /// </summary>
    static public class Menu
    {
        /// <summary>
        /// Returns a IEnumberable instance of all entrees
        /// </summary>
        static public IEnumerable<DinoMenuItem> Entrees
        {
            get
            {
                List<DinoMenuItem> items = new()
                {
                    new AllosaurusAllAmericanBurger(),
                    new DeinonychusDouble(),
                    new CarnotaurusCheeseburger(),
                    new TRexTripleBurger(),
                    new Brontowurst(),
                    new DinoNuggets(),
                    new PterodactylWings(),
                    new PrehistoricPBJ(),
                    new VelociWraptor()
                };
                return items;
            }
        }

        /// <summary>
        /// Returns a IEnumberable instance of all sides
        /// </summary>
        static public IEnumerable<DinoMenuItem> Sides
        {
            get
            {
                List<DinoMenuItem> items = new()
                {
                    new Fryceritops() { Size = ServingSize.Small },
                    new Fryceritops() { Size = ServingSize.Medium },
                    new Fryceritops() { Size = ServingSize.Large },

                    new MeteorMacAndCheese() { Size = ServingSize.Small },
                    new MeteorMacAndCheese() { Size = ServingSize.Medium },
                    new MeteorMacAndCheese() { Size = ServingSize.Large },

                    new MezzorellaSticks() { Size = ServingSize.Small },
                    new MezzorellaSticks() { Size = ServingSize.Medium },
                    new MezzorellaSticks() { Size = ServingSize.Large },

                    new Triceritots() { Size = ServingSize.Small },
                    new Triceritots() { Size = ServingSize.Medium },
                    new Triceritots() { Size = ServingSize.Large }
                };
                return items;
            }
        }

        /// <summary>
        /// Returns a IEnumberable instance of all Drinks
        /// </summary>
        static public IEnumerable<DinoMenuItem> Drinks
        {
            get
            {
                List<DinoMenuItem> items = new()
                {
                    new Plilosoda() { Size = ServingSize.Small },
                    new Plilosoda() { Size = ServingSize.Medium },
                    new Plilosoda() { Size = ServingSize.Large },

                    new CretaceousCoffee() { Size = ServingSize.Small },
                    new CretaceousCoffee() { Size = ServingSize.Medium },
                    new CretaceousCoffee() { Size = ServingSize.Large }
                };
                return items;
            }
        }

        /// <summary>
        /// Returns a IEnumberable instance of all Menu Items
        /// </summary>
        static public IEnumerable<DinoMenuItem> FullMenu
        {
            get
            {
                List<DinoMenuItem> items = new()
                {
                    //Entrees
                    new AllosaurusAllAmericanBurger(),
                    new DeinonychusDouble(),
                    new CarnotaurusCheeseburger(),
                    new TRexTripleBurger(),
                    new Brontowurst(),
                    new DinoNuggets(),
                    new PterodactylWings(),
                    new PrehistoricPBJ(),
                    new VelociWraptor(),
                    //Sides
                    new Fryceritops() { Size = ServingSize.Small },
                    new Fryceritops() { Size = ServingSize.Medium },
                    new Fryceritops() { Size = ServingSize.Large },

                    new MeteorMacAndCheese() { Size = ServingSize.Small },
                    new MeteorMacAndCheese() { Size = ServingSize.Medium },
                    new MeteorMacAndCheese() { Size = ServingSize.Large },

                    new MezzorellaSticks() { Size = ServingSize.Small },
                    new MezzorellaSticks() { Size = ServingSize.Medium },
                    new MezzorellaSticks() { Size = ServingSize.Large },

                    new Triceritots() { Size = ServingSize.Small },
                    new Triceritots() { Size = ServingSize.Medium },
                    new Triceritots() { Size = ServingSize.Large },
                    //Drinks
                    new Plilosoda() { Size = ServingSize.Small },
                    new Plilosoda() { Size = ServingSize.Medium },
                    new Plilosoda() { Size = ServingSize.Large },

                    new CretaceousCoffee() { Size = ServingSize.Small },
                    new CretaceousCoffee() { Size = ServingSize.Medium },
                    new CretaceousCoffee() { Size = ServingSize.Large }
                };
                return items;
            }
        }

        /// <summary>
        /// Retruns a list of menu item types
        /// </summary>
        public static string[] MenuItemTypes
        {
            get => new string[]
            {
                "Entrees",
                "Sides",
                "Drinks"
            };
        }

        /// <summary>
        /// Searches the full menu for the search parameters
        /// </summary>
        /// <param name="terms">Search Terms</param>
        /// <param name="itemTypes">Item Types</param>
        /// <param name="priceMin">Price Minimum</param>
        /// <param name="priceMax">Price Maximum</param>
        /// <param name="caloriesMin">Calories Minimum</param>
        /// <param name="caloriesMax">Calories Maximum</param>
        /// <returns>A dictionary separating the search results by type</returns>
        public static Dictionary<string, IEnumerable<DinoMenuItem>> Search (string? terms, string[] itemTypes, double? priceMin, double? priceMax, double? caloriesMin, double? caloriesMax) 
        {
            Dictionary<string, IEnumerable<DinoMenuItem>> results = new();
            
            bool hasTypeFilter = itemTypes.Length > 0;
            //Filtered Case
            //Entrees
            if (itemTypes.Contains("Entrees") || !hasTypeFilter)
            {
                IEnumerable<DinoMenuItem> entrees = SearchbyTerms(Entrees, terms);
                entrees = FilterByPrice(entrees, priceMin, priceMax);
                entrees = FilterByCalories(entrees, caloriesMin, caloriesMax);
                if (entrees.Count() > 0) results.Add("Entrees", entrees);
            }
            //Sides
            if (itemTypes.Contains("Sides") || !hasTypeFilter)
            {
                IEnumerable<DinoMenuItem> sides = SearchbyTerms(Sides, terms);
                sides = FilterByPrice(sides, priceMin, priceMax);
                sides = FilterByCalories(sides, caloriesMin, caloriesMax);
                if (sides.Count() > 0) results.Add("Sides", sides);
            }
            //Drinks
            if (itemTypes.Contains("Drinks") || !hasTypeFilter)
            {
                IEnumerable<DinoMenuItem> drinks = SearchbyTerms(Drinks, terms);
                drinks = FilterByPrice(drinks, priceMin, priceMax);
                drinks = FilterByCalories(drinks, caloriesMin, caloriesMax);
                if(drinks.Count() > 0) results.Add("Drinks", drinks);
            }
            return results;
        }

        

        /// <summary>
        /// Searches through the full menu for items that fit the search terms
        /// </summary>
        /// <param name="terms">Search Terms</param>
        /// <param name="items">Item list</param>
        /// <returns>List of items that fit the search</returns>
        public static IEnumerable<DinoMenuItem> SearchbyTerms(IEnumerable<DinoMenuItem> items, string? terms)
        {
            List<DinoMenuItem> results = new();

            if (terms == null) return items;

            string[] termList = terms.Split(" ");

            foreach (DinoMenuItem item in items)
            {
                foreach (string term in termList)
                {
                    if (item.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase))
                    {
                        results.Add(item);
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Filters the search by menu item type
        /// </summary>
        /// <param name="items">Previous search</param>
        /// <param name="types">Filter types</param>
        /// <returns>Filtered list</returns>
        public static IEnumerable<DinoMenuItem> FilterByType(IEnumerable<DinoMenuItem> items, IEnumerable<string> types)
        {
            List<DinoMenuItem> results = new();

            foreach (DinoMenuItem item in items)
            {
                if (types.Contains("Entrees") && Entrees.Contains(item))
                {
                    results.Add(item);
                }
                if (types.Contains("Sides") && Sides.Contains(item))
                {
                    results.Add(item);
                }
                if (types.Contains("Drinks") && Drinks.Contains(item))
                {
                    results.Add(item);
                }
            }
            return results;
        }

        /// <summary>
        /// Filters the search by price
        /// </summary>
        /// <param name="items">Previous search</param>
        /// <param name="min">Min price</param>
        /// <param name="max">Max price</param>
        /// <returns>Filtered list</returns>
        public static IEnumerable<DinoMenuItem> FilterByPrice(IEnumerable<DinoMenuItem> items, double? min, double? max)
        {

            //Both null case
            if (min == null && max == null) return items;

            List<DinoMenuItem> results = new();
            //Min Null Case
            if (min == null)
            {
                Decimal maxDecimal = Convert.ToDecimal(max);
                foreach(DinoMenuItem item in items)
                {
                    if (item.Price <= maxDecimal) results.Add(item);
                }
                return results;
            }
            //Max Null Case
            if (max == null)
            {
                Decimal minDecimal = Convert.ToDecimal(min);
                foreach (DinoMenuItem item in items)
                {
                    if (item.Price >= minDecimal) results.Add(item);
                }
                return results;
            }
            //Neither Null Case
            foreach(DinoMenuItem item in items)
            {
                Decimal maxDecimal = Convert.ToDecimal(max);
                Decimal minDecimal = Convert.ToDecimal(min);
                if (item.Price >= minDecimal && item.Price <= maxDecimal)
                {
                    results.Add(item);
                }
            }
            return results;
        }

        /// <summary>
        /// Filters the search by calories
        /// </summary>
        /// <param name="items">Previous Search</param>
        /// <param name="min">Min Calories</param>
        /// <param name="max">Max Calories</param>
        /// <returns>Filtered List</returns>
        public static IEnumerable<DinoMenuItem> FilterByCalories(IEnumerable<DinoMenuItem> items, double? min, double? max)
        {

            //Both null case
            if (min == null && max == null) return items;

            List<DinoMenuItem> results = new();
            //Min Null Case
            if (min == null)
            {
                foreach (DinoMenuItem item in items)
                {
                    if (item.Calories <= Convert.ToUInt32(max)) results.Add(item);
                }
                return results;
            }
            //Max Null Case
            if (max == null)
            {
                foreach (DinoMenuItem item in items)
                {
                    if (item.Calories >= Convert.ToUInt32(min)) results.Add(item);
                }
                return results;
            }
            //Neither Null Case
            foreach (DinoMenuItem item in items)
            {
                if (item.Calories >= Convert.ToUInt32(min) && item.Calories <= Convert.ToUInt32(max))
                {
                    results.Add(item);
                }
            }
            return results;
        }
    }
}
