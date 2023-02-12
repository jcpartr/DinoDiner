using DinoDiner.Data.Entrees;
using System.Windows;
using System.Windows.Controls;

namespace DinoDiner.PointOfSale.MenuControls
{
    /// <summary>
    /// Interaction logic for BurgerControl.xaml
    /// </summary>
    public partial class BurgerControl : UserControl
    {

        /// <summary>
        /// Private Reference to the given burger
        /// </summary>
        private Burger _burger;

        /// <summary>
        /// Constructor for the BurgerControl
        /// </summary>
        /// <param name="burger">Burger Object</param>
        public BurgerControl(Burger burger)
        {
            InitializeComponent();

            this.DataContext = burger;
            _burger = burger;

            PattiesControl.IncreasePattiesButton.Click += IncreasePattiesButton_Click;
            PattiesControl.DecreasePattiesButton.Click += DecreasePattiesButton_Click;

        }
        /// <summary>
        /// Increase the number of Patties in the burger object
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Arguments</param>
        private void IncreasePattiesButton_Click(object sender, RoutedEventArgs e)
        {
            _burger.Patties++;
        }
        /// <summary>
        /// Decrease the number of Patties in the burger object
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Arguments</param>
        private void DecreasePattiesButton_Click(object sender, RoutedEventArgs e)
        {
            if (_burger.Patties == 0) { return; }
            _burger.Patties--;
        }

    }
}
