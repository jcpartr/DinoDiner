using DinoDiner.Data.Drinks;
using System.Windows.Controls;

namespace DinoDiner.PointOfSale.MenuControls
{
    /// <summary>
    /// Interaction logic for PhilosodaControl.xaml
    /// </summary>
    public partial class PhilosodaControl : UserControl
    {
        public PhilosodaControl(Plilosoda soda)
        {
            InitializeComponent();
            this.DataContext = soda;
        }
    }
}
