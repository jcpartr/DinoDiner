namespace DinoDiner.Data.Drinks
{
    /// <summary>
    /// Class representing the Philosoda drink
    /// </summary>
    public class Plilosoda : DinoMenuItem
    {
        /// <summary>
        /// The name of the soda
        /// </summary>
        public override string Name
        {
            get
            {
                string name = "";
                //Size
                if (Size == ServingSize.Small) { name += "Small "; }
                else if (Size == ServingSize.Medium) { name += "Medium "; }
                else if (Size == ServingSize.Large) { name += "Large "; }
                else throw new Exception("Size Not Selected!");
                //Flavor
                if (Flavor == SodaFlavor.Cola) { name += "Cola "; }
                else if (Flavor == SodaFlavor.CherryCola) { name += "Cherry Cola "; }
                else if (Flavor == SodaFlavor.LemonLime) { name += "Lemon Lime "; }
                else if (Flavor == SodaFlavor.DinoDew) { name += "Dino Dew "; }
                else if (Flavor == SodaFlavor.DoctorDino) { name += "Doctor Dino "; }
                else throw new Exception("Flavor Not Selected!");
                //Philosoda
                return name + "Plilosoda";
            }
        }

        /// <summary>
        /// Price of the drink
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (Size == ServingSize.Small) { return 1.00m; }
                if (Size == ServingSize.Medium) { return 1.75m; }
                if (Size == ServingSize.Large) { return 2.50m; }
                throw new Exception("Size Not Selected");
            }
        }
        /// <summary>
        /// Calories in the drink
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == ServingSize.Small)
                {
                    if (Flavor == SodaFlavor.Cola) { return 180; }
                    if (Flavor == SodaFlavor.CherryCola) { return 100; }
                    if (Flavor == SodaFlavor.LemonLime) { return 41; }
                    if (Flavor == SodaFlavor.DinoDew) { return 141; }
                    if (Flavor == SodaFlavor.DoctorDino) { return 120; }
                    throw new Exception("Flavor Not Selected!");
                }
                if (Size == ServingSize.Medium)
                {
                    if (Flavor == SodaFlavor.Cola) { return 288; }
                    if (Flavor == SodaFlavor.CherryCola) { return 160; }
                    if (Flavor == SodaFlavor.LemonLime) { return 66; }
                    if (Flavor == SodaFlavor.DinoDew) { return 256; }
                    if (Flavor == SodaFlavor.DoctorDino) { return 192; }
                    throw new Exception("Flavor Not Selected"!);
                }
                if (Size == ServingSize.Large)
                {
                    if (Flavor == SodaFlavor.Cola) { return 432; }
                    if (Flavor == SodaFlavor.CherryCola) { return 240; }
                    if (Flavor == SodaFlavor.LemonLime) { return 98; }
                    if (Flavor == SodaFlavor.DinoDew) { return 338; }
                    if (Flavor == SodaFlavor.DoctorDino) { return 288; }
                    throw new Exception("Flavor Not Selected!");
                }
                throw new Exception("Size Not Selected!");
            }
        }

        /// <summary>
        /// Flavor of the soda
        /// </summary>
        public SodaFlavor Flavor
        {
            get { return _flavor; }
            set
            {
                _flavor = value;
                OnPropertyChanged("Flavor");
                OnPropertyChanged("Calories");
                OnPropertyChanged("Name");
            }

        }

        /// <summary>
        /// Private value for Flavor
        /// </summary>
        private SodaFlavor _flavor;
        /// <summary>
        /// size of the soda
        /// </summary>
        public ServingSize Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged("Size");
                OnPropertyChanged("Calories");
                OnPropertyChanged("Price");
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Empty List of changes
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// Private value for Size
        /// </summary>
        private ServingSize _size;

    }
}
