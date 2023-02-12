using DinoDiner.Data;

namespace DataTest
{
    /// <summary>
    /// Unit Tests for the MeteorMacAndCheese class
    /// </summary>
    public class MeteorMacAndCheeseUnitTests
    {
        /// <summary>
        /// Checks if MeteorMacAndCheese is inheriting from INotifyPropertyChanged
        /// </summary>
        [Fact]
        [Trait("Side", "")]
        public void ShouldInheritFromINotifyPropertyChanged()
        {
            MeteorMacAndCheese mac = new MeteorMacAndCheese();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(mac);
        }

        /// <summary>
        /// Tests if changing Size gives the appropriate events
        /// </summary>
        /// <param name="size">ServingSize</param>
        /// <param name="propertyName">Property Name String</param>
        [Theory]
        [Trait("Side", "")]
        [InlineData(ServingSize.Small, "Size")]
        [InlineData(ServingSize.Small, "Calories")]
        [InlineData(ServingSize.Small, "Price")]
        [InlineData(ServingSize.Small, "Name")]

        [InlineData(ServingSize.Medium, "Size")]
        [InlineData(ServingSize.Medium, "Calories")]
        [InlineData(ServingSize.Medium, "Price")]
        [InlineData(ServingSize.Medium, "Name")]

        [InlineData(ServingSize.Large, "Size")]
        [InlineData(ServingSize.Large, "Calories")]
        [InlineData(ServingSize.Large, "Price")]
        [InlineData(ServingSize.Large, "Name")]
        public void ChangingSizeShouldNotifyPropertyChanged(ServingSize size, string propertyName)
        {
            MeteorMacAndCheese mac = new MeteorMacAndCheese();
            Assert.PropertyChanged(mac, propertyName, () => { mac.Size = size; });

        }

        /// <summary>
        /// Checks if MeteorMacAndCheese inherits from Side
        /// </summary>
        [Fact]
        [Trait("Side", "")]
        public void ShouldInheritFromMenuItem()
        {
            MeteorMacAndCheese mac = new MeteorMacAndCheese();
            Assert.IsAssignableFrom<DinoMenuItem>(mac);
        }

        /// <summary>
        /// Checks if the name is correct
        /// </summary>
        /// <param name="servingSize">Serving Size Enum</param>
        [Theory]
        [Trait("Side", "")]
        [InlineData(ServingSize.Small)]
        [InlineData(ServingSize.Medium)]
        [InlineData(ServingSize.Large)]
        public void NameShouldBeCorrect(ServingSize servingSize)
        {
            MeteorMacAndCheese mac = new MeteorMacAndCheese();
            mac.Size = servingSize;
            if (servingSize == ServingSize.Small)
            {
                Assert.Equal("Small Meteor Mac & Cheese", mac.Name);
            }
            else if (servingSize == ServingSize.Medium)
            {
                Assert.Equal("Medium Meteor Mac & Cheese", mac.Name);
            }
            else if (servingSize == ServingSize.Large)
            {
                Assert.Equal("Large Meteor Mac & Cheese", mac.Name);
            }
        }

        /// <summary>
        /// Checks if the price is correct
        /// </summary>
        /// <param name="servingSize">Serving Size Enum</param>
        [Theory]
        [Trait("Side", "")]
        [InlineData(ServingSize.Small)]
        [InlineData(ServingSize.Medium)]
        [InlineData(ServingSize.Large)]
        public void PriceShouldBeCorrect(ServingSize servingSize)
        {
            MeteorMacAndCheese mac = new MeteorMacAndCheese();
            mac.Size = servingSize;
            if (servingSize == ServingSize.Small)
            {
                Assert.Equal(3.50m, mac.Price);
            }
            else if (servingSize == ServingSize.Medium)
            {
                Assert.Equal(4.00m, mac.Price);
            }
            else if (servingSize == ServingSize.Large)
            {
                Assert.Equal(5.25m, mac.Price);
            }
        }

        /// <summary>
        /// Checks if the price is correct
        /// </summary>
        /// <param name="servingSize">Serving Size Enum</param>
        /// <param name="sauce">Bool if sauce</param>
        [Theory]
        [Trait("Side", "")]
        [InlineData(ServingSize.Small, true)]
        [InlineData(ServingSize.Medium, true)]
        [InlineData(ServingSize.Large, true)]
        public void CaloriesShouldBeCorrect(ServingSize servingSize, bool sauce)
        {
            MeteorMacAndCheese mac = new MeteorMacAndCheese();
            mac.Size = servingSize;
            uint calories = 0;
            if (servingSize == ServingSize.Small)
            {
                calories = 425;
            }
            else if (servingSize == ServingSize.Medium)
            {
                calories = 510;
            }
            else if (servingSize == ServingSize.Large)
            {
                calories = 700;
            }
            Assert.Equal(calories, mac.Calories);
        }

        /// <summary>
        /// Checks if size can be changed
        /// </summary>
        /// <param name="size">Size of Side</param>
        [Theory]
        [Trait("Side", "")]
        [InlineData(ServingSize.Small)]
        [InlineData(ServingSize.Medium)]
        [InlineData(ServingSize.Large)]
        public void ShouldBeAbleToSetSize(ServingSize size)
        {
            MeteorMacAndCheese mac = new MeteorMacAndCheese();
            mac.Size = size;
            Assert.Equal(size, mac.Size);
        }
    }
}
