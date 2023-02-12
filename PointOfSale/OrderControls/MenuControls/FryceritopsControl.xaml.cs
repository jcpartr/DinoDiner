using DinoDiner.Data.Sides;
using System.Windows.Controls;

namespace DinoDiner.PointOfSale.MenuControls
{
    /// <summary>
    /// Interaction logic for FryceritopsControl.xaml
    /// </summary>
    public partial class FryceritopsControl : UserControl
    {
        public FryceritopsControl(Fryceritops fries)
        {
            InitializeComponent();
            this.DataContext = fries;
        }
    }
}
