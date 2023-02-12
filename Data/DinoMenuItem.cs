namespace DinoDiner.Data
{
    /// <summary>
    /// Base Class Representing All Menu Items
    /// </summary>
    public abstract class DinoMenuItem : INotifyPropertyChanged
    {
        /// <summary>
        /// Name of the drink
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Price of the drink
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// Calories of the drink
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Summary list of Changes to the menu item
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }

        /// <summary>
        /// Event Triggered by property changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Event Helper function to be called when a property changes in any sub classes
        /// </summary>
        /// <param name="propertyName">Name of the property exact case</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
