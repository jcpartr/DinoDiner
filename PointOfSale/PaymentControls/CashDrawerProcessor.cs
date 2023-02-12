using RoundRegister;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Navigation;

namespace DinoDiner.PointOfSale.PaymentControls
{
    /// <summary>
    /// Class to act as the ModelView for the CashDrawer from RoundRegister
    /// </summary>
    public class CashDrawerProcessor : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        
        /// <summary>
        /// Event Helper function to be called when a property changes in any sub classes
        /// </summary>
        /// <param name="propertyName">Name of the property exact case</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Event Helper for when any of the Paid Monies Amounts change
        /// </summary>
        /// <param name="propertyName">Name of the Property Throwing events</param>
        private void OnPaidPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
            OnPropertyChanged(nameof(AmountDue));
            OnPropertyChanged(nameof(ChangeOwed));
            CalculateChange();
        }
        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="Price"></param>
        public CashDrawerProcessor(decimal price)
        {
            Price = Math.Round(price, 2);
        }
        
        /// <summary>
        /// Calculates the total amount paid by the customer
        /// </summary>
        /// <returns>Decimal Of Total Amount Paid</returns>
        public decimal CalculatePaidTotal()
        {
            //Start Sum at 0
            decimal sum = 0m;
            //Add all quantities of monies times the respective values
            //Bills
            sum += PaidHundreds * 100m;
            sum += PaidFifties * 50m;
            sum += PaidTwenties * 20m;
            sum += PaidTens * 10m;
            sum += PaidFives * 5m;
            sum += PaidTwos * 2m;
            sum += PaidOnes * 1m;
            //Coins
            sum += PaidDollarCoins * 1m;
            sum += PaidHalfDollarCoins * .5m;
            sum += PaidQuarters * .25m;
            sum += PaidDimes * .1m;
            sum += PaidNickles * .05m;
            sum += PaidPennies * .01m;
            //Return that sum
            return sum;
        }
        /// <summary>
        /// Calculates the optimal change distribution
        /// </summary>
        private void CalculateChange()
        {
            decimal change = ChangeOwed;

            uint desiredAmount;

            //Each stage checks if there is enough of that type of money
            //in the drawer and calculates based on that
            //100s
            desiredAmount = (uint)Math.Floor(change / 100);
            if (desiredAmount < DrawerHundreds)
            {
                ChangeHundreds = desiredAmount;
            } else
            {
                ChangeHundreds = DrawerHundreds;
            }
            change -= ChangeHundreds * 100;
            //50s
            desiredAmount = (uint)Math.Floor(change / 50);
            if (desiredAmount < DrawerFifties)
            {
                ChangeFifties = desiredAmount;
            }
            else
            {
                ChangeFifties = DrawerFifties;
            }
            change -= ChangeFifties * 50;
            //20s
            desiredAmount = (uint)Math.Floor(change / 20);
            if (desiredAmount < DrawerTwenties)
            {
                ChangeTwenties = desiredAmount;
            }
            else
            {
                ChangeTwenties = DrawerTwenties;
            }
            change -= ChangeTwenties * 20;
            //10s
            desiredAmount = (uint)Math.Floor(change / 10);
            if (desiredAmount < DrawerTens)
            {
                ChangeTens = desiredAmount;
            }
            else
            {
                ChangeTens = DrawerTens;
            }
            change -= ChangeTens * 10;
            //5s
            desiredAmount = (uint)Math.Floor(change / 5);
            if (desiredAmount < DrawerFives)
            {
                ChangeFives = desiredAmount;
            }
            else
            {
                ChangeFives = DrawerFives;
            }
            change -= ChangeFives * 5;
            //2s
            desiredAmount = (uint)Math.Floor(change / 2);
            if (desiredAmount < DrawerTwos)
            {
                ChangeTwos = desiredAmount;
            }
            else
            {
                ChangeTwos = DrawerTwos;
            }
            change -= ChangeTwos * 2;
            //1s
            desiredAmount = (uint)Math.Floor(change / 1);
            if (desiredAmount < DrawerOnes)
            {
                ChangeOnes = desiredAmount;
            }
            else
            {
                ChangeOnes = DrawerOnes;
            }
            change -= ChangeOnes * 1;
            //Coins
            //DollarCoins
            desiredAmount = (uint)Math.Floor(change / 1);
            if (desiredAmount < DrawerDollarCoins)
            {
                ChangeDollarCoins = desiredAmount;
            }
            else
            {
                ChangeDollarCoins = DrawerDollarCoins;
            }
            change -= ChangeDollarCoins * 1;
            //HalfDollarCoins
            desiredAmount = (uint)Math.Floor(change / .5m);
            if (desiredAmount < DrawerHalfDollarCoins)
            {
                ChangeHalfDollarCoins = desiredAmount;
            }
            else
            {
                ChangeHalfDollarCoins = DrawerHalfDollarCoins;
            }
            change -= ChangeHalfDollarCoins * .5m;
            //Quarters
            desiredAmount = (uint)Math.Floor(change / .25m);
            if (desiredAmount < DrawerQuarters)
            {
                ChangeQuarters = desiredAmount;
            }
            else
            {
                ChangeQuarters = DrawerQuarters;
            }
            change -= ChangeQuarters * .25m;
            //Dimes
            desiredAmount = (uint)Math.Floor(change / .10m);
            if (desiredAmount < DrawerDimes)
            {
                ChangeDimes = desiredAmount;
            }
            else
            {
                ChangeDimes = DrawerDimes;
            }
            change -= ChangeDimes * .10m;
            //Nickles
            desiredAmount = (uint)Math.Floor(change / .05m);
            if (desiredAmount < DrawerNickles)
            {
                ChangeNickles = desiredAmount;
            }
            else
            {
                ChangeNickles = DrawerNickles;
            }
            change -= ChangeNickles * .05m;
            //Pennies
            desiredAmount = (uint)Math.Floor(change / .01m);
            if (desiredAmount < DrawerPennies)
            {
                ChangePennies = desiredAmount;
            }
            else
            {
                ChangePennies = DrawerPennies;
            }
            change -= ChangePennies * .05m;

            if(change > 0) 
            {
                MessageBox.Show("Not enough change in drawer!!!" +
                    "\n$" + change.ToString() + " in change left");
            }

        }

        /// <summary>
        /// Finalizes the transaction and adds paid monies and subtracts change monies
        /// </summary>
        public void FinalizeTransaction()
        {
            CashDrawer.Open();
            //Hundreds
            DrawerHundreds += PaidHundreds;
            DrawerHundreds -= ChangeHundreds;
            //Fifties
            DrawerFifties += PaidFifties;
            DrawerFifties -= ChangeFifties;
            //Twenties
            DrawerTwenties += PaidTwenties;
            DrawerTwenties -= ChangeTwenties;
            //Tens
            DrawerTens += PaidTens;
            DrawerTens -= ChangeTens;
            //Fives
            DrawerFives += PaidFives;
            DrawerFives -= ChangeFives;
            //Twos
            DrawerTwos += PaidTwos;
            DrawerTwos -= ChangeTwos;
            //Ones
            DrawerOnes += PaidOnes;
            DrawerOnes -= ChangeOnes;
            //Dollarcoins
            DrawerDollarCoins += PaidDollarCoins;
            DrawerDollarCoins -= ChangeDollarCoins;
            //HalfDollarCoins
            DrawerHalfDollarCoins += PaidHalfDollarCoins;
            DrawerHalfDollarCoins -= ChangeHalfDollarCoins;
            //Quarters
            DrawerQuarters += PaidQuarters;
            DrawerQuarters -= ChangeQuarters;
            //Dimes
            DrawerDimes += PaidDimes;
            DrawerDimes -= ChangeDimes;
            //Nickles
            DrawerNickles += PaidNickles;
            DrawerNickles -= ChangeNickles;
            //Pennies
            DrawerPennies += PaidPennies;
            DrawerPennies -= ChangePennies;
        }
        
        /// <summary>
        /// Price of the transaction
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Amount Left To Be Paid
        /// </summary>
        public decimal AmountDue { 
            get 
            {
                decimal amtDue = Price - CalculatePaidTotal();
                if (amtDue > 0) { return amtDue; }
                else { return 0.00m; }
                
            } 
        }

        /// <summary>
        /// Amount To Be Given Back
        /// </summary>
        public decimal ChangeOwed {
            get
            {
                decimal change = CalculatePaidTotal() - Price;
                if (change > 0)
                {
                    return change;
                }
                else return 0.0m;
            }
        }

        //Hundreds
        /// <summary>
        /// Number of Hundred Dollar Bills in the Drawer
        /// </summary>
        public uint DrawerHundreds
        {
            get
            {
                return CashDrawer.Hundreds;
            }
            set
            {
                CashDrawer.Hundreds = value;
                OnPropertyChanged(nameof(DrawerHundreds));
            }
        }

        /// <summary>
        /// Number of Hundreds given by customer
        /// </summary>
        public uint PaidHundreds
        {
            get => _paidHundreds;
            set
            {
                _paidHundreds = value;
                OnPaidPropertyChanged(nameof(PaidHundreds));
            }
        }
        /// <summary>
        /// Private Variable for PaidHundreds
        /// </summary>
        private uint _paidHundreds;
        
        /// <summary>
        /// Number of Hundreds to give back to customer
        /// </summary>
        public uint ChangeHundreds
        {
            get => _changeHundreds;
            set
            {
                if (value != _changeHundreds)
                {
                    _changeHundreds = value;
                    OnPropertyChanged(nameof(ChangeHundreds));
                }
            }
        }

        /// <summary>
        /// Private Variable for ChangeHundreds
        /// </summary>
        private uint _changeHundreds;

        //Fifties
        /// <summary>
        /// Number of Fifty Dollar Bills in the Drawer
        /// </summary>
        public uint DrawerFifties
        {
            get => CashDrawer.Fifties;
            set
            {
                CashDrawer.Fifties = value;
                OnPropertyChanged(nameof(DrawerFifties));
            }
        }

        /// <summary>
        /// Number of Fifties given by customer
        /// </summary>
        public uint PaidFifties
        {
            get => _paidFifties;
            set
            {
                _paidFifties = value;
                OnPaidPropertyChanged(nameof(PaidFifties));
            }
        }
        /// <summary>
        /// Private Variable for PaidFifties
        /// </summary>
        private uint _paidFifties;

        /// <summary>
        /// Number of Fifties to give back to customer
        /// </summary>
        public uint ChangeFifties
        {
            get => _changeFifties;
            set
            {
                if (value != _changeFifties)
                {
                    _changeFifties = value;
                    OnPropertyChanged(nameof(ChangeFifties));
                }
            }
        }

        /// <summary>
        /// Private Variable for ChangeFifties
        /// </summary>
        private uint _changeFifties;
        
        //Twenties
        /// <summary>
        /// Number of Twenties in the Drawer
        /// </summary>
        public uint DrawerTwenties
        {
            get => CashDrawer.Twenties;
            set
            {
                CashDrawer.Twenties = value;
                OnPropertyChanged(nameof(DrawerTwenties));
            }
        }

        /// <summary>
        /// Number of Twenties given by customer
        /// </summary>
        public uint PaidTwenties
        {
            get => _paidTwenties;
            set
            {
                _paidTwenties = value;
                OnPaidPropertyChanged(nameof(PaidTwenties));
            }
        }
        /// <summary>
        /// Private Variable for PaidTwenties
        /// </summary>
        private uint _paidTwenties;

        /// <summary>
        /// Number of Twenties to give back to customer
        /// </summary>
        public uint ChangeTwenties
        {
            get => _changeTwenties;
            set
            {
                if (value != _changeTwenties)
                {
                    _changeTwenties = value;
                    OnPropertyChanged(nameof(ChangeTwenties));
                }
            }
        }

        /// <summary>
        /// Private Variable for ChangeTwenties
        /// </summary>
        private uint _changeTwenties;

        //Tens
        /// <summary>
        /// Number of Tens in the Drawer
        /// </summary>
        public uint DrawerTens
        {
            get => CashDrawer.Tens;
            set
            {
                CashDrawer.Tens = value;
                OnPropertyChanged(nameof(DrawerTens));
            }
        }

        /// <summary>
        /// Number of Tens given by customer
        /// </summary>
        public uint PaidTens
        {
            get => _paidTens;
            set
            {
                _paidTens = value;
                OnPaidPropertyChanged(nameof(PaidTens));
            }
        }
        /// <summary>
        /// Private Variable for PaidTens
        /// </summary>
        private uint _paidTens;

        /// <summary>
        /// Number of Tens to give back to customer
        /// </summary>
        public uint ChangeTens
        {
            get => _changeTens;
            set
            {
                if (value != _changeTens)
                {
                    _changeTens = value;
                    OnPropertyChanged(nameof(ChangeTens));
                }
            }
        }

        /// <summary>
        /// Private Variable for ChangeTens
        /// </summary>
        private uint _changeTens;

        //Fives
        /// <summary>
        /// Number of Fives in the Drawer
        /// </summary>
        public uint DrawerFives
        {
            get => CashDrawer.Fives;
            set
            {
                CashDrawer.Fives = value;
                OnPropertyChanged(nameof(DrawerFives));
            }
        }

        /// <summary>
        /// Number of Fives given by customer
        /// </summary>
        public uint PaidFives
        {
            get => _paidFives;
            set
            {
                _paidFives = value;
                OnPaidPropertyChanged(nameof(PaidFives));
            }
        }
        /// <summary>
        /// Private Variable for PaidFives
        /// </summary>
        private uint _paidFives;

        /// <summary>
        /// Number of Fives to give back to customer
        /// </summary>
        public uint ChangeFives
        {
            get => _changeFives;
            set
            {
                if (value != _changeFives)
                {
                    _changeFives = value;
                    OnPropertyChanged(nameof(ChangeFives));
                }
            }
        }

        /// <summary>
        /// Private Variable for ChangeFives
        /// </summary>
        private uint _changeFives;

        //Twos
        /// <summary>
        /// Number of Twos in the Drawer
        /// </summary>
        public uint DrawerTwos
        {
            get => CashDrawer.Twos;
            set
            {
                CashDrawer.Twos = value;
                OnPropertyChanged(nameof(DrawerTwos));
            }
        }

        /// <summary>
        /// Number of Twos given by customer
        /// </summary>
        public uint PaidTwos
        {
            get => _paidTwos;
            set
            {
                _paidTwos = value;
                OnPaidPropertyChanged(nameof(PaidTwos));
            }
        }
        /// <summary>
        /// Private Variable for PaidTwos
        /// </summary>
        private uint _paidTwos;

        /// <summary>
        /// Number of Twos to give back to customer
        /// </summary>
        public uint ChangeTwos
        {
            get => _changeTwos;
            set
            {
                if (value != _changeTwos)
                {
                    _changeTwos = value;
                    OnPropertyChanged(nameof(ChangeTwos));
                }
            }
        }

        /// <summary>
        /// Private Variable for ChangeTwos
        /// </summary>
        private uint _changeTwos;

        //Ones
        /// <summary>
        /// Number of Ones in the Drawer
        /// </summary>
        public uint DrawerOnes
        {
            get => CashDrawer.Ones;
            set
            {
                CashDrawer.Ones = value;
                OnPropertyChanged(nameof(DrawerOnes));
            }
        }

        /// <summary>
        /// Number of Ones given by customer
        /// </summary>
        public uint PaidOnes
        {
            get => _paidOnes;
            set
            {
                _paidOnes = value;
                OnPaidPropertyChanged(nameof(PaidOnes));
            }
        }
        /// <summary>
        /// Private Variable for PaidOnes
        /// </summary>
        private uint _paidOnes;

        /// <summary>
        /// Number of Ones to give back to customer
        /// </summary>
        public uint ChangeOnes
        {
            get => _changeOnes;
            set
            {
                if (value != _changeOnes)
                {
                    _changeOnes = value;
                    OnPropertyChanged(nameof(ChangeOnes));
                }
            }
        }

        /// <summary>
        /// Private Variable for ChangeOnes
        /// </summary>
        private uint _changeOnes;

        //DollarCoins
        /// <summary>
        /// Number of DollarCoins in the Drawer
        /// </summary>
        public uint DrawerDollarCoins
        {
            get => CashDrawer.DollarCoins;
            set
            {
                CashDrawer.DollarCoins = value;
                OnPropertyChanged(nameof(DrawerDollarCoins));
            }
        }

        /// <summary>
        /// Number of DollarCoins given by customer
        /// </summary>
        public uint PaidDollarCoins
        {
            get => _paidDollarCoins;
            set
            {
                _paidDollarCoins = value;
                OnPaidPropertyChanged(nameof(PaidDollarCoins));
            }
        }
        /// <summary>
        /// Private Variable for PaidDollarCoins
        /// </summary>
        private uint _paidDollarCoins;

        /// <summary>
        /// Number of DollarCoins to give back to customer
        /// </summary>
        public uint ChangeDollarCoins
        {
            get => _changeDollarCoins;
            set
            {
                if (value != _changeDollarCoins)
                {
                    _changeDollarCoins = value;
                    OnPropertyChanged(nameof(ChangeDollarCoins));
                }
            }
        }

        /// <summary>
        /// Private Variable for ChangeDollarCoins
        /// </summary>
        private uint _changeDollarCoins;

        //HalfDollarCoins
        /// <summary>
        /// Number of HalfDollarCoins in the Drawer
        /// </summary>
        public uint DrawerHalfDollarCoins
        {
            get => CashDrawer.HalfDollarCoins;
            set
            {
                CashDrawer.HalfDollarCoins = value;
                OnPropertyChanged(nameof(DrawerHalfDollarCoins));
            }
        }

        /// <summary>
        /// Number of HalfDollarCoins given by customer
        /// </summary>
        public uint PaidHalfDollarCoins
        {
            get => _paidHalfDollarCoins;
            set
            {
                _paidHalfDollarCoins = value;
                OnPaidPropertyChanged(nameof(PaidHalfDollarCoins));
            }
        }
        /// <summary>
        /// Private Variable for PaidHalfDollarCoins
        /// </summary>
        private uint _paidHalfDollarCoins;

        /// <summary>
        /// Number of HalfDollarCoins to give back to customer
        /// </summary>
        public uint ChangeHalfDollarCoins
        {
            get => _changeHalfDollarCoins;
            set
            {
                if (value != _changeHalfDollarCoins)
                {
                    _changeHalfDollarCoins = value;
                    OnPropertyChanged(nameof(ChangeHalfDollarCoins));
                }
            }
        }

        /// <summary>
        /// Private Variable for ChangeHalfDollarCoins
        /// </summary>
        private uint _changeHalfDollarCoins;

        //Quarters
        /// <summary>
        /// Number of Quarters in the Drawer
        /// </summary>
        public uint DrawerQuarters
        {
            get => CashDrawer.Quarters;
            set
            {
                CashDrawer.Quarters = value;
                OnPropertyChanged(nameof(DrawerQuarters));
            }
        }

        /// <summary>
        /// Number of Quarters given by customer
        /// </summary>
        public uint PaidQuarters
        {
            get => _paidQuarters;
            set
            {
                _paidQuarters = value;
                OnPaidPropertyChanged(nameof(PaidQuarters));
            }
        }
        /// <summary>
        /// Private Variable for PaidQuarters
        /// </summary>
        private uint _paidQuarters;

        /// <summary>
        /// Number of Quarters to give back to customer
        /// </summary>
        public uint ChangeQuarters
        {
            get => _changeQuarters;
            set
            {
                if (value != _changeQuarters)
                {
                    _changeQuarters = value;
                    OnPropertyChanged(nameof(ChangeQuarters));
                }
            }
        }

        /// <summary>
        /// Private Variable for ChangeQuarters
        /// </summary>
        private uint _changeQuarters;

        //Dimes
        /// <summary>
        /// Number of Dimes in the Drawer
        /// </summary>
        public uint DrawerDimes
        {
            get => CashDrawer.Dimes;
            set
            {
                CashDrawer.Dimes = value;
                OnPropertyChanged(nameof(DrawerDimes));
            }
        }

        /// <summary>
        /// Number of Dimes given by customer
        /// </summary>
        public uint PaidDimes
        {
            get => _paidDimes;
            set
            {
                _paidDimes = value;
                OnPaidPropertyChanged(nameof(PaidDimes));
            }
        }
        /// <summary>
        /// Private Variable for PaidDimes
        /// </summary>
        private uint _paidDimes;

        /// <summary>
        /// Number of Dimes to give back to customer
        /// </summary>
        public uint ChangeDimes
        {
            get => _changeDimes;
            set
            {
                if (value != _changeDimes)
                {
                    _changeDimes = value;
                    OnPropertyChanged(nameof(ChangeDimes));
                }
            }
        }

        /// <summary>
        /// Private Variable for ChangeDimes
        /// </summary>
        private uint _changeDimes;

        //Nickles
        /// <summary>
        /// Number of Nickles in the Drawer
        /// </summary>
        public uint DrawerNickles
        {
            get => CashDrawer.Nickles;
            set
            {
                CashDrawer.Nickles = value;
                OnPropertyChanged(nameof(DrawerNickles));
            }
        }

        /// <summary>
        /// Number of Nickles given by customer
        /// </summary>
        public uint PaidNickles
        {
            get => _paidNickles;
            set
            {
                _paidNickles = value;
                OnPaidPropertyChanged(nameof(PaidNickles));
            }
        }
        /// <summary>
        /// Private Variable for PaidNickles
        /// </summary>
        private uint _paidNickles;

        /// <summary>
        /// Number of Nickles to give back to customer
        /// </summary>
        public uint ChangeNickles
        {
            get => _changeNickles;
            set
            {
                if (value != _changeNickles)
                {
                    _changeNickles = value;
                    OnPropertyChanged(nameof(ChangeNickles));
                }
            }
        }

        /// <summary>
        /// Private Variable for ChangeNickles
        /// </summary>
        private uint _changeNickles;

        //Pennies
        /// <summary>
        /// Number of Pennies in the Drawer
        /// </summary>
        public uint DrawerPennies
        {
            get => CashDrawer.Pennies;
            set
            {
                CashDrawer.Pennies = value;
                OnPropertyChanged(nameof(DrawerPennies));
            }
        }

        /// <summary>
        /// Number of Pennies given by customer
        /// </summary>
        public uint PaidPennies
        {
            get => _paidPennies;
            set
            {
                _paidPennies = value;
                OnPaidPropertyChanged(nameof(PaidPennies));
            }
        }
        /// <summary>
        /// Private Variable for PaidPennies
        /// </summary>
        private uint _paidPennies;

        /// <summary>
        /// Number of Pennies to give back to customer
        /// </summary>
        public uint ChangePennies
        {
            get => _changePennies;
            set
            {
                if (value != _changePennies)
                {
                    _changePennies = value;
                    OnPropertyChanged(nameof(ChangePennies));
                }
            }
        }

        /// <summary>
        /// Private Variable for ChangePennies
        /// </summary>
        private uint _changePennies;
    }
}
