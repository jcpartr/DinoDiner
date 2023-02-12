using DinoDiner.Data;

namespace DataTest
{
    /// <summary>
    /// Unit tests for the Brontowurst class
    /// </summary>
    public class BrontowurstUnitTests
    {
        /// <summary>
        /// Checks if Brontowurst inherits from INotifyPropertyChanged
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void ShouldInheritFromINotifyPropertyChanged()
        {
            Brontowurst brontowurst = new Brontowurst();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(brontowurst);
        }

        /// <summary>
        /// Checks if changing Onions throws a property changed event
        /// </summary>
        /// <param name="onions">Onions if true</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true)]
        [InlineData(false)]
        public void ChangingOnionsShouldNotifyPropertyChanged(bool onions)
        {
            Brontowurst brontowurst = new Brontowurst();
            Assert.PropertyChanged(brontowurst, "Onions", () => { brontowurst.Onions = onions; });
        }

        /// <summary>
        /// Checks if changing peppers throws a property changed event
        /// </summary>
        /// <param name="peppers">Peppers if true</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true)]
        [InlineData(false)]
        public void ChangingPeppersShouldNotifyPropertyChanged(bool peppers)
        {
            Brontowurst brontowurst = new Brontowurst();
            Assert.PropertyChanged(brontowurst, "Peppers", () => { brontowurst.Peppers = peppers; });
        }

        /// <summary>
        /// Checks if Brontowurst is an entree
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void ShouldInheritFromMenuItem()
        {
            Brontowurst brontowurst = new Brontowurst();
            Assert.IsAssignableFrom<DinoMenuItem>(brontowurst);
        }

        /// <summary>
        /// Name is correct always
        /// </summary>
        /// <param name="onions">bool if onions</param>
        /// <param name="pepper">bool if pepper</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]

        public void NameShouldBeCorrect(bool onions, bool pepper)
        {
            Brontowurst brontowurst = new Brontowurst();
            brontowurst.Onions = onions;
            brontowurst.Peppers = pepper;
            Assert.Equal("Brontowurst", brontowurst.Name);
        }

        /// <summary>
        /// Price is correct always
        /// </summary>
        /// <param name="onions">bool if onions</param>
        /// <param name="pepper">bool if pepper</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]

        public void PriceShouldBeCorrect(bool onions, bool pepper)
        {
            Brontowurst brontowurst = new Brontowurst();
            brontowurst.Onions = onions;
            brontowurst.Peppers = pepper;
            Assert.Equal(5.86m, brontowurst.Price);
        }

        /// <summary>
        /// Calories is correct always
        /// </summary>
        /// <param name="onions">bool if onions</param>
        /// <param name="pepper">bool if pepper</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void CaloriesShouldBeCorrect(bool onions, bool pepper)
        {
            Brontowurst brontowurst = new Brontowurst();
            brontowurst.Onions = onions;
            brontowurst.Peppers = pepper;
            uint correctCalories = 512;
            Assert.Equal(correctCalories, brontowurst.Calories);
        }
        /// <summary>
        /// Onions default to true
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void OnionsShouldDefaultToTrue()
        {
            Brontowurst brontowurst = new Brontowurst();
            Assert.True(brontowurst.Onions);
        }
        /// <summary>
        /// Checks if able to set onions
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void ShouldBeAbleToSetOnions()
        {
            Brontowurst brontowurst = new Brontowurst();
            Assert.True(brontowurst.Onions);
            brontowurst.Onions = false;
            Assert.False(brontowurst.Onions);
        }

        /// <summary>
        /// Pepeprs default to true
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void PeppersShouldDefaultToTrue()
        {
            Brontowurst brontowurst = new Brontowurst();
            Assert.True(brontowurst.Peppers);
        }
        /// <summary>
        /// Checks if able to set peppers
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void ShouldBeAbleToSetPeppers()
        {
            Brontowurst brontowurst = new Brontowurst();
            Assert.True(brontowurst.Peppers);
            brontowurst.Peppers = false;
            Assert.False(brontowurst.Peppers);
        }

    }
}
