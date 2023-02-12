using DinoDiner.Data.Sides;
using System.Windows.Controls;

namespace DinoDiner.PointOfSale.MenuControls
{
    /// <summary>
    /// Interaction logic for MeteorMacAndCheese.xaml
    /// </summary>
    public partial class MeteorMacAndCheeseControl : UserControl
    {

        public MeteorMacAndCheeseControl(MeteorMacAndCheese mac)
        {
            InitializeComponent();
            this.DataContext = mac;
        }
    }
}
