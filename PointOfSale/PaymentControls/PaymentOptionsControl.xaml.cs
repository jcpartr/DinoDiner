using DinoDiner.Data;
using System.Windows.Controls;

namespace DinoDiner.PointOfSale
{
    /// <summary>
    /// Interaction logic for PaymentOptionsControl.xaml
    /// </summary>
    public partial class PaymentOptionsControl : UserControl
    {
        public PaymentOptionsControl(Order order)
        {
            InitializeComponent();
            this.DataContext = order;
        }
    }
}
