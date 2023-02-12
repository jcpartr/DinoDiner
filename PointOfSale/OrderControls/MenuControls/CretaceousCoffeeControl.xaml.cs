using DinoDiner.Data.Drinks;
using System.Windows.Controls;

namespace DinoDiner.PointOfSale.MenuControls
{
    /// <summary>
    /// Interaction logic for CretaceousCoffeeControl.xaml
    /// </summary>
    public partial class CretaceousCoffeeControl : UserControl
    {
        public CretaceousCoffeeControl(CretaceousCoffee coffee)
        {
            InitializeComponent();
            this.DataContext = coffee;
        }
    }
}
