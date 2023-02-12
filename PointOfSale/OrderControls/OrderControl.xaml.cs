using DinoDiner.Data;
using DinoDiner.Data.Drinks;
using DinoDiner.Data.Entrees;
using DinoDiner.Data.Sides;
using DinoDiner.PointOfSale.MenuControls;
using System.Windows;
using System.Windows.Controls;

namespace DinoDiner.PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        /// <summary>
        /// Object for displaying the menu
        /// </summary>
        private readonly MenuItemSelectionControl _menu;

        /// <summary>
        /// Current Menu Item Being Displayed, Nullable
        /// </summary>
        private DinoMenuItem? _currentItem;

        /// <summary>
        /// Private Reference to the parent order
        /// </summary>
        private Order _order;

        public OrderControl(Order order)
        {
            InitializeComponent();

            _order = order;
            _menu = new MenuItemSelectionControl();

            this.DataContext = _order;
            this.OrderSummaryControl.DataContext = _order;

            MenuButtonSetup();
            DisplayMenu();
            OrderSummaryControl.List.OrderList.SelectionChanged += OnOrderItemSelectionChanged;
        }

        /// <summary>
        /// Displays the given control
        /// </summary>
        /// <param name="control">Menu Item Control</param>
        private void DisplayControl(UserControl control)
        {
            MenuContainer.Child = control;
        }

        /// <summary>
        /// Used to display the menu control
        /// </summary>
        public void DisplayMenu()
        {
            DisplayControl(_menu);
            RemoveItemButton.IsEnabled = false;
            AddMoreItemsButton.IsEnabled = false;
            _currentItem = null;
        }

        /// <summary>
        /// Sets up all the Menu Item Buttons on the Menu
        /// </summary>
        private void MenuButtonSetup()
        {
            foreach (var c in _menu.MenuGrid.Children)
            {
                if (c is Button b)
                {
                    b.Click += MenuButton_Click;
                }
            }
        }

        /// <summary>
        /// Event Handler for Menu Item Buttons
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Arguments</param>
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Name == "AllosaurusAllAmericanButton")
                {
                    AllosaurusAllAmericanBurger allosaurus = new AllosaurusAllAmericanBurger();
                    _order.Add(allosaurus);
                    DisplayDinoMenuItem(allosaurus);
                }
                else if (button.Name == "CarnotaurusCheeseburgerButton")
                {
                    CarnotaurusCheeseburger carnotaurus = new CarnotaurusCheeseburger();
                    _order.Add(carnotaurus);
                    DisplayDinoMenuItem(carnotaurus);
                }
                else if (button.Name == "DeinonychusDoubleButton")
                {
                    DeinonychusDouble deinonychus = new DeinonychusDouble();
                    _order.Add(deinonychus);
                    DisplayDinoMenuItem(deinonychus);

                }
                else if (button.Name == "TRexTripleButton")
                {
                    TRexTripleBurger trex = new TRexTripleBurger();
                    _order.Add(trex);
                    DisplayDinoMenuItem(trex);
                }
                else if (button.Name == "BrontowurstButton")
                {
                    Brontowurst brontowurst = new Brontowurst();
                    _order.Add(brontowurst);
                    DisplayDinoMenuItem(brontowurst);
                }
                else if (button.Name == "DinoNuggetsButton")
                {
                    DinoNuggets nuggets = new DinoNuggets();
                    _order.Add(nuggets);
                    DisplayDinoMenuItem(nuggets);
                }
                else if (button.Name == "PrehistoricPBJButton")
                {
                    PrehistoricPBJ prehistoricPBJ = new PrehistoricPBJ();
                    _order.Add(prehistoricPBJ);
                    DisplayDinoMenuItem(prehistoricPBJ);
                }
                else if (button.Name == "PterodactylWingsButton")
                {
                    PterodactylWings pterodactylWings = new PterodactylWings();
                    _order.Add(pterodactylWings);
                    DisplayDinoMenuItem(pterodactylWings);
                }
                else if (button.Name == "VelociWraptorButton")
                {
                    VelociWraptor velociWraptor = new VelociWraptor();
                    _order.Add(velociWraptor);
                    DisplayDinoMenuItem(velociWraptor);
                }
                else if (button.Name == "FryceritopsButton")
                {
                    Fryceritops fryceritops = new Fryceritops();
                    _order.Add(fryceritops);
                    DisplayDinoMenuItem(fryceritops);
                }
                else if (button.Name == "MeteorMacAndCheeseButton")
                {
                    MeteorMacAndCheese meteorMacAndCheese = new MeteorMacAndCheese();
                    _order.Add(meteorMacAndCheese);
                    DisplayDinoMenuItem(meteorMacAndCheese);
                }
                else if (button.Name == "MezzorellaSticksButton")
                {
                    MezzorellaSticks mezzorellaSticks = new MezzorellaSticks();
                    _order.Add(mezzorellaSticks);
                    DisplayDinoMenuItem(mezzorellaSticks);
                }
                else if (button.Name == "TriceritotsButton")
                {
                    Triceritots triceritots = new Triceritots();
                    _order.Add(triceritots);
                    DisplayDinoMenuItem(triceritots);
                }
                else if (button.Name == "PlilosodaButton")
                {
                    Plilosoda philosoda = new Plilosoda();
                    _order.Add(philosoda);
                    DisplayDinoMenuItem(philosoda);
                }
                else if (button.Name == "CretaceousCoffeeButton")
                {
                    CretaceousCoffee cretaceousCoffee = new CretaceousCoffee();
                    _order.Add(cretaceousCoffee);
                    DisplayDinoMenuItem(cretaceousCoffee);
                }

            }
        }

        /// <summary>
        /// Displays the given DinoMenuItem object in the proper menu control
        /// </summary>
        /// <param name="item">DinoMenuItem</param>
        private void DisplayDinoMenuItem(object item)
        {
            if (item is not DinoMenuItem) { return; }
            if (item is AllosaurusAllAmericanBurger allosaurus)//Start of Entrees
            {
                _currentItem = allosaurus;
                DisplayControl(new BurgerControl(allosaurus));
            }
            else if (item is CarnotaurusCheeseburger carnotaurus)
            {
                _currentItem = carnotaurus;
                DisplayControl(new BurgerControl(carnotaurus));
            }
            else if (item is DeinonychusDouble deinonychus)
            {
                _currentItem = deinonychus;
                DisplayControl(new BurgerControl(deinonychus));
            }
            else if (item is TRexTripleBurger trex)
            {
                _currentItem = trex;
                DisplayControl(new BurgerControl(trex));
            }
            else if (item is Brontowurst bronto)
            {
                _currentItem = bronto;
                DisplayControl(new BrontowurstControl(bronto));
            }
            else if (item is DinoNuggets nuggets)
            {
                _currentItem = nuggets;
                DisplayControl(new DinoNuggetsControl(nuggets));
            }
            else if (item is PrehistoricPBJ pbj)
            {
                _currentItem = pbj;
                DisplayControl(new PrehistoricPBJControl(pbj));
            }
            else if (item is PterodactylWings wings)
            {
                _currentItem = wings;
                DisplayControl(new PterodactylWingsControl(wings));
            }
            else if (item is VelociWraptor wrap)
            {
                _currentItem = wrap;
                DisplayControl(new VelociWraptorControl(wrap));
            }
            else if (item is Fryceritops fry) //Start of Sides
            {
                _currentItem = fry;
                DisplayControl(new FryceritopsControl(fry));
            }
            else if (item is MeteorMacAndCheese mac)
            {
                _currentItem = mac;
                DisplayControl(new MeteorMacAndCheeseControl(mac));
            }
            else if (item is MezzorellaSticks sticks)
            {
                _currentItem = sticks;
                DisplayControl(new MezzorellaSticksControl(sticks));
            }
            else if (item is Triceritots tots)
            {
                _currentItem = tots;
                DisplayControl(new TriceritotsControl(tots));
            }
            else if (item is CretaceousCoffee coffee) //Start of Drinks
            {
                _currentItem = coffee;
                DisplayControl(new CretaceousCoffeeControl(coffee));
            }
            else if (item is Plilosoda soda)
            {
                _currentItem = soda;
                DisplayControl(new PhilosodaControl(soda));
            }
            RemoveItemButton.IsEnabled = true;
            AddMoreItemsButton.IsEnabled = true;
        }

        /// <summary>
        /// Event Handler for the AddMoreItemsButton
        /// </summary>
        /// <param name="sender">Add More Item Button</param>
        /// <param name="e">Arguments</param>
        private void AddMoreItemsButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayMenu();
        }

        /// <summary>
        /// Event Handler For Removing an item
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Arguments</param>
        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentItem != null)
            {
                _order.Remove(_currentItem);
            }
            DisplayMenu();
        }

        /// <summary>
        /// Event Handler for when the order summary list selection is changed
        /// </summary>
        /// <param name="sender">List</param>
        /// <param name="e">Arguments</param>
        private void OnOrderItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                var item = e.AddedItems[0];
                if (item != null)
                {
                    DisplayDinoMenuItem(item);
                }
            }
        }

    }
}
