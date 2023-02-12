using DinoDiner.Data;

namespace DataTest
{
    /// <summary>
    /// Unit Tests for VelociWraptor Class
    /// </summary>
    public class VelociWraptorUnitTests
    {
        /// <summary>
        /// Checks if VelociWraptor inherits from INotifyPropertyChanged
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void ShouldInheritFromINotifyPropertyChanged()
        {
            VelociWraptor wrap = new VelociWraptor();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(wrap);
        }

        /// <summary>
        /// Checks if changing cheese throws a property changed event
        /// </summary>
        /// <param name="cheese">cheese boolean</param>
        /// <param name="propertyName">property name</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true, "Calories")]
        [InlineData(true, "Cheese")]
        [InlineData(false, "Calories")]
        [InlineData(false, "Cheese")]
        public void ChangingCheeseShouldNotifyPropertyChanged(bool cheese, string propertyName)
        {
            VelociWraptor wrap = new VelociWraptor();
            Assert.PropertyChanged(wrap, propertyName, () => { wrap.Cheese = cheese; });
        }

        /// <summary>
        /// Checks if changing Dressing throws a property changed event
        /// </summary>
        /// <param name="dressing">dressing boolean</param>
        /// <param name="propertyName">property name</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true, "Calories")]
        [InlineData(true, "Dressing")]
        [InlineData(false, "Calories")]
        [InlineData(false, "Dressing")]
        public void ChangingDressingShouldNotifyPropertyChanged(bool dressing, string propertyName)
        {
            VelociWraptor wrap = new VelociWraptor();
            Assert.PropertyChanged(wrap, propertyName, () => { wrap.Dressing = dressing; });
        }

        /// <summary>
        /// Checks if name is always correct
        /// </summary>
        /// <param name="dressing">Bool if dressing</param>
        /// <param name="cheese">Bool if cheese</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void NameShouldBeCorrect(bool dressing, bool cheese)
        {
            VelociWraptor wrap = new VelociWraptor();
            wrap.Dressing = dressing;
            wrap.Cheese = cheese;
            Assert.Equal("Veloci-Wraptor", wrap.Name);
        }
        /// <summary>
        /// Checks if VelociWraptor Inherits from Entree
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void ShouldInheritFromMenuItem()
        {
            VelociWraptor wrap = new VelociWraptor();
            Assert.IsAssignableFrom<DinoMenuItem>(wrap);
        }

        /// <summary>
        /// Checks if price is always correct
        /// </summary>
        /// <param name="dressing">Bool if dressing</param>
        /// <param name="cheese">Bool if cheese</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void PriceShouldBeCorrect(bool dressing, bool cheese)
        {
            VelociWraptor wrap = new VelociWraptor();
            wrap.Dressing = dressing;
            wrap.Cheese = cheese;
            Assert.Equal(6.25m, wrap.Price);
        }
        /// <summary>
        /// Checks if calories are correct
        /// </summary>
        /// <param name="dressing">Bool if dressing</param>
        /// <param name="cheese">Bool if cheese</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void CaloriesShouldBeCorrect(bool dressing, bool cheese)
        {
            VelociWraptor wrap = new VelociWraptor();
            wrap.Dressing = dressing;
            wrap.Cheese = cheese;

            uint correctCalories = 732;
            if (!dressing) correctCalories -= 94;
            if (!cheese) correctCalories -= 22;

            Assert.Equal(correctCalories, wrap.Calories);
        }

        /// <summary>
        /// Dressing should default to true
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void DressingShouldDefaultToTrue()
        {
            VelociWraptor wrap = new VelociWraptor();
            Assert.True(wrap.Dressing);
        }

        /// <summary>
        /// Should be able to change the dressing
        /// </summary>
        /// <param name="dressing">Dressing Change</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetDressing(bool dressing)
        {
            VelociWraptor wrap = new VelociWraptor();
            wrap.Dressing = dressing;
            Assert.Equal(dressing, wrap.Dressing);
            wrap.Dressing = !dressing;
            Assert.Equal(!dressing, wrap.Dressing);
        }

        /// <summary>
        /// Cheese should default to true
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void CheeseShouldDefaultToTrue()
        {
            VelociWraptor wrap = new VelociWraptor();
            Assert.True(wrap.Cheese);
        }

        /// <summary>
        /// Should be able to change the cheese
        /// </summary>
        /// <param name="cheese">Cheese Change</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetCheese(bool cheese)
        {
            VelociWraptor wrap = new VelociWraptor();
            wrap.Cheese = cheese;
            Assert.Equal(cheese, wrap.Cheese);
            wrap.Cheese = !cheese;
            Assert.Equal(!cheese, wrap.Cheese);
        }
    }
}
