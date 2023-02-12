using DinoDiner.Data.Sides;
using System.Windows.Controls;

namespace DinoDiner.PointOfSale.MenuControls
{
    /// <summary>
    /// Interaction logic for TriceritotsControl.xaml
    /// </summary>
    public partial class TriceritotsControl : UserControl
    {
        public TriceritotsControl(Triceritots tots)
        {
            InitializeComponent();
            this.DataContext = tots;
        }
    }
}
