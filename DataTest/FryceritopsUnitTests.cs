using DinoDiner.Data;

namespace DataTest
{
    /// <summary>
    /// Unit Tests for Fryceritops class
    /// </summary>
    public class FryceritopsUnitTests
    {
        /// <summary>
        /// Checks if Fryceritops is inheriting from INotifyPropertyChanged
        /// </summary>
        [Fact]
        [Trait("Side", "")]
        public void ShouldInheritFromINotifyPropertyChanged()
        {
            Fryceritops fries = new Fryceritops();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(fries);
        }

        /// <summary>
        /// Tests if changing salt gives the appropriate events
        /// </summary>
        /// <param name="salt">Salt boolean</param>
        /// <param name="propertyName">Name of the property</param>
        [Theory]
        [Trait("Side", "")]
        [InlineData(true, "Salt")]
        [InlineData(false, "Salt")]
        public void ChangingSaltShouldNotifyPropertyChanged(bool salt, string propertyName)
        {
            Fryceritops fries = new Fryceritops();
            Assert.PropertyChanged(fries, propertyName, () => { fries.Salt = salt; });
        }

        /// <summary>
        /// Tests if changing Sauce gives the appropriate events
        /// </summary>
        /// <param name="sauce">Sauce bool</param>
        /// <param name="propertyName">name of the property</param>
        [Theory]
        [Trait("Side", "")]
        [InlineData(true, "Sauce")]
        [InlineData(false, "Sauce")]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        public void ChangingSauceShouldNotifyPropertyChanged(bool sauce, string propertyName)
        {
            Fryceritops fries = new Fryceritops();
            Assert.PropertyChanged(fries, propertyName, () => { fries.Sauce = sauce; });
        }

        /// <summary>
        /// Tests if changing Size gives the appropriate events
        /// </summary>
        /// <param name="size">ServingSize</param>
        /// <param name="propertyName">name of the property</param>
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
            Fryceritops fries = new Fryceritops();
            Assert.PropertyChanged(fries, propertyName, () => { fries.Size = size; });
        }
        /// <summary>
        /// Tests if Fryceitops inherits from Sides
        /// </summary>
        [Fact]
        [Trait("Side", "")]
        public void ShouldInheritFromMenuItem()
        {
            Fryceritops fries = new Fryceritops();
            Assert.IsAssignableFrom<DinoMenuItem>(fries);
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
            Fryceritops fries = new Fryceritops();
            fries.Size = servingSize;
            if (servingSize == ServingSize.Small)
            {
                Assert.Equal("Small Fryceritops", fries.Name);
            }
            else if (servingSize == ServingSize.Medium)
            {
                Assert.Equal("Medium Fryceritops", fries.Name);
            }
            else if (servingSize == ServingSize.Large)
            {
                Assert.Equal("Large Fryceritops", fries.Name);
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
            Fryceritops fries = new Fryceritops();
            fries.Size = servingSize;
            if (servingSize == ServingSize.Small)
            {
                Assert.Equal(3.50m, fries.Price);
            }
            else if (servingSize == ServingSize.Medium)
            {
                Assert.Equal(4.00m, fries.Price);
            }
            else if (servingSize == ServingSize.Large)
            {
                Assert.Equal(5.00m, fries.Price);
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
            Fryceritops fries = new Fryceritops();
            fries.Size = servingSize;
            fries.Sauce = sauce;
            uint calories = 0;
            if (servingSize == ServingSize.Small)
            {
                calories = 365;
            }
            else if (servingSize == ServingSize.Medium)
            {
                calories = 465;
            }
            else if (servingSize == ServingSize.Large)
            {
                calories = 510;
            }
            if (sauce) calories += 80;
            Assert.Equal(calories, fries.Calories);
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
            Fryceritops fries = new Fryceritops();
            fries.Size = size;
            Assert.Equal(size, fries.Size);
        }

        /// <summary>
        /// Checks if salt is default true
        /// </summary>
        [Fact]
        [Trait("Side", "")]
        public void SaltShouldDefaultToTrue()
        {
            Fryceritops fries = new Fryceritops();
            Assert.True(fries.Salt);
        }
        /// <summary>
        /// Checks if salt can be set and changed
        /// </summary>
        /// <param name="included">Boolean Testing Parameter</param>
        [Theory]
        [Trait("Side", "")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetSalt(bool included)
        {
            Fryceritops fries = new Fryceritops();
            fries.Salt = included;
            Assert.Equal(included, fries.Salt);
            fries.Salt = !included;
            Assert.Equal(!included, fries.Salt);
        }

        /// <summary>
        /// Checks if sauce is default false
        /// </summary>
        [Fact]
        [Trait("Side", "")]
        public void SauceShouldDefaultToFalse()
        {
            Fryceritops fries = new Fryceritops();
            Assert.False(fries.Sauce);
        }
        /// <summary>
        /// Checks if sauce can be set and changed
        /// </summary>
        /// <param name="included">Boolean Testing Parameter</param>
        [Theory]
        [Trait("Side", "")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetSauce(bool included)
        {
            Fryceritops fries = new Fryceritops();
            fries.Sauce = included;
            Assert.Equal(included, fries.Sauce);
            fries.Sauce = !included;
            Assert.Equal(!included, fries.Sauce);
        }

    }
}
