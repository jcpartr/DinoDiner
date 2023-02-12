using DinoDiner.Data.Sides;
using System.Windows.Controls;

namespace DinoDiner.PointOfSale.MenuControls
{
    /// <summary>
    /// Interaction logic for MezzorellaSticksControl.xaml
    /// </summary>
    public partial class MezzorellaSticksControl : UserControl
    {
        public MezzorellaSticksControl(MezzorellaSticks sticks)
        {
            InitializeComponent();
            this.DataContext = sticks;
        }
    }
}
