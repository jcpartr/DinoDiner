using DinoDiner.Data;

namespace DataTest
{
    /// <summary>
    /// Unit Tests for the Pterodactyl Wings Class
    /// </summary>
    public class PterodactylWingsUnitTests
    {
        /// <summary>
        /// Checks if Brontowurst inherits from INotifyPropertyChanged
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void ShouldInheritFromINotifyPropertyChanged()
        {
            PterodactylWings wings = new PterodactylWings();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(wings);
        }

        /// <summary>
        /// Tests if changing sauce notifies a property change
        /// </summary>
        /// <param name="sauce">sauce boolean</param>
        /// <param name="propertyName">name of property changing</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(WingSauce.Buffalo, "Sauce")]
        [InlineData(WingSauce.Buffalo, "Calories")]
        [InlineData(WingSauce.Buffalo, "Name")]
        [InlineData(WingSauce.Teriyaki, "Sauce")]
        [InlineData(WingSauce.Teriyaki, "Calories")]
        [InlineData(WingSauce.Teriyaki, "Name")]
        [InlineData(WingSauce.HoneyGlaze, "Sauce")]
        [InlineData(WingSauce.HoneyGlaze, "Calories")]
        [InlineData(WingSauce.HoneyGlaze, "Name")]
        public void ChangingSauceShouldNotifyPropertyChanged(WingSauce sauce, string propertyName)
        {
            PterodactylWings wings = new PterodactylWings();
            Assert.PropertyChanged(wings, propertyName, () => { wings.Sauce = sauce; });

        }
        /// <summary>
        /// Checks if PterodactylWings is an entree
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void ShouldInheritFromMenuItem()
        {
            PterodactylWings wings = new PterodactylWings();
            Assert.IsAssignableFrom<DinoMenuItem>(wings);
        }

        /// <summary>
        /// Checks the name of the wings
        /// </summary>
        /// <param name="sauce">Sauce on the wings</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(WingSauce.Buffalo)]
        [InlineData(WingSauce.Teriyaki)]
        [InlineData(WingSauce.HoneyGlaze)]
        public void NameShouldBeCorrect(WingSauce sauce)
        {
            PterodactylWings wings = new PterodactylWings();
            wings.Sauce = sauce;

            if (sauce == WingSauce.Buffalo)
            {
                Assert.Equal("Buffalo Pterodactyl Wings", wings.Name);
            }
            else if (sauce == WingSauce.Teriyaki)
            {
                Assert.Equal("Teriyaki Pterodactyl Wings", wings.Name);
            }
            else if (sauce == WingSauce.HoneyGlaze)
            {
                Assert.Equal("Honey Glaze Pterodactyl Wings", wings.Name);
            }
        }
        /// <summary>
        /// Checks the price
        /// </summary>
        /// <param name="sauce">Sauce on the wings</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(WingSauce.Buffalo)]
        [InlineData(WingSauce.Teriyaki)]
        [InlineData(WingSauce.HoneyGlaze)]
        public void PriceShouldBeCorrect(WingSauce sauce)
        {
            PterodactylWings wings = new PterodactylWings();
            Assert.Equal(8.95m, wings.Price);
            wings.Sauce = sauce;
            Assert.Equal(8.95m, wings.Price);
        }

        /// <summary>
        /// Checks if the calories is right depending on sauce
        /// </summary>
        /// <param name="sauce">Sauce on the wingss</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(WingSauce.Buffalo)]
        [InlineData(WingSauce.Teriyaki)]
        [InlineData(WingSauce.HoneyGlaze)]
        public void CaloriesShouldBeCorrect(WingSauce sauce)
        {
            PterodactylWings wings = new PterodactylWings();
            wings.Sauce = sauce;

            if (sauce == WingSauce.Buffalo)
            {
                Assert.Equal((uint)360, wings.Calories);
            }
            else if (sauce == WingSauce.Teriyaki)
            {
                Assert.Equal((uint)342, wings.Calories);
            }
            else if (sauce == WingSauce.HoneyGlaze)
            {
                Assert.Equal((uint)359, wings.Calories);
            }
        }

        /// <summary>
        /// Sauce should default to WingSauce.Buffalo
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void SauceShouldDefaultToBuffalo()
        {
            PterodactylWings wings = new PterodactylWings();
            Assert.Equal(WingSauce.Buffalo, wings.Sauce);
        }
        /// <summary>
        /// Checks the ability to change sauces
        /// </summary>
        /// <param name="sauce">Sauce to be changed to</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(WingSauce.Buffalo)]
        [InlineData(WingSauce.Teriyaki)]
        [InlineData(WingSauce.HoneyGlaze)]
        public void ShouldBeAbleToSetSauce(WingSauce sauce)
        {
            PterodactylWings wings = new PterodactylWings();
            Assert.Equal(WingSauce.Buffalo, wings.Sauce);
            wings.Sauce = sauce;
            Assert.Equal(sauce, wings.Sauce);
        }
    }
}
