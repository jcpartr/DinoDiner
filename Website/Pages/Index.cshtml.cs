using DinoDiner.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    /// <summary>
    /// Page Backend for Index
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Contains all the menu items found in the search
        /// </summary>
        public Dictionary<string, IEnumerable<DinoMenuItem>> MenuItems { get; set; }

        /// <summary>
        /// The menu item types to search for
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string[] MenuItemTypes { get; set; }

        /// <summary>
        /// The terms to search for
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string? SearchTerms { get; set; }

        /// <summary>
        /// Minumum Price to search for
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public double? PriceMin { get; set; }

        /// <summary>
        /// Maximum Price to search for
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public double? PriceMax { get; set; }

        /// <summary>
        /// Minumum Calories to search for
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMin { get; set; }

        /// <summary>
        /// Maximum Calories to search for
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMax { get; set; }

        /// <summary>
        /// Searches the menu by the criteria
        /// </summary>
        public void OnGet()
        {
            MenuItems = Menu.Search(SearchTerms, MenuItemTypes, PriceMin, PriceMax, CaloriesMin, CaloriesMax);
        }
    }
}