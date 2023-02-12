using DinoDiner.Data.Entrees;
using System.Windows.Controls;

namespace DinoDiner.PointOfSale.MenuControls
{
    /// <summary>
    /// Interaction logic for PrehistoricPBJControl.xaml
    /// </summary>
    public partial class PrehistoricPBJControl : UserControl
    {
        public PrehistoricPBJControl(PrehistoricPBJ pbj)
        {
            InitializeComponent();
            this.DataContext = pbj;
        }
    }
}
