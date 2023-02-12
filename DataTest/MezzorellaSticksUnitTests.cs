using DinoDiner.Data;

namespace DataTest
{
    /// <summary>
    /// Unit Tests for the MezzoreallaSticks class
    /// </summary>
    public class MezzoreallaSticksUnitTests
    {

        /// <summary>
        /// Checks if MezzoreallaSticks is inheriting from INotifyPropertyChanged
        /// </summary>
        [Fact]
        [Trait("Side", "")]
        public void ShouldInheritFromINotifyPropertyChanged()
        {
            MezzorellaSticks sticks = new MezzorellaSticks();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(sticks);
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
            MezzorellaSticks sticks = new MezzorellaSticks();
            Assert.PropertyChanged(sticks, propertyName, () => { sticks.Size = size; });

        }


        /// <summary>
        /// Checks if MezzoreallaSticks inherits from Side
        /// </summary>
        [Fact]
        [Trait("Side", "")]
        public void ShouldInheritFromMenuItem()
        {
            MezzorellaSticks sticks = new MezzorellaSticks();
            Assert.IsAssignableFrom<DinoMenuItem>(sticks);
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
            MezzorellaSticks sticks = new MezzorellaSticks();
            sticks.Size = servingSize;
            if (servingSize == ServingSize.Small)
            {
                Assert.Equal("Small Mezzorella Sticks", sticks.Name);
            }
            else if (servingSize == ServingSize.Medium)
            {
                Assert.Equal("Medium Mezzorella Sticks", sticks.Name);
            }
            else if (servingSize == ServingSize.Large)
            {
                Assert.Equal("Large Mezzorella Sticks", sticks.Name);
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
            MezzorellaSticks sticks = new MezzorellaSticks();
            sticks.Size = servingSize;
            if (servingSize == ServingSize.Small)
            {
                Assert.Equal(3.50m, sticks.Price);
            }
            else if (servingSize == ServingSize.Medium)
            {
                Assert.Equal(4.00m, sticks.Price);
            }
            else if (servingSize == ServingSize.Large)
            {
                Assert.Equal(5.25m, sticks.Price);
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
            MezzorellaSticks sticks = new MezzorellaSticks();
            sticks.Size = servingSize;
            uint calories = 0;
            if (servingSize == ServingSize.Small)
            {
                calories = 530;
            }
            else if (servingSize == ServingSize.Medium)
            {
                calories = 620;
            }
            else if (servingSize == ServingSize.Large)
            {
                calories = 730;
            }
            Assert.Equal(calories, sticks.Calories);
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
            MezzorellaSticks sticks = new MezzorellaSticks();
            sticks.Size = size;
            Assert.Equal(size, sticks.Size);
        }
    }
}
