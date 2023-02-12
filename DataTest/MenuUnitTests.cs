using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinoDiner.Data;

namespace DataTest
{
    /// <summary>
    /// Unit Tests for the Menu Class
    /// </summary>
    public class MenuUnitTests
    {
        /// <summary>
        /// Checks if Entrees has the correct number of items
        /// </summary>
        [Fact]
        [Trait("Menu","")]
        public void EntreesShouldHaveNineItems()
        {
            Assert.Equal(9, Menu.Entrees.Count());
        }

        /// <summary>
        /// Checks if Sides has the correct number of items
        /// </summary>
        [Fact]
        [Trait("Menu", "")]
        public void SidesShouldHaveTwelveItems()
        {
            Assert.Equal(12, Menu.Sides.Count());
        }

        /// <summary>
        /// Checks if Drinks has the correct number of items
        /// </summary>
        [Fact]
        [Trait("Menu", "")]
        public void DrinksShouldHaveSixItems()
        {
            Assert.Equal(6, Menu.Drinks.Count());
        }

        /// <summary>
        /// Checks if FullMenu has the correct number of items
        /// </summary>
        [Fact]
        [Trait("Menu", "")]
        public void FullMenuShouldHaveTwentySevenItems()
        {
            Assert.Equal(27, Menu.FullMenu.Count());
        }
    }
}
