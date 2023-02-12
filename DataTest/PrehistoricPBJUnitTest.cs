using DinoDiner.Data;

namespace DataTest
{
    /// <summary>
    /// Unit tests for the PrehistoricPBJ Class
    /// </summary>
    public class PrehistoricPBJUnitTest
    {
        /// <summary>
        /// Checks if PrehistoricPBJ inherits from INotifyPropertyChanged
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void ShouldInheritFromINotifyPropertyChanged()
        {
            PrehistoricPBJ pbj = new PrehistoricPBJ();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(pbj);
        }

        /// <summary>
        /// Tests if changing Jelly notifies a property changed
        /// </summary>
        /// <param name="jelly">jelly boolean</param>
        /// <param name="propertyName">name of the property</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true, "Calories")]
        [InlineData(true, "Jelly")]
        [InlineData(false, "Calories")]
        [InlineData(false, "Jelly")]
        public void ChangingJellyShouldNotifyPropertyChanged(bool jelly, string propertyName)
        {
            PrehistoricPBJ pbj = new PrehistoricPBJ();
            Assert.PropertyChanged(pbj, propertyName, () => { pbj.Jelly = jelly; });
        }

        /// <summary>
        /// Tests if changing PeanutButter notifies a property changed
        /// </summary>
        /// <param name="peanutbutter">Peanutbutter</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true, "Calories")]
        [InlineData(true, "PeanutButter")]
        [InlineData(false, "Calories")]
        [InlineData(false, "PeanutButter")]
        public void ChangingPeanutButterShouldNotifyPropertyChanged(bool peanutbutter, string propertyName)
        {
            PrehistoricPBJ pbj = new PrehistoricPBJ();
            Assert.PropertyChanged(pbj, propertyName, () => { pbj.PeanutButter = peanutbutter; });
        }

        /// <summary>
        /// Tests if changing Toasted notifies a property changed
        /// </summary>
        /// <param name="toasted">toasted boolean</param>
        /// <param name="propertyName">property to be changed</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true, "Toasted")]
        [InlineData(false, "Toasted")]
        public void ChangingToastedShouldNotifyPropertyChanged(bool toasted, string propertyName)
        {
            PrehistoricPBJ pbj = new PrehistoricPBJ();
            Assert.PropertyChanged(pbj, propertyName, () => { pbj.Toasted = toasted; });
        }

        /// <summary>
        /// Tests to see if the name is always Prehistoric PBJ
        /// </summary>
        /// <param name="peanutbutter">Bool if peanut butter</param>
        /// <param name="jelly">bool if jelly</param>
        /// <param name="toasted">bool if toasted</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true, true, true)]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(false, true, true)]
        [InlineData(false, false, true)]
        [InlineData(true, false, false)]
        [InlineData(false, false, false)]
        public void NameShouldBeCorrect(bool peanutbutter, bool jelly, bool toasted)
        {
            PrehistoricPBJ pbj = new PrehistoricPBJ();
            pbj.PeanutButter = peanutbutter;
            pbj.Jelly = jelly;
            pbj.Toasted = toasted;
            Assert.Equal("Prehistoric PBJ", pbj.Name);
        }

        /// <summary>
        /// PBJ should inherit from the entree class
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void PrehistoricPBJShouldInheritFromMenuItem()
        {
            PrehistoricPBJ pbj = new PrehistoricPBJ();
            Assert.IsAssignableFrom<DinoMenuItem>(pbj);

        }

        /// <summary>
        /// PeanutButter should default to true
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void PeanutButterShouldDefaultToTrue()
        {
            PrehistoricPBJ pbj = new();
            Assert.True(pbj.PeanutButter);
        }

        /// <summary>
        /// Should be able to set PeanutButter to
        /// true or false
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void ShouldBeAbleToSetPeanutButter()
        {
            PrehistoricPBJ pbj = new();
            pbj.PeanutButter = false;
            Assert.False(pbj.PeanutButter);
            pbj.PeanutButter = true;
            Assert.True(pbj.PeanutButter);
        }

        /// <summary>
        /// Jelly should default to true
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void JellyShouldDefaultToTrue()
        {
            PrehistoricPBJ pbj = new();
            Assert.True(pbj.Jelly);
        }

        /// <summary>
        /// Should be able to set Jelly to
        /// true or false
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void ShouldBeAbleToSetJelly()
        {
            PrehistoricPBJ pbj = new();
            pbj.PeanutButter = false;
            Assert.False(pbj.PeanutButter);
            pbj.PeanutButter = true;
            Assert.True(pbj.PeanutButter);
        }

        /// <summary>
        /// Toasted should default to true
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void ToastedShouldDefaultToTrue()
        {
            PrehistoricPBJ pbj = new();
            Assert.True(pbj.Toasted);
        }

        /// <summary>
        /// Should be able to set Toasted to
        /// true or false
        /// </summary>
        [Fact]
        [Trait("Entree", "")]
        public void ShouldBeAbleToSetToasted()
        {
            PrehistoricPBJ pbj = new();
            pbj.PeanutButter = false;
            Assert.False(pbj.PeanutButter);
            pbj.PeanutButter = true;
            Assert.True(pbj.PeanutButter);
        }

        /// <summary>
        /// Price should always be $3.75
        /// </summary>
        /// <param name="peanutButter">If pbj contains peanut butter</param>
        /// <param name="jelly">If pbj contains jelly</param>
        /// <param name="toasted">If pbj is toasted</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true, true, true)]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(false, true, true)]
        [InlineData(false, false, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, false)]
        [InlineData(false, false, false)]
        public void PriceShouldBeCorrect(bool peanutButter, bool jelly, bool toasted)
        {
            PrehistoricPBJ pbj = new()
            {
                PeanutButter = peanutButter,
                Jelly = jelly,
                Toasted = toasted
            };
            Assert.Equal(3.75m, pbj.Price);
        }

        /// <summary>
        /// Calories varies based on how the PBJ is made
        /// </summary>
        /// <details>
        /// 148 calories for the bread
        /// 188 calories for the peanut butter 
        /// 62 calories for the jelly
        /// </details>
        /// <param name="peanutButter">If pbj contains peanut butter</param>
        /// <param name="jelly">If pbj contains jelly</param>
        /// <param name="toasted">If pbj is toasted</param>
        /// <param name="calories">The expected calories</param>
        [Theory]
        [Trait("Entree", "")]
        [InlineData(true, true, true, 148 + 188 + 62)]
        [InlineData(true, true, false, 148 + 188 + 62)]
        [InlineData(true, false, true, 148 + 188)]
        [InlineData(false, true, true, 148 + 62)]
        [InlineData(false, false, true, 148)]
        [InlineData(true, false, false, 148 + 188)]
        [InlineData(false, true, false, 148 + 62)]
        [InlineData(false, false, false, 148)]
        public void CaloriesShouldBeCorrect(bool peanutButter, bool jelly, bool toasted, uint calories)
        {
            PrehistoricPBJ pbj = new()
            {
                PeanutButter = peanutButter,
                Jelly = jelly,
                Toasted = toasted
            };
            Assert.Equal(calories, pbj.Calories);
        }
    }
}