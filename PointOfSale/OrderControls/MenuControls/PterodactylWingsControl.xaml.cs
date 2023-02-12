using DinoDiner.Data.Entrees;
using System.Windows.Controls;

namespace DinoDiner.PointOfSale.MenuControls
{
    /// <summary>
    /// Interaction logic for PterodactylWingsControl.xaml
    /// </summary>
    public partial class PterodactylWingsControl : UserControl
    {
        public PterodactylWingsControl(PterodactylWings wings)
        {
            InitializeComponent();
            this.DataContext = wings;
        }
    }
}
