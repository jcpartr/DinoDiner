using DinoDiner.Data;

namespace DataTest
{
    /// <summary>
    /// unit tests for the TRexTripleBurger class
    /// </summary>
    public class TRexTripleBurgerUnitTests
    {
        /// <summary>
        /// Checks if inherits from INotifyPropertyChanged
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void ShouldInheritFromINotifyPropertyChanged()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(burger);
        }

        /// <summary>
        /// Tests if changing Patties notifies property changes
        /// </summary>
        /// <param name="patties">num Patties</param>
        /// <param name="propertyName">property to test</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(1, "Patties")]
        [InlineData(1, "Price")]
        [InlineData(1, "Calories")]
        [InlineData(2, "Patties")]
        [InlineData(2, "Price")]
        [InlineData(2, "Calories")]
        [InlineData(6, "Patties")]
        [InlineData(6, "Price")]
        [InlineData(6, "Calories")]
        public void ChangingPattiesShouldNotifyPropertyChanges(uint patties, string propertyName)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.PropertyChanged(burger, propertyName, () => { burger.Patties = patties; });
        }

        /// <summary>
        /// Tests if changing Ketchup notifies a property change
        /// </summary>
        /// <param name="ketchup">Ketchup Boolean</param>
        /// <param name="propertyName">Property Name</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true, "Ketchup")]
        [InlineData(true, "Calories")]
        [InlineData(true, "Price")]
        [InlineData(false, "Ketchup")]
        [InlineData(false, "Calories")]
        [InlineData(false, "Price")]
        public void ChangingeKetchupShouldNotifyPropertyChanges(bool ketchup, string propertyName)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.PropertyChanged(burger, propertyName, () => { burger.Ketchup = ketchup; });
        }

        /// <summary>
        /// Tests if changing Mustard notifies a property change
        /// </summary>
        /// <param name="mustard">Mustard Boolean</param>
        /// <param name="propertyName">Property Name</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true, "Mustard")]
        [InlineData(true, "Calories")]
        [InlineData(true, "Price")]
        [InlineData(false, "Mustard")]
        [InlineData(false, "Calories")]
        [InlineData(false, "Price")]
        public void ChangingeMustardShouldNotifyPropertyChanges(bool mustard, string propertyName)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.PropertyChanged(burger, propertyName, () => { burger.Mustard = mustard; });
        }

        /// <summary>
        /// Tests if changing Pickle notifies a property change
        /// </summary>
        /// <param name="pickle">Pickle Boolean</param>
        /// <param name="propertyName">Property Name</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true, "Pickle")]
        [InlineData(true, "Calories")]
        [InlineData(true, "Price")]
        [InlineData(false, "Pickle")]
        [InlineData(false, "Calories")]
        [InlineData(false, "Price")]
        public void ChangingePickleShouldNotifyPropertyChanges(bool pickle, string propertyName)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.PropertyChanged(burger, propertyName, () => { burger.Pickle = pickle; });
        }

        /// <summary>
        /// Tests if changing Mayo notifies a property change
        /// </summary>
        /// <param name="mayo">Mayo Boolean</param>
        /// <param name="propertyName">Property Name</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true, "Mayo")]
        [InlineData(true, "Calories")]
        [InlineData(true, "Price")]
        [InlineData(false, "Mayo")]
        [InlineData(false, "Calories")]
        [InlineData(false, "Price")]
        public void ChangingeMayoShouldNotifyPropertyChanges(bool mayo, string propertyName)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.PropertyChanged(burger, propertyName, () => { burger.Mayo = mayo; });
        }

        /// <summary>
        /// Tests if changing BBQ notifies a property change
        /// </summary>
        /// <param name="bbq">BBQ Boolean</param>
        /// <param name="propertyName">Property Name</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true, "BBQ")]
        [InlineData(true, "Calories")]
        [InlineData(true, "Price")]
        [InlineData(false, "BBQ")]
        [InlineData(false, "Calories")]
        [InlineData(false, "Price")]
        public void ChangingeBBQShouldNotifyPropertyChanges(bool bbq, string propertyName)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.PropertyChanged(burger, propertyName, () => { burger.BBQ = bbq; });
        }

        /// <summary>
        /// Tests if changing Onion notifies a property change
        /// </summary>
        /// <param name="onion">Onion Boolean</param>
        /// <param name="propertyName">Property Name</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true, "Onion")]
        [InlineData(true, "Calories")]
        [InlineData(true, "Price")]
        [InlineData(false, "Onion")]
        [InlineData(false, "Calories")]
        [InlineData(false, "Price")]
        public void ChangingeOnionShouldNotifyPropertyChanges(bool onion, string propertyName)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.PropertyChanged(burger, propertyName, () => { burger.Onion = onion; });
        }

        /// <summary>
        /// Tests if changing Tomato notifies a property change
        /// </summary>
        /// <param name="tomato">Tomato Boolean</param>
        /// <param name="propertyName">Property Name</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true, "Tomato")]
        [InlineData(true, "Calories")]
        [InlineData(true, "Price")]
        [InlineData(false, "Tomato")]
        [InlineData(false, "Calories")]
        [InlineData(false, "Price")]
        public void ChangingeTomatoShouldNotifyPropertyChanges(bool tomato, string propertyName)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.PropertyChanged(burger, propertyName, () => { burger.Tomato = tomato; });
        }

        /// <summary>
        /// Tests if changing Lettuce notifies a property change
        /// </summary>
        /// <param name="lettuce">Lettuce Boolean</param>
        /// <param name="propertyName">Property Name</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true, "Lettuce")]
        [InlineData(true, "Calories")]
        [InlineData(true, "Price")]
        [InlineData(false, "Lettuce")]
        [InlineData(false, "Calories")]
        [InlineData(false, "Price")]
        public void ChangingeLettuceShouldNotifyPropertyChanges(bool lettuce, string propertyName)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.PropertyChanged(burger, propertyName, () => { burger.Lettuce = lettuce; });
        }

        /// <summary>
        /// Tests if changing AmericanCheese notifies a property change
        /// </summary>
        /// <param name="americancheese">AmericanCheese Boolean</param>
        /// <param name="propertyName">Property Name</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true, "AmericanCheese")]
        [InlineData(true, "Calories")]
        [InlineData(true, "Price")]
        [InlineData(false, "AmericanCheese")]
        [InlineData(false, "Calories")]
        [InlineData(false, "Price")]
        public void ChangingeAmericanCheeseShouldNotifyPropertyChanges(bool americancheese, string propertyName)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.PropertyChanged(burger, propertyName, () => { burger.AmericanCheese = americancheese; });
        }

        /// <summary>
        /// Tests if changing SwissCheese notifies a property change
        /// </summary>
        /// <param name="swisscheese">SwissCheese Boolean</param>
        /// <param name="propertyName">Property Name</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true, "SwissCheese")]
        [InlineData(true, "Calories")]
        [InlineData(true, "Price")]
        [InlineData(false, "SwissCheese")]
        [InlineData(false, "Calories")]
        [InlineData(false, "Price")]
        public void ChangingeSwissCheeseShouldNotifyPropertyChanges(bool swisscheese, string propertyName)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.PropertyChanged(burger, propertyName, () => { burger.SwissCheese = swisscheese; });
        }

        /// <summary>
        /// Tests if changing Bacon notifies a property change
        /// </summary>
        /// <param name="bacon">Bacon Boolean</param>
        /// <param name="propertyName">Property Name</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true, "Bacon")]
        [InlineData(true, "Calories")]
        [InlineData(true, "Price")]
        [InlineData(false, "Bacon")]
        [InlineData(false, "Calories")]
        [InlineData(false, "Price")]
        public void ChangingeBaconShouldNotifyPropertyChanges(bool bacon, string propertyName)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.PropertyChanged(burger, propertyName, () => { burger.Bacon = bacon; });
        }

        /// <summary>
        /// Tests if changing Mushrooms notifies a property change
        /// </summary>
        /// <param name="mushrooms">Mushrooms Boolean</param>
        /// <param name="propertyName">Property Name</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true, "Mushrooms")]
        [InlineData(true, "Calories")]
        [InlineData(true, "Price")]
        [InlineData(false, "Mushrooms")]
        [InlineData(false, "Calories")]
        [InlineData(false, "Price")]
        public void ChangingeMushroomsShouldNotifyPropertyChanges(bool mushrooms, string propertyName)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.PropertyChanged(burger, propertyName, () => { burger.Mushrooms = mushrooms; });
        }

        /// <summary>
        /// Checks if inherits from Entree
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void ShouldInheritFromMenuItem()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.IsAssignableFrom<DinoMenuItem>(burger);
        }

        /// <summary>
        /// Checks if inherits from Entree
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void ShouldInheritFromBurger()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.IsAssignableFrom<Burger>(burger);
        }

        /// <summary>
        /// Checks if name is correct
        /// </summary>
        /// <param name="ketchup">bool if ketchup</param>
        /// <param name="mustard">bool if mustard</param>
        /// <param name="pickle">bool if pickles</param>
        /// <param name="mayo">bool if mayo</param>
        /// <param name="bbq">bool if bbq</param>
        /// <param name="onion">bool if onion</param>
        /// <param name="tomato">bool if tomato</param>
        /// <param name="lettuce">bool if lettuce</param>
        /// <param name="americanCheese">bool if americanCheese</param>
        /// <param name="swissCheese">bool if swissCheese</param>
        /// <param name="bacon">bool if bacon</param>
        /// <param name="mushrooms">bool if mushrooms</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true, true, true, true, true, true, true, true, true, true, true, true)]
        [InlineData(true, false, true, true, true, true, true, true, true, true, true, true)]
        [InlineData(true, true, false, true, true, true, true, true, true, true, true, true)]
        [InlineData(true, true, true, false, true, true, true, true, true, true, true, true)]
        [InlineData(true, true, true, true, false, true, true, true, true, true, true, true)]
        [InlineData(true, true, true, true, true, false, true, true, true, true, true, true)]
        [InlineData(true, true, true, true, true, true, false, true, true, true, true, true)]
        [InlineData(true, true, true, true, true, true, true, false, true, true, true, true)]
        [InlineData(true, true, true, true, true, true, true, true, false, true, true, true)]
        [InlineData(true, true, true, true, true, true, true, true, true, false, true, true)]
        [InlineData(true, true, true, true, true, true, true, true, true, true, false, true)]
        [InlineData(true, true, true, true, true, true, true, true, true, true, true, false)]
        [InlineData(false, false, false, false, false, false, false, false, false, false, false, false)]
        public void NameShouldBeCorrect(bool ketchup, bool mustard, bool pickle, bool mayo, bool bbq, bool onion, bool tomato, bool lettuce, bool americanCheese, bool swissCheese, bool bacon, bool mushrooms)
        {
            Burger burger = new TRexTripleBurger();
            burger.Ketchup = ketchup;
            burger.Mushrooms = mustard;
            burger.Pickle = pickle;
            burger.Mayo = mayo;
            burger.BBQ = bbq;
            burger.Onion = onion;
            burger.Tomato = tomato;
            burger.Lettuce = lettuce;
            burger.AmericanCheese = americanCheese;
            burger.SwissCheese = swissCheese;
            burger.Bacon = bacon;
            burger.Mushrooms = mushrooms;
            Assert.Equal("T-Rex Triple Burger", burger.Name);
        }

        /// <summary>
        /// Checks if price is correct
        /// </summary>
        /// <param name="patties">Number of patties</param>
        /// <param name="ketchup">bool if ketchup</param>
        /// <param name="mustard">bool if mustard</param>
        /// <param name="pickle">bool if pickles</param>
        /// <param name="mayo">bool if mayo</param>
        /// <param name="bbq">bool if bbq</param>
        /// <param name="onion">bool if onion</param>
        /// <param name="tomato">bool if tomato</param>
        /// <param name="lettuce">bool if lettuce</param>
        /// <param name="americanCheese">bool if americanCheese</param>
        /// <param name="swissCheese">bool if swissCheese</param>
        /// <param name="bacon">bool if bacon</param>
        /// <param name="mushrooms">bool if mushrooms</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(7, true, true, true, true, true, true, true, true, true, true, true, true)]
        [InlineData(8, true, false, true, true, true, true, true, true, true, true, true, true)]
        [InlineData(4, true, true, false, true, true, true, true, true, true, true, true, true)]
        [InlineData(10, true, true, true, false, true, true, true, true, true, true, true, true)]
        [InlineData(2, true, true, true, true, false, true, true, true, true, true, true, true)]
        [InlineData(2, true, true, true, true, true, false, true, true, true, true, true, true)]
        [InlineData(1, true, true, true, true, true, true, false, true, true, true, true, true)]
        [InlineData(4, true, true, true, true, true, true, true, false, true, true, true, true)]
        [InlineData(5, true, true, true, true, true, true, true, true, false, true, true, true)]
        [InlineData(3, true, true, true, true, true, true, true, true, true, false, true, true)]
        [InlineData(14, true, true, true, true, true, true, true, true, true, true, false, true)]
        [InlineData(42, true, true, true, true, true, true, true, true, true, true, true, false)]
        [InlineData(6, false, false, false, false, false, false, false, false, false, false, false, false)]
        public void PriceShouldBeCorrect(uint patties, bool ketchup, bool mustard, bool pickle, bool mayo, bool bbq, bool onion, bool tomato, bool lettuce, bool americanCheese, bool swissCheese, bool bacon, bool mushrooms)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            burger.Patties = patties;
            burger.Ketchup = ketchup;
            burger.Mustard = mustard;
            burger.Pickle = pickle;
            burger.Mayo = mayo;
            burger.BBQ = bbq;
            burger.Onion = onion;
            burger.Tomato = tomato;
            burger.Lettuce = lettuce;
            burger.AmericanCheese = americanCheese;
            burger.SwissCheese = swissCheese;
            burger.Bacon = bacon;
            burger.Mushrooms = mushrooms;

            decimal price = 1.40m * patties;
            if (ketchup) { price += .20m; }
            if (mustard) { price += .20m; }
            if (pickle) { price += .20m; }
            if (mayo) { price += .20m; }
            if (bbq) { price += .10m; }
            if (onion) { price += .40m; }
            if (tomato) { price += .40m; }
            if (lettuce) { price += .30m; }
            if (americanCheese) { price += .25m; }
            if (swissCheese) { price += .25m; }
            if (bacon) { price += .50m; }
            if (mushrooms) { price += .40m; }

            Assert.Equal(price, burger.Price);

        }

        /// <summary>
        /// Checks if Calories is correct
        /// </summary>
        /// <param name="patties">Number of patties</param>
        /// <param name="ketchup">bool if ketchup</param>
        /// <param name="mustard">bool if mustard</param>
        /// <param name="pickle">bool if pickles</param>
        /// <param name="mayo">bool if mayo</param>
        /// <param name="bbq">bool if bbq</param>
        /// <param name="onion">bool if onion</param>
        /// <param name="tomato">bool if tomato</param>
        /// <param name="lettuce">bool if lettuce</param>
        /// <param name="americanCheese">bool if americanCheese</param>
        /// <param name="swissCheese">bool if swissCheese</param>
        /// <param name="bacon">bool if bacon</param>
        /// <param name="mushrooms">bool if mushrooms</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(7, true, true, true, true, true, true, true, true, true, true, true, true)]
        [InlineData(8, true, false, true, true, true, true, true, true, true, true, true, true)]
        [InlineData(4, true, true, false, true, true, true, true, true, true, true, true, true)]
        [InlineData(10, true, true, true, false, true, true, true, true, true, true, true, true)]
        [InlineData(2, true, true, true, true, false, true, true, true, true, true, true, true)]
        [InlineData(2, true, true, true, true, true, false, true, true, true, true, true, true)]
        [InlineData(1, true, true, true, true, true, true, false, true, true, true, true, true)]
        [InlineData(4, true, true, true, true, true, true, true, false, true, true, true, true)]
        [InlineData(5, true, true, true, true, true, true, true, true, false, true, true, true)]
        [InlineData(3, true, true, true, true, true, true, true, true, true, false, true, true)]
        [InlineData(14, true, true, true, true, true, true, true, true, true, true, false, true)]
        [InlineData(42, true, true, true, true, true, true, true, true, true, true, true, false)]
        [InlineData(6, false, false, false, false, false, false, false, false, false, false, false, false)]
        public void CaloriesShouldBeCorrect(uint patties, bool ketchup, bool mustard, bool pickle, bool mayo, bool bbq, bool onion, bool tomato, bool lettuce, bool americanCheese, bool swissCheese, bool bacon, bool mushrooms)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            burger.Patties = patties;
            burger.Ketchup = ketchup;
            burger.Mustard = mustard;
            burger.Pickle = pickle;
            burger.Mayo = mayo;
            burger.BBQ = bbq;
            burger.Onion = onion;
            burger.Tomato = tomato;
            burger.Lettuce = lettuce;
            burger.AmericanCheese = americanCheese;
            burger.SwissCheese = swissCheese;
            burger.Bacon = bacon;
            burger.Mushrooms = mushrooms;

            uint calories = 204 * patties;
            if (ketchup) { calories += 19; }
            if (mustard) { calories += 3; }
            if (pickle) { calories += 7; }
            if (mayo) { calories += 94; }
            if (bbq) { calories += 29; }
            if (onion) { calories += 44; }
            if (tomato) { calories += 22; }
            if (lettuce) { calories += 5; }
            if (americanCheese) { calories += 104; }
            if (swissCheese) { calories += 106; }
            if (bacon) { calories += 43; }
            if (mushrooms) { calories += 3; }

            Assert.Equal(calories, burger.Calories);
        }

        /// <summary>
        /// Checks if patties start at 3
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void PattiesShouldDefaultToThree()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.Equal((uint)3, burger.Patties);
        }

        /// <summary>
        /// Checks if patties can be changed
        /// </summary>
        /// <param name="patties">Number of patties</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(4)]
        [InlineData(2)]
        [InlineData(18)]
        [InlineData(3)]
        public void ShouldBeAbleToSetPatties(uint patties)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            burger.Patties = patties;
            Assert.Equal(patties, burger.Patties);
        }
        /// <summary>
        /// Ketchup should start true
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void KetchupShouldDefaultToTrue()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.True(burger.Ketchup);
        }

        /// <summary>
        /// Checks if ketchup can be changed
        /// </summary>
        /// <param name="included">Boolean to test</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToChangeKetchup(bool included)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            burger.Ketchup = included;
            Assert.Equal(burger.Ketchup, included);
            burger.Ketchup = !included;
            Assert.Equal(burger.Ketchup, !included);
        }

        /// <summary>
        /// Mustard should start false
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void MustardShouldDefaultToFalse()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.False(burger.Mustard);
        }

        /// <summary>
        /// Checks if Mustard can be changed
        /// </summary>
        /// <param name="included">Boolean to test</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToChangeMustard(bool included)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            burger.Mustard = included;
            Assert.Equal(burger.Mustard, included);
            burger.Mustard = !included;
            Assert.Equal(burger.Mustard, !included);
        }

        /// <summary>
        /// Pickle should start true
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void PickleShouldDefaultToTrue()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.True(burger.Pickle);
        }

        /// <summary>
        /// Checks if Pickle can be changed
        /// </summary>
        /// <param name="included">Boolean to test</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToChangePickle(bool included)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            burger.Pickle = included;
            Assert.Equal(burger.Pickle, included);
            burger.Pickle = !included;
            Assert.Equal(burger.Pickle, !included);
        }

        /// <summary>
        /// Mayo should start true
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void MayoShouldDefaultToTrue()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.True(burger.Mayo);
        }

        /// <summary>
        /// Checks if Mayo can be changed
        /// </summary>
        /// <param name="included">Boolean to test</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToChangeMayo(bool included)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            burger.Mayo = included;
            Assert.Equal(burger.Mayo, included);
            burger.Mayo = !included;
            Assert.Equal(burger.Mayo, !included);
        }

        /// <summary>
        /// BBQ should start false
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void BBQShouldDefaultToFalse()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.False(burger.BBQ);
        }

        /// <summary>
        /// Checks if BBQ can be changed
        /// </summary>
        /// <param name="included">Boolean to test</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToChangeBBQ(bool included)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            burger.BBQ = included;
            Assert.Equal(burger.BBQ, included);
            burger.BBQ = !included;
            Assert.Equal(burger.BBQ, !included);
        }

        /// <summary>
        /// Onion should start true
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void OnionShouldDefaultToTrue()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.True(burger.Onion);
        }

        /// <summary>
        /// Checks if Onion can be changed
        /// </summary>
        /// <param name="included">Boolean to test</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToChangeOnion(bool included)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            burger.Onion = included;
            Assert.Equal(burger.Onion, included);
            burger.Onion = !included;
            Assert.Equal(burger.Onion, !included);
        }

        /// <summary>
        /// Tomato should start True
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void TomatoShouldDefaultToTrue()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.True(burger.Tomato);
        }

        /// <summary>
        /// Checks if Tomato can be changed
        /// </summary>
        /// <param name="included">Boolean to test</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToChangeTomato(bool included)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            burger.Tomato = included;
            Assert.Equal(burger.Tomato, included);
            burger.Tomato = !included;
            Assert.Equal(burger.Tomato, !included);
        }

        /// <summary>
        /// Lettuce should start true
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void LettuceShouldDefaultToTrue()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.True(burger.Lettuce);
        }

        /// <summary>
        /// Checks if Lettuce can be changed
        /// </summary>
        /// <param name="included">Boolean to test</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToChangeLettuce(bool included)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            burger.Lettuce = included;
            Assert.Equal(burger.Lettuce, included);
            burger.Lettuce = !included;
            Assert.Equal(burger.Lettuce, !included);
        }

        /// <summary>
        /// AmericanCheese should start False
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void AmericanCheeseShouldDefaultToFalse()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.False(burger.AmericanCheese);
        }

        /// <summary>
        /// Checks if AmericanCheese can be changed
        /// </summary>
        /// <param name="included">Boolean to test</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToChangeAmericanCheese(bool included)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            burger.AmericanCheese = included;
            Assert.Equal(burger.AmericanCheese, included);
            burger.AmericanCheese = !included;
            Assert.Equal(burger.AmericanCheese, !included);
        }

        /// <summary>
        /// SwissCheese should start False
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void SwissCheeseShouldDefaultToFalse()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.False(burger.SwissCheese);
        }

        /// <summary>
        /// Checks if SwissCheese can be changed
        /// </summary>
        /// <param name="included">Boolean to test</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToChangeSwissCheese(bool included)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            burger.SwissCheese = included;
            Assert.Equal(burger.SwissCheese, included);
            burger.SwissCheese = !included;
            Assert.Equal(burger.SwissCheese, !included);
        }

        /// <summary>
        /// Bacon should start False
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void BaconShouldDefaultToFalse()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.False(burger.Bacon);
        }

        /// <summary>
        /// Checks if Bacon can be changed
        /// </summary>
        /// <param name="included">Boolean to test</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToChangeBacon(bool included)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            burger.Bacon = included;
            Assert.Equal(burger.Bacon, included);
            burger.Bacon = !included;
            Assert.Equal(burger.Bacon, !included);
        }

        /// <summary>
        /// Mushrooms should start False
        /// </summary>
        [Fact]
        [Trait("Entree", "Burger")]
        public void MushroomsShouldDefaultToFalse()
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            Assert.False(burger.Mushrooms);
        }

        /// <summary>
        /// Checks if Mushrooms can be changed
        /// </summary>
        /// <param name="included">Boolean to test</param>
        [Theory]
        [Trait("Entree", "Burger")]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToChangeMushrooms(bool included)
        {
            TRexTripleBurger burger = new TRexTripleBurger();
            burger.Mushrooms = included;
            Assert.Equal(burger.Mushrooms, included);
            burger.Mushrooms = !included;
            Assert.Equal(burger.Mushrooms, !included);
        }
    }
}
