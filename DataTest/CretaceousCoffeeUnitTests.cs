using DinoDiner.Data;

namespace DataTest
{
    /// <summary>
    /// Unit Tests for CretaceousCoffee Class
    /// </summary>
    public class CretaceousCoffeeUnitTests
    {
        /// <summary>
        /// Checks if CretaceousCoffee is inheriting from INotifyPropertyChanged
        /// </summary>
        [Fact]
        [Trait("Drink", "")]
        public void ShouldInheritFromINotifyPropertyChanged()
        {
            CretaceousCoffee coffee = new CretaceousCoffee();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(coffee);
        }

        /// <summary>
        /// Tests if changing size throws the correct property changed events
        /// </summary>
        /// <param name="size">ServingSize</param>
        /// <param name="propertyName">Property Name</param>
        [Theory]
        [Trait("Drink", "")]
        [InlineData(ServingSize.Small, "Size")]
        [InlineData(ServingSize.Small, "Price")]
        [InlineData(ServingSize.Small, "Name")]

        [InlineData(ServingSize.Medium, "Size")]
        [InlineData(ServingSize.Medium, "Price")]
        [InlineData(ServingSize.Medium, "Name")]

        [InlineData(ServingSize.Large, "Size")]
        [InlineData(ServingSize.Large, "Price")]
        [InlineData(ServingSize.Large, "Name")]
        public void ChangingSizeShouldNotifyPropertyChanged(ServingSize size, string propertyName)
        {
            CretaceousCoffee coffee = new CretaceousCoffee();
            Assert.PropertyChanged(coffee, propertyName, () => { coffee.Size = size; });
        }

        /// <summary>
        /// Tests if changing Cream throws the correct property changed events
        /// </summary>
        /// <param name="cream">Cream bool</param>
        /// <param name="propertyName">propertyName string</param>
        [Theory]
        [Trait("Drink", "")]
        [InlineData(true, "Cream")]
        [InlineData(false, "Cream")]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        public void ChangingCreamShouldNotifyPropertyChanged(bool cream, string propertyName)
        {
            CretaceousCoffee coffee = new CretaceousCoffee();
            Assert.PropertyChanged(coffee, propertyName, () => { coffee.Cream = cream; });

        }

        /// <summary>
        /// Tests if CretaceousCoffee inherits from Sides
        /// </summary>
        [Fact]
        [Trait("Drink", "")]
        public void ShouldInheritFromMenuItem()
        {
            CretaceousCoffee coffee = new CretaceousCoffee();
            Assert.IsAssignableFrom<DinoMenuItem>(coffee);
        }
        /// <summary>
        /// Tests if the name is correct
        /// </summary>
        /// <param name="size">Size of the drink</param>
        [Theory]
        [Trait("Drink", "")]
        [InlineData(ServingSize.Small)]
        [InlineData(ServingSize.Medium)]
        [InlineData(ServingSize.Large)]
        public void NameShouldBeCorrect(ServingSize size)
        {
            CretaceousCoffee coffee = new CretaceousCoffee();
            coffee.Size = size;
            if (size == ServingSize.Small) Assert.Equal("Small Cretaceous Coffee", coffee.Name);
            if (size == ServingSize.Medium) Assert.Equal("Medium Cretaceous Coffee", coffee.Name);
            if (size == ServingSize.Large) Assert.Equal("Large Cretaceous Coffee", coffee.Name);
        }
        /// <summary>
        /// Tests if the price is correct
        /// </summary>
        /// <param name="size">Size of the drink</param>
        [Theory]
        [Trait("Drink", "")]
        [InlineData(ServingSize.Small)]
        [InlineData(ServingSize.Medium)]
        [InlineData(ServingSize.Large)]
        public void PriceShouldBeCorrect(ServingSize size)
        {
            CretaceousCoffee coffee = new CretaceousCoffee();
            coffee.Size = size;
            if (size == ServingSize.Small) Assert.Equal(.75m, coffee.Price);
            if (size == ServingSize.Medium) Assert.Equal(1.25m, coffee.Price);
            if (size == ServingSize.Large) Assert.Equal(2.00m, coffee.Price);
        }

        /// <summary>
        /// Tests if the calories are correct
        /// </summary>
        /// <param name="size">Size of the drink</param>
        /// <param name="cream">bool if cream</param>
        [Theory]
        [Trait("Drink", "")]
        [InlineData(ServingSize.Small, true)]
        [InlineData(ServingSize.Medium, true)]
        [InlineData(ServingSize.Large, true)]
        [InlineData(ServingSize.Small, false)]
        [InlineData(ServingSize.Medium, false)]
        [InlineData(ServingSize.Large, false)]
        public void CaloriesShouldBeCorrect(ServingSize size, bool cream)
        {
            CretaceousCoffee coffee = new CretaceousCoffee();
            coffee.Size = size;
            coffee.Cream = cream;
            uint calories = 0;
            if (cream) calories = 64;
            Assert.Equal(calories, coffee.Calories);
        }

        /// <summary>
        /// Checks if size can be set
        /// </summary>
        /// <param name="size">Size of the drink</param>
        [Theory]
        [Trait("Drink", "")]
        [InlineData(ServingSize.Small)]
        [InlineData(ServingSize.Medium)]
        [InlineData(ServingSize.Large)]
        public void ShouldBeAbleToSetSize(ServingSize size)
        {
            CretaceousCoffee coffee = new CretaceousCoffee();
            coffee.Size = size;
            Assert.Equal(size, coffee.Size);
        }

        /// <summary>
        /// Tests if cream can be set and changed
        /// </summary>
        /// <param name="cream">Bool if cream</param>
        [Theory]
        [Trait("Drink", "")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetCream(bool cream)
        {
            CretaceousCoffee coffee = new CretaceousCoffee();
            coffee.Cream = cream;
            Assert.Equal(cream, coffee.Cream);
            coffee.Cream = !cream;
            Assert.Equal(!cream, coffee.Cream);
        }
        /// <summary>
        /// Tests if cream is defaulted to false
        /// </summary>
        [Fact]
        [Trait("Drink", "")]
        public void CreamShouldDefaultToFalse()
        {
            CretaceousCoffee coffee = new CretaceousCoffee();
            Assert.False(coffee.Cream);
        }
    }
}
