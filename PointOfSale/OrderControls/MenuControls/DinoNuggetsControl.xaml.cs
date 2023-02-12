using DinoDiner.Data.Entrees;
using System.Windows;
using System.Windows.Controls;

namespace DinoDiner.PointOfSale.MenuControls
{
    /// <summary>
    /// Interaction logic for DinoNuggetsControl.xaml
    /// </summary>
    public partial class DinoNuggetsControl : UserControl
    {
        private DinoNuggets _nuggets;

        public DinoNuggetsControl(DinoNuggets nuggets)
        {
            InitializeComponent();
            _nuggets = nuggets;
            this.DataContext = nuggets;
            NuggetsCounter.IncreaseCountButton.Click += IncreaseCountButton_Click;
            NuggetsCounter.DecreaseCountbutton.Click += DecreaseCountbutton_Click;
        }

        private void IncreaseCountButton_Click(object sender, RoutedEventArgs e)
        {
            _nuggets.Count++;
        }

        private void DecreaseCountbutton_Click(object sender, RoutedEventArgs e)
        {
            if (_nuggets.Count == 0) { return; }
            _nuggets.Count--;
        }
    }
}
