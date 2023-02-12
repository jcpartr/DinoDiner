using DinoDiner.Data;

namespace DataTest
{
    /// <summary>
    /// Unit Tests for the Triceritots class
    /// </summary>
    public class TriceritotsUnitTests
    {
        /// <summary>
        /// Checks if Triceritots is inheriting from INotifyPropertyChanged
        /// </summary>
        [Fact]
        [Trait("Side", "")]
        public void ShouldInheritFromINotifyPropertyChanged()
        {
            Triceritots tots = new Triceritots();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(tots);
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
            Triceritots tots = new Triceritots();
            Assert.PropertyChanged(tots, propertyName, () => { tots.Size = size; });

        }

        /// <summary>
        /// Checks if Triceritots inherits from Side
        /// </summary>
        [Fact]
        [Trait("Side", "")]
        public void ShouldInheritFromMenuItem()
        {
            Triceritots tots = new Triceritots();
            Assert.IsAssignableFrom<DinoMenuItem>(tots);
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
            Triceritots tots = new Triceritots();
            tots.Size = servingSize;
            if (servingSize == ServingSize.Small)
            {
                Assert.Equal("Small Triceritots", tots.Name);
            }
            else if (servingSize == ServingSize.Medium)
            {
                Assert.Equal("Medium Triceritots", tots.Name);
            }
            else if (servingSize == ServingSize.Large)
            {
                Assert.Equal("Large Triceritots", tots.Name);
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
            Triceritots tots = new Triceritots();
            tots.Size = servingSize;
            if (servingSize == ServingSize.Small)
            {
                Assert.Equal(3.50m, tots.Price);
            }
            else if (servingSize == ServingSize.Medium)
            {
                Assert.Equal(4.00m, tots.Price);
            }
            else if (servingSize == ServingSize.Large)
            {
                Assert.Equal(5.25m, tots.Price);
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
            Triceritots tots = new Triceritots();
            tots.Size = servingSize;
            uint calories = 0;
            if (servingSize == ServingSize.Small)
            {
                calories = 351;
            }
            else if (servingSize == ServingSize.Medium)
            {
                calories = 409;
            }
            else if (servingSize == ServingSize.Large)
            {
                calories = 583;
            }
            Assert.Equal(calories, tots.Calories);
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
            Triceritots tots = new Triceritots();
            tots.Size = size;
            Assert.Equal(size, tots.Size);
        }
    }
}
