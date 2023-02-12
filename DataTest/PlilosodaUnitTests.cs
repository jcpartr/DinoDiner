using DinoDiner.Data;

namespace DataTest
{
    /// <summary>
    /// Unit tests for the Philosoda class
    /// </summary>
    public class PlilosodaUnitTests
    {
        /// <summary>
        /// Checks if Philosoda is inheriting from INotifyPropertyChanged
        /// </summary>
        [Fact]
        [Trait("Drink", "")]
        public void ShouldInheritFromINotifyPropertyChanged()
        {
            Plilosoda soda = new Plilosoda();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(soda);
        }

        /// <summary>
        /// Tests if changing Size throws a property changed event
        /// </summary>
        /// <param name="size">Size of drink</param>
        /// <param name="propertyName">property being changed</param>
        [Theory]
        [Trait("Drink", "")]
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
            Plilosoda soda = new Plilosoda();
            Assert.PropertyChanged(soda, propertyName, () => { soda.Size = size; });
        }

        /// <summary>
        /// Tests if changing the flavor throws the right events
        /// </summary>
        /// <param name="flavor">Flavor of the soda</param>
        /// <param name="propertyName">Property being changed</param>
        [Theory]
        [Trait("Drink", "")]
        [InlineData(SodaFlavor.CherryCola, "Flavor")]
        [InlineData(SodaFlavor.CherryCola, "Calories")]
        [InlineData(SodaFlavor.CherryCola, "Name")]

        [InlineData(SodaFlavor.Cola, "Flavor")]
        [InlineData(SodaFlavor.Cola, "Calories")]
        [InlineData(SodaFlavor.Cola, "Name")]

        [InlineData(SodaFlavor.DinoDew, "Flavor")]
        [InlineData(SodaFlavor.DinoDew, "Calories")]
        [InlineData(SodaFlavor.DinoDew, "Name")]

        [InlineData(SodaFlavor.DoctorDino, "Flavor")]
        [InlineData(SodaFlavor.DoctorDino, "Calories")]
        [InlineData(SodaFlavor.DoctorDino, "Name")]

        [InlineData(SodaFlavor.LemonLime, "Flavor")]
        [InlineData(SodaFlavor.LemonLime, "Calories")]
        [InlineData(SodaFlavor.LemonLime, "Name")]
        public void ChangingFlavorShouldNotifyPropertyChanged(SodaFlavor flavor, string propertyName)
        {
            Plilosoda soda = new Plilosoda();
            Assert.PropertyChanged(soda, propertyName, () => { soda.Flavor = flavor; });
        }


        /// <summary>
        /// Checks if Plilosoda inherits from Drink
        /// </summary>
        [Fact]
        [Trait("Drink", "")]
        public void ShouldInheritFromMenuItem()
        {
            Plilosoda soda = new Plilosoda();
            Assert.IsAssignableFrom<DinoMenuItem>(soda);
        }

        /// <summary>
        /// Tests the name of the soda
        /// </summary>
        /// <param name="size">Size of drink</param>
        /// <param name="flavor">flavor of drink</param>
        [Theory]
        [Trait("Drink", "")]
        [InlineData(ServingSize.Small, SodaFlavor.CherryCola)]
        [InlineData(ServingSize.Small, SodaFlavor.Cola)]
        [InlineData(ServingSize.Small, SodaFlavor.DinoDew)]
        [InlineData(ServingSize.Small, SodaFlavor.DoctorDino)]
        [InlineData(ServingSize.Small, SodaFlavor.LemonLime)]

        [InlineData(ServingSize.Medium, SodaFlavor.CherryCola)]
        [InlineData(ServingSize.Medium, SodaFlavor.Cola)]
        [InlineData(ServingSize.Medium, SodaFlavor.DinoDew)]
        [InlineData(ServingSize.Medium, SodaFlavor.DoctorDino)]
        [InlineData(ServingSize.Medium, SodaFlavor.LemonLime)]

        [InlineData(ServingSize.Large, SodaFlavor.CherryCola)]
        [InlineData(ServingSize.Large, SodaFlavor.Cola)]
        [InlineData(ServingSize.Large, SodaFlavor.DinoDew)]
        [InlineData(ServingSize.Large, SodaFlavor.DoctorDino)]
        [InlineData(ServingSize.Large, SodaFlavor.LemonLime)]
        public void NameShouldBeCorrect(ServingSize size, SodaFlavor flavor)
        {
            Plilosoda soda = new Plilosoda();
            soda.Size = size;
            soda.Flavor = flavor;

            string name = "";
            //Size
            if (size == ServingSize.Small) { name += "Small "; }
            else if (size == ServingSize.Medium) { name += "Medium "; }
            else if (size == ServingSize.Large) { name += "Large "; }

            if (flavor == SodaFlavor.Cola) { name += "Cola "; }
            else if (flavor == SodaFlavor.CherryCola) { name += "Cherry Cola "; }
            else if (flavor == SodaFlavor.LemonLime) { name += "Lemon Lime "; }
            else if (flavor == SodaFlavor.DinoDew) { name += "Dino Dew "; }
            else if (flavor == SodaFlavor.DoctorDino) { name += "Doctor Dino "; }

            name += "Plilosoda";

            Assert.Equal(name, soda.Name);
        }

