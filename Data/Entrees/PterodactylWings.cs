namespace DinoDiner.Data.Entrees
{
    /// <summary>
    /// Class representing the Pterodactyl Wings menu item
    /// </summary>
    public class PterodactylWings : DinoMenuItem
    {

        /// <summary>
        /// Name of the Pterodactyl Wings menu item
        /// </summary>
        /// <returns>"[Sauce] Pterodactyl Wings"</returns>
        public override string Name
        {
            get
            {
                string sauce = "";
                switch (Sauce)
                {
                    case WingSauce.Buffalo: { sauce = "Buffalo"; break; }
                    case WingSauce.Teriyaki: { sauce = "Teriyaki"; break; }
                    case WingSauce.HoneyGlaze: { sauce = "Honey Glaze"; break; }
                }
                return sauce + " Pterodactyl Wings";
            }
        }


        /// <summary>
        /// Price of the Pterodactyl Wings menu item
        /// </summary>
        public override decimal Price { get; } = 8.95m;

        /// <summary>
        /// Calories of the Pterodactyl Wings menu item
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Sauce)
                {
                    case WingSauce.Teriyaki: { return 342; }
                    case WingSauce.HoneyGlaze: { return 359; }
                    default: return 360; //default is WingSauce.Buffalo
                }
            }
        }

        /// <summary>
        /// Type of sauce put on the wings.
        /// </summary>
        public WingSauce Sauce
        {
            get { return _sauce; }
            set
            {
                _sauce = value;
                OnPropertyChanged("Sauce");
                OnPropertyChanged("Calories");
                OnPropertyChanged("Name");
            }
        }
        /// <summary>
        /// Private value for Sauce
        /// </summary>
        private WingSauce _sauce = WingSauce.Buffalo;

        /// <summary>
        /// Changes to the normal menu item
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> changes = new List<string>();
                //Sauce change is in name already
                return changes;
            }
        }
    }
}
