using DinoDiner.Data.Entrees;
using System.Windows.Controls;

namespace DinoDiner.PointOfSale.MenuControls
{
    /// <summary>
    /// Interaction logic for VelociWraptorControl.xaml
    /// </summary>
    public partial class VelociWraptorControl : UserControl
    {
        public VelociWraptorControl(VelociWraptor wrap)
        {
            InitializeComponent();
            this.DataContext = wrap;
        }
    }
}
