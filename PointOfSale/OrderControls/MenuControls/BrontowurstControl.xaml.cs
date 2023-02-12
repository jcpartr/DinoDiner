using DinoDiner.Data.Entrees;
using System.Windows.Controls;

namespace DinoDiner.PointOfSale.MenuControls
{
    /// <summary>
    /// Interaction logic for BrontowurstControl.xaml
    /// </summary>
    public partial class BrontowurstControl : UserControl
    {
        public BrontowurstControl(Brontowurst brontowurst)
        {
            InitializeComponent();
            this.DataContext = brontowurst;
        }
    }
}