        /// <summary>
        /// Checks the price is correct
        /// </summary>
        /// <param name="size">Size of the drink</param>
        /// <param name="flavor">Flavor of the drink</param>
        [Theory]
        [Trait("Drink", "")]
        [InlineData(ServingSize.Small, SodaFlavor.CherryCola)]
        [InlineData(ServingSize.Small, SodaFlavor.Cola)]
        [InlineData(ServingSize.Small, SodaFlavor.DinoDew)]
        [InlineData(ServingSize.Small, SodaFlavor.DoctorDino)]
        [InlineData(ServingSize.Small, SodaFlavor.LemonLime)]

        [InlineData(ServingSize.Medium, SodaFlavor.CherryCola)]
        [InlineData(ServingSize.Medium, SodaFlavor.Cola)]
        [InlineData(ServingSize.Medium, SodaFlavor.DinoDew)]
        [InlineData(ServingSize.Medium, SodaFlavor.DoctorDino)]
        [InlineData(ServingSize.Medium, SodaFlavor.LemonLime)]

        [InlineData(ServingSize.Large, SodaFlavor.CherryCola)]
        [InlineData(ServingSize.Large, SodaFlavor.Cola)]
        [InlineData(ServingSize.Large, SodaFlavor.DinoDew)]
        [InlineData(ServingSize.Large, SodaFlavor.DoctorDino)]
        [InlineData(ServingSize.Large, SodaFlavor.LemonLime)]
        public void PriceShouldBeCorrect(ServingSize size, SodaFlavor flavor)
        {
            Plilosoda soda = new Plilosoda();
            soda.Size = size;
            soda.Flavor = flavor;

            decimal price = 0.0m;

            if (size == ServingSize.Small)
            {
                price = 1.00m;
            }
            else if (size == ServingSize.Medium)
            {
                price = 1.75m;
            }
            else if (size == ServingSize.Large)
            {
                price = 2.50m;
            }

            Assert.Equal(price, soda.Price);

        }

        /// <summary>
        /// Checks the calories is correct
        /// </summary>
        /// <param name="size">Size of the drink</param>
        /// <param name="flavor">Flavor of the drink</param>
        [Theory]
        [Trait("Drink", "")]
        [InlineData(ServingSize.Small, SodaFlavor.CherryCola)]
        [InlineData(ServingSize.Small, SodaFlavor.Cola)]
        [InlineData(ServingSize.Small, SodaFlavor.DinoDew)]
        [InlineData(ServingSize.Small, SodaFlavor.DoctorDino)]
        [InlineData(ServingSize.Small, SodaFlavor.LemonLime)]

        [InlineData(ServingSize.Medium, SodaFlavor.CherryCola)]
        [InlineData(ServingSize.Medium, SodaFlavor.Cola)]
        [InlineData(ServingSize.Medium, SodaFlavor.DinoDew)]
        [InlineData(ServingSize.Medium, SodaFlavor.DoctorDino)]
        [InlineData(ServingSize.Medium, SodaFlavor.LemonLime)]

        [InlineData(ServingSize.Large, SodaFlavor.CherryCola)]
        [InlineData(ServingSize.Large, SodaFlavor.Cola)]
        [InlineData(ServingSize.Large, SodaFlavor.DinoDew)]
        [InlineData(ServingSize.Large, SodaFlavor.DoctorDino)]
        [InlineData(ServingSize.Large, SodaFlavor.LemonLime)]
        public void CaloriesShouldBeCorrect(ServingSize size, SodaFlavor flavor)
        {
            Plilosoda soda = new Plilosoda();
            soda.Size = size;
            soda.Flavor = flavor;

            uint calories = 0;

            if (size == ServingSize.Small)
            {
                if (flavor == SodaFlavor.Cola) { calories = 180; }
                if (flavor == SodaFlavor.CherryCola) { calories = 100; }
                if (flavor == SodaFlavor.LemonLime) { calories = 41; }
                if (flavor == SodaFlavor.DinoDew) { calories = 141; }
                if (flavor == SodaFlavor.DoctorDino) { calories = 120; }
            }
            else if (size == ServingSize.Medium)
            {
                if (flavor == SodaFlavor.Cola) { calories = 288; }
                if (flavor == SodaFlavor.CherryCola) { calories = 160; }
                if (flavor == SodaFlavor.LemonLime) { calories = 66; }
                if (flavor == SodaFlavor.DinoDew) { calories = 256; }
                if (flavor == SodaFlavor.DoctorDino) { calories = 192; }
            }
            else if (size == ServingSize.Large)
            {
                if (flavor == SodaFlavor.Cola) { calories = 432; }
                if (flavor == SodaFlavor.CherryCola) { calories = 240; }
                if (flavor == SodaFlavor.LemonLime) { calories = 98; }
                if (flavor == SodaFlavor.DinoDew) { calories = 338; }
                if (flavor == SodaFlavor.DoctorDino) { calories = 288; }
            }

            Assert.Equal(calories, soda.Calories);

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
            Plilosoda soda = new Plilosoda();
            soda.Size = size;
            Assert.Equal(size, soda.Size);
        }

        /// <summary>
        /// Checks if flavor can be set
        /// </summary>
        /// <param name="flavor">Flavor of the drink</param>
        [Theory]
        [Trait("Drink", "")]
        [InlineData(SodaFlavor.CherryCola)]
        [InlineData(SodaFlavor.Cola)]
        [InlineData(SodaFlavor.DinoDew)]
        [InlineData(SodaFlavor.DoctorDino)]
        [InlineData(SodaFlavor.LemonLime)]
        public void ShouldBeAbleToSetFlavor(SodaFlavor flavor)
        {
            Plilosoda soda = new Plilosoda();
            soda.Flavor = flavor;
            Assert.Equal(flavor, soda.Flavor);
        }
    }
}
