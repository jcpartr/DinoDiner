using DinoDiner.Data;

namespace DataTest
{
    /// <summary>
    /// Unit Tests for the DinoNuggets Class
    /// </summary>
    public class DinoNuggetsUnitTests
    {
        /// <summary>
        /// Checks if DinoNuggets is inheriting from INotifyPropertyChanged
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void ShouldInheritFromINotifyPropertyChanged()
        {
            DinoNuggets nuggets = new DinoNuggets();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(nuggets);
        }

        /// <summary>
        /// Checks if changing count notifies a property changed
        /// </summary>
        /// <param name="count">Count of nuggets</param>
        /// <param name="propertyName">Property being changed</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(1, "Price")]
        [InlineData(1, "Calories")]
        [InlineData(1, "Name")]
        [InlineData(1, "Count")]
        [InlineData(4, "Price")]
        [InlineData(4, "Calories")]
        [InlineData(4, "Name")]
        [InlineData(4, "Count")]
        [InlineData(14, "Price")]
        [InlineData(14, "Calories")]
        [InlineData(14, "Name")]
        [InlineData(14, "Count")]
        public void ChangingCountShouldNotifyPropertyChanged(uint count, string propertyName)
        {
            DinoNuggets nuggets = new DinoNuggets();
            Assert.PropertyChanged(nuggets, propertyName, () => { nuggets.Count = count; });
        }

        /// <summary>
        /// Checks if DinoNuggets is an entree
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void ShouldInheritFromMenuItem()
        {
            DinoNuggets nuggets = new DinoNuggets();
            Assert.IsAssignableFrom<DinoMenuItem>(nuggets);
        }

        /// <summary>
        /// Checks if the name is correct
        /// </summary>
        /// <param name="count">Number of Nuggets to be changed</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        public void NameShouldBeCorrect(uint count)
        {
            DinoNuggets nuggets = new DinoNuggets();
            nuggets.Count = count;
            string str = " Dino Nuggets";
            Assert.Equal(count + str, nuggets.Name);
        }

        /// <summary>
        /// Checks if the price is correct
        /// </summary>
        /// <param name="count">Number of Nuggets to be changed</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        public void PriceShouldBeCorrect(uint count)
        {
            DinoNuggets nuggets = new DinoNuggets();
            nuggets.Count = count;
            Assert.Equal(.25m * count, nuggets.Price);
        }

        /// <summary>
        /// Checks if the calories are correct
        /// </summary>
        /// <param name="count">Number of Nuggets to be changed</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        public void CaloriesShouldBeCorrect(uint count)
        {
            DinoNuggets nuggets = new DinoNuggets();
            nuggets.Count = count;
            Assert.Equal(61 * count, nuggets.Calories);
        }

        /// <summary>
        /// Checks if count is defaulted to 6
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void CountShouldDefaulToSix()
        {
            DinoNuggets nuggets = new DinoNuggets();
            Assert.Equal((uint)6, nuggets.Count);
        }

        /// <summary>
        /// Checks if able to set Count
        /// </summary>
        /// <param name="count">Number of Nuggets to be changed</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        public void ShouldBeAbleToSetCount(uint count)
        {
            DinoNuggets nuggets = new DinoNuggets();
            nuggets.Count = count;
            Assert.Equal(count, nuggets.Count);
        }

    }
}
