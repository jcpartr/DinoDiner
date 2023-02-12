using DinoDiner.PointOfSale.PaymentControls;
using PointOfSale;
using RoundRegister;
using System.Diagnostics;
using System.Reflection;

namespace PointOfSaleUnitTests
{
    /// <summary>
    /// Unit Tests for CashDrawerProcessor
    /// </summary>
    public class CashDrawerProcessorUnitTests
    {
        /// <summary>
        /// Helper Function for summing the total amount paid
        /// </summary>
        /// <param name="processor">CashDrawerProcessor</param>
        /// <returns>Total Amount Paid</returns>
        private static decimal CalculateTotalPaid(CashDrawerProcessor processor)
        {
            decimal sum = 0m;
            sum += processor.PaidHundreds * 100;
            sum += processor.PaidFifties * 50;
            sum += processor.PaidTwenties * 20;
            sum += processor.PaidTens * 10;
            sum += processor.PaidFives * 5;
            sum += processor.PaidTwos * 2;
            sum += processor.PaidOnes * 1;
            sum += processor.PaidDollarCoins * 1;
            sum += processor.PaidHalfDollarCoins * .5m;
            sum += processor.PaidQuarters * .25m;
            sum += processor.PaidDimes *.10m;
            sum += processor.PaidNickles * .05m;
            sum += processor.PaidPennies * .01m;
            return sum;
        } 
        

        /// <summary>
        /// Tests if the default drawer values are correct
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor","")]
        public void DrawerShouldHaveCorrectDefaultValues()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.Equal(12.5m, processor.Price);
            Assert.Equal((uint)0, processor.DrawerHundreds);
            Assert.Equal((uint)0, processor.DrawerFifties);
            Assert.Equal((uint)4, processor.DrawerTwenties);
            Assert.Equal((uint)10, processor.DrawerTens);
            Assert.Equal((uint)8, processor.DrawerFives);
            Assert.Equal((uint)0, processor.DrawerTwos);
            Assert.Equal((uint)20, processor.DrawerOnes);
            Assert.Equal((uint)0, processor.DrawerDollarCoins);
            Assert.Equal((uint)0, processor.DrawerHalfDollarCoins);
            Assert.Equal((uint)80, processor.DrawerQuarters);
            Assert.Equal((uint)100, processor.DrawerDimes);
            Assert.Equal((uint)80, processor.DrawerNickles);
            Assert.Equal((uint)100, processor.DrawerPennies);
        }

        /// <summary>
        /// Checks if ChangeOwed is the correct amount if overpaid
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="paidHundreds">Num Hundreds Paid</param>
        /// <param name="paidFifties">Num Fifties Paid</param>
        /// <param name="paidTwenties">Num Twenties Paid</param>
        /// <param name="paidTens">Num Tens Paid</param>
        /// <param name="paidFives">Num Fives Paid</param>
        /// <param name="paidTwos">Num Twos Paid</param>
        /// <param name="paidOnes">Num Ones Paid</param>
        /// <param name="paidDollarCoins">Num DollarCoins Paid</param>
        /// <param name="paidHalfDollarCoins">Num HalfDollarcoins Paid</param>
        /// <param name="paidQuarters">Num Quarters Paid</param>
        /// <param name="paidDimes">Num Dimes Paid</param>
        /// <param name="paidNickles">Num Nickles Paid</param>
        /// <param name="paidPennies">Num Pennies Paid</param>
        [Theory]
        [Trait("CashDrawerProcessor", "")]
        [InlineData(12.5, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [InlineData(12.5, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [InlineData(12.5, 15, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [InlineData(12.5, 0, 0, 0, 0, 0, 2, 3, 0, 0, 0, 0, 0, 0)]

        public void ChangeShouldBeCorrect(double price, uint paidHundreds, uint paidFifties, uint paidTwenties, uint paidTens, 
            uint paidFives, uint paidTwos, uint paidOnes, uint paidDollarCoins, uint paidHalfDollarCoins, uint paidQuarters, 
            uint paidDimes, uint paidNickles, uint paidPennies)
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new((decimal)price)
            {
                PaidHundreds = paidHundreds,
                PaidFifties = paidFifties,
                PaidTwenties = paidTwenties,
                PaidTens = paidTens,
                PaidFives = paidFives,
                PaidTwos = paidTwos,
                PaidOnes = paidOnes,
                PaidDollarCoins = paidDollarCoins,
                PaidHalfDollarCoins = paidHalfDollarCoins,
                PaidQuarters = paidQuarters,
                PaidDimes = paidDimes,
                PaidNickles = paidNickles,
                PaidPennies = paidPennies
            };
            decimal changeDue = CalculateTotalPaid(processor) - (decimal)price;

            if (changeDue < 0) { changeDue = 0m; }

            Assert.Equal(changeDue, processor.ChangeOwed);
        }


        /// <summary>
        /// Tests if the calculated total paid is right
        /// </summary>
        /// <param name="paidHundreds">Num Hundreds Paid</param>
        /// <param name="paidFifties">Num Fifties Paid</param>
        /// <param name="paidTwenties">Num Twenties Paid</param>
        /// <param name="paidTens">Num Tens Paid</param>
        /// <param name="paidFives">Num Fives Paid</param>
        /// <param name="paidTwos">Num Twos Paid</param>
        /// <param name="paidOnes">Num Ones Paid</param>
        /// <param name="paidDollarCoins">Num DollarCoins Paid</param>
        /// <param name="paidHalfDollarCoins">Num HalfDollarcoins Paid</param>
        /// <param name="paidQuarters">Num Quarters Paid</param>
        /// <param name="paidDimes">Num Dimes Paid</param>
        /// <param name="paidNickles">Num Nickles Paid</param>
        /// <param name="paidPennies">Num Pennies Paid</param>
        [Theory]
        [Trait("CashDrawerProcessor", "")]
        [InlineData(0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [InlineData(0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [InlineData(15, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [InlineData(0, 0, 0, 0, 0, 2, 3, 0, 0, 0, 0, 0, 0)]
        public void TotalPaidShouldBeCorrect(uint paidHundreds, uint paidFifties, uint paidTwenties, uint paidTens,
            uint paidFives, uint paidTwos, uint paidOnes, uint paidDollarCoins, uint paidHalfDollarCoins, uint paidQuarters,
            uint paidDimes, uint paidNickles, uint paidPennies)
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(0.0m)
            {
                PaidHundreds = paidHundreds,
                PaidFifties = paidFifties,
                PaidTwenties = paidTwenties,
                PaidTens = paidTens,
                PaidFives = paidFives,
                PaidTwos = paidTwos,
                PaidOnes = paidOnes,
                PaidDollarCoins = paidDollarCoins,
                PaidHalfDollarCoins = paidHalfDollarCoins,
                PaidQuarters = paidQuarters,
                PaidDimes = paidDimes,
                PaidNickles = paidNickles,
                PaidPennies = paidPennies
            };
            Assert.Equal(CalculateTotalPaid(processor), processor.CalculatePaidTotal());
        }

        /// <summary>
        /// Checks if change amounts are correct on a new register
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="paidHundreds">Num Hundred Paid</param>
        /// <param name="paidFifties">Num Fifties Paid</param>
        /// <param name="paidTwenties">Num Twenties Paid</param>
        /// <param name="paidTens">Num Tens Paid</param>
        /// <param name="paidFives">Num Fives Paid</param>
        /// <param name="paidTwos">Num Twos Paid</param>
        /// <param name="paidOnes">Num Ones Paid</param>
        /// <param name="paidDollarCoins">Num DollarCoins Paid</param>
        /// <param name="paidHalfDollarCoins">Num HalfDollarCoins Paid</param>
        /// <param name="paidQuarters">Num Quarters Paid</param>
        /// <param name="paidDimes">Num Dimes Paid</param>
        /// <param name="paidNickles">Num Nickles Paid</param>
        /// <param name="paidPennies">Num Pennies Paid</param>
        /// <param name="expectedHundreds">Num Hundreds Expected</param>
        /// <param name="expectedFifties">Num Fifties Expected</param>
        /// <param name="expectedTwenties">Num Twenties Expected</param>
        /// <param name="expectedTens">Num Tens Expected</param>
        /// <param name="expectedFives">Num Fives Expected</param>
        /// <param name="expectedTwos">Num Twos Expected</param>
        /// <param name="expectedOnes">Num Ones Expected</param>
        /// <param name="expectedDollarCoins">Num DollarCoins Expected</param>
        /// <param name="expectedHalfDollarCoins">Num HalfDollarCoins Expected</param>
        /// <param name="expectedQuarters">Num Quarters Expected</param>
        /// <param name="expectedDimes">Num Dimes Expected</param>
        /// <param name="expectedNickles">Num Nickles Expected</param>
        /// <param name="expectedPennies">Num Pennies Expected</param>
        [Theory]
        [Trait("CashDrawerProcessor", "")]
        [InlineData( 
            /*Price*/ 0.0,
            /*paidHundreds*/0, /*paidFifties*/0, /*paidTwenties*/0, /*paidTens*/0, /*paidFives*/0, /*paidTwos*/0, /*paidOnes*/0, /*paidDollarCoins*/0, /*paidHalfDollarCoins*/0, /*paidQuarters*/0, /*paidDimes*/0, /*paidNickles*/0, /*paidPennies*/0,
            /*expectedHundreds*/0, /*expectedFifties*/0, /*expectedTwenties*/0, /*expectedTens*/0, /*expectedFives*/0, /*expectedTwos*/0, /*expectedOnes*/0, /*expectedDollarCoins*/0, /*expectedHalfDollarCoins*/0, /*expectedQuarters*/0, /*expectedDimes*/0, /*expectedNickles*/0, /*expectedPennies*/0
            )]
        //23.50 Different Payment Amounts
        [InlineData(
            /*Price*/ 23.50,
            /*paidHundreds*/0, /*paidFifties*/0, /*paidTwenties*/0, /*paidTens*/2, /*paidFives*/1, /*paidTwos*/0, /*paidOnes*/0, /*paidDollarCoins*/0, /*paidHalfDollarCoins*/0, /*paidQuarters*/0, /*paidDimes*/0, /*paidNickles*/0, /*paidPennies*/0,
            /*expectedHundreds*/0, /*expectedFifties*/0, /*expectedTwenties*/0, /*expectedTens*/0, /*expectedFives*/0, /*expectedTwos*/0, /*expectedOnes*/1, /*expectedDollarCoins*/0, /*expectedHalfDollarCoins*/0, /*expectedQuarters*/2, /*expectedDimes*/0, /*expectedNickles*/0, /*expectedPennies*/0
            )]
        [InlineData(
            /*Price*/ 23.50,
            /*paidHundreds*/0, /*paidFifties*/0, /*paidTwenties*/1, /*paidTens*/0, /*paidFives*/1, /*paidTwos*/0, /*paidOnes*/0, /*paidDollarCoins*/0, /*paidHalfDollarCoins*/0, /*paidQuarters*/0, /*paidDimes*/0, /*paidNickles*/0, /*paidPennies*/0,
            /*expectedHundreds*/0, /*expectedFifties*/0, /*expectedTwenties*/0, /*expectedTens*/0, /*expectedFives*/0, /*expectedTwos*/0, /*expectedOnes*/1, /*expectedDollarCoins*/0, /*expectedHalfDollarCoins*/0, /*expectedQuarters*/2, /*expectedDimes*/0, /*expectedNickles*/0, /*expectedPennies*/0
            )]
        [InlineData(
            /*Price*/ 23.50,
            /*paidHundreds*/0, /*paidFifties*/1, /*paidTwenties*/0, /*paidTens*/0, /*paidFives*/0, /*paidTwos*/0, /*paidOnes*/0, /*paidDollarCoins*/0, /*paidHalfDollarCoins*/0, /*paidQuarters*/0, /*paidDimes*/0, /*paidNickles*/0, /*paidPennies*/0,
            /*expectedHundreds*/0, /*expectedFifties*/0, /*expectedTwenties*/1, /*expectedTens*/0, /*expectedFives*/1, /*expectedTwos*/0, /*expectedOnes*/1, /*expectedDollarCoins*/0, /*expectedHalfDollarCoins*/0, /*expectedQuarters*/2, /*expectedDimes*/0, /*expectedNickles*/0, /*expectedPennies*/0
            )]
        [InlineData(
            /*Price*/ 23.50,
            /*paidHundreds*/1, /*paidFifties*/0, /*paidTwenties*/0, /*paidTens*/0, /*paidFives*/0, /*paidTwos*/0, /*paidOnes*/0, /*paidDollarCoins*/0, /*paidHalfDollarCoins*/0, /*paidQuarters*/0, /*paidDimes*/0, /*paidNickles*/0, /*paidPennies*/0,
            /*expectedHundreds*/0, /*expectedFifties*/0, /*expectedTwenties*/3, /*expectedTens*/1, /*expectedFives*/1, /*expectedTwos*/0, /*expectedOnes*/1, /*expectedDollarCoins*/0, /*expectedHalfDollarCoins*/0, /*expectedQuarters*/2, /*expectedDimes*/0, /*expectedNickles*/0, /*expectedPennies*/0
            )]
        public void ChangeAmountsShouldBeCorrect(
            float price,
            uint paidHundreds, uint paidFifties, uint paidTwenties, uint paidTens, uint paidFives, uint paidTwos, uint paidOnes, uint paidDollarCoins, uint paidHalfDollarCoins, uint paidQuarters, uint paidDimes, uint paidNickles, uint paidPennies,
            uint expectedHundreds, uint expectedFifties, uint expectedTwenties, uint expectedTens, uint expectedFives, uint expectedTwos, uint expectedOnes, uint expectedDollarCoins, uint expectedHalfDollarCoins, uint expectedQuarters, uint expectedDimes, uint expectedNickles, uint expectedPennies
            )
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new((decimal)price)
            {
                PaidHundreds = paidHundreds,
                PaidFifties = paidFifties,
                PaidTwenties = paidTwenties,
                PaidTens = paidTens,
                PaidFives = paidFives,
                PaidTwos = paidTwos,
                PaidOnes = paidOnes,
                PaidDollarCoins = paidDollarCoins,
                PaidHalfDollarCoins = paidHalfDollarCoins,
                PaidQuarters = paidQuarters,
                PaidDimes = paidDimes,
                PaidNickles = paidNickles,
                PaidPennies = paidPennies
            };
            Assert.Equal(processor.ChangeHundreds, expectedHundreds);
            Assert.Equal(processor.ChangeFifties, expectedFifties);
            Assert.Equal(processor.ChangeTwenties, expectedTwenties);
            Assert.Equal(processor.ChangeTens, expectedTens);
            Assert.Equal(processor.ChangeFives, expectedFives);
            Assert.Equal(processor.ChangeTwos, expectedTwos);
            Assert.Equal(processor.ChangeOnes, expectedOnes);
            Assert.Equal(processor.ChangeDollarCoins, expectedDollarCoins);
            Assert.Equal(processor.ChangeHalfDollarCoins, expectedHalfDollarCoins);
            Assert.Equal(processor.ChangeQuarters, expectedQuarters);
            Assert.Equal(processor.ChangeDimes, expectedDimes);
            Assert.Equal(processor.ChangeNickles, expectedNickles);
            Assert.Equal(processor.ChangePennies, expectedPennies);
        }

        /// <summary>
        /// Tests if change amounts skip types that are empty in the drawer
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "")]
        public void ChangeAmountsShouldSkipEmptyDrawers()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.59m)
            {
                PaidHundreds = 1,
                PaidFifties = 1
            };
            Assert.Equal((uint)4, processor.ChangeTwenties);
            Assert.Equal((uint)5, processor.ChangeTens);
            Assert.Equal((uint)1, processor.ChangeFives);
            Assert.Equal((uint)2, processor.ChangeOnes);
            Assert.Equal((uint)1, processor.ChangeQuarters);
            Assert.Equal((uint)1, processor.ChangeDimes);
            Assert.Equal((uint)1, processor.ChangeNickles);
            Assert.Equal((uint)1, processor.ChangePennies);
        }

        /// <summary>
        /// Checks if Finalize Works
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "")]
        public void FinalizeShouldWork()
        {
            //Setup
            CashDrawer.Reset();
            //Sample Transaction
            CashDrawerProcessor processor = new(15.39m)
            {
                PaidTwenties = 1
            };
            processor.FinalizeTransaction();
            //Assert Drawer Amounts are correct
            //Change should be $4.61 or 4 Dollars, 2 Quarters, 1 Dime, 1 Penny
            Assert.Equal(5u, processor.DrawerTwenties); //Twenties should be 4 + 1
            Assert.Equal(16u, processor.DrawerOnes); //Ones should be 20 - 4
            Assert.Equal(78u, processor.DrawerQuarters); //Quarters should be 80 - 2
            Assert.Equal(99u, processor.DrawerDimes); //Dimes should be 100 - 1
            Assert.Equal(99u, processor.DrawerPennies); //Pennies should be 100 - 1 

        }


        //Paid Property Events
        /// <summary>
        /// Tests if PaidHundreds changing notifies the correct Property Changes
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Paid Property")]
        public void PaidHundredsShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "PaidHundreds", () => { processor.PaidHundreds++; });
            Assert.PropertyChanged(processor, "AmountDue", () => { processor.PaidHundreds++; });
            Assert.PropertyChanged(processor, "ChangeOwed", () => { processor.PaidHundreds++; });
        }

        /// <summary>
        /// Tests if PaidFifties changing notifies the correct Property Changes
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Paid Property")]
        public void PaidFiftiesShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "PaidFifties", () => { processor.PaidFifties++; });
            Assert.PropertyChanged(processor, "AmountDue", () => { processor.PaidFifties++; });
            Assert.PropertyChanged(processor, "ChangeOwed", () => { processor.PaidFifties++; });
        }

        /// <summary>
        /// Tests if PaidTwenties changing notifies the correct Property Changes
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Paid Property")]
        public void PaidTwentiesShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "PaidTwenties", () => { processor.PaidTwenties++; });
            Assert.PropertyChanged(processor, "AmountDue", () => { processor.PaidTwenties++; });
            Assert.PropertyChanged(processor, "ChangeOwed", () => { processor.PaidTwenties++; });
        }

        /// <summary>
        /// Tests if PaidTens changing notifies the correct Property Changes
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Paid Property")]
        public void PaidTensShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "PaidTens", () => { processor.PaidTens++; });
            Assert.PropertyChanged(processor, "AmountDue", () => { processor.PaidTens++; });
            Assert.PropertyChanged(processor, "ChangeOwed", () => { processor.PaidTens++; });
        }

        /// <summary>
        /// Tests if PaidFives changing notifies the correct Property Changes
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Paid Property")]
        public void PaidFivesShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "PaidFives", () => { processor.PaidFives++; });
            Assert.PropertyChanged(processor, "AmountDue", () => { processor.PaidFives++; });
            Assert.PropertyChanged(processor, "ChangeOwed", () => { processor.PaidFives++; });
        }

        /// <summary>
        /// Tests if PaidTwos changing notifies the correct Property Changes
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Paid Property")]
        public void PaidTwosShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "PaidTwos", () => { processor.PaidTwos++; });
            Assert.PropertyChanged(processor, "AmountDue", () => { processor.PaidTwos++; });
            Assert.PropertyChanged(processor, "ChangeOwed", () => { processor.PaidTwos++; });
        }

        /// <summary>
        /// Tests if PaidOnes changing notifies the correct Property Changes
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Paid Property")]
        public void PaidOnesShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "PaidOnes", () => { processor.PaidOnes++; });
            Assert.PropertyChanged(processor, "AmountDue", () => { processor.PaidOnes++; });
            Assert.PropertyChanged(processor, "ChangeOwed", () => { processor.PaidOnes++; });
        }

        /// <summary>
        /// Tests if PaidDollarCoins changing notifies the correct Property Changes
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Paid Property")]
        public void PaidDollarCoinsShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "PaidDollarCoins", () => { processor.PaidDollarCoins++; });
            Assert.PropertyChanged(processor, "AmountDue", () => { processor.PaidDollarCoins++; });
            Assert.PropertyChanged(processor, "ChangeOwed", () => { processor.PaidDollarCoins++; });
        }

        /// <summary>
        /// Tests if PaidHalfDollarCoins changing notifies the correct Property Changes
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Paid Property")]
        public void PaidHalfDollarCoinsShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "PaidHalfDollarCoins", () => { processor.PaidHalfDollarCoins++; });
            Assert.PropertyChanged(processor, "AmountDue", () => { processor.PaidHalfDollarCoins++; });
            Assert.PropertyChanged(processor, "ChangeOwed", () => { processor.PaidHalfDollarCoins++; });
        }

        /// <summary>
        /// Tests if PaidQuarters changing notifies the correct Property Changes
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Paid Property")]
        public void PaidQuartersShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "PaidQuarters", () => { processor.PaidQuarters++; });
            Assert.PropertyChanged(processor, "AmountDue", () => { processor.PaidQuarters++; });
            Assert.PropertyChanged(processor, "ChangeOwed", () => { processor.PaidQuarters++; });
        }
        
        /// <summary>
        /// Tests if PaidDimes changing notifies the correct Property Changes
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Paid Property")]
        public void PaidDimesShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "PaidDimes", () => { processor.PaidDimes++; });
            Assert.PropertyChanged(processor, "AmountDue", () => { processor.PaidDimes++; });
            Assert.PropertyChanged(processor, "ChangeOwed", () => { processor.PaidDimes++; });
        }

        /// <summary>
        /// Tests if PaidNickles changing notifies the correct Property Changes
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Paid Property")]
        public void PaidNicklesShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "PaidNickles", () => { processor.PaidNickles++; });
            Assert.PropertyChanged(processor, "AmountDue", () => { processor.PaidNickles++; });
            Assert.PropertyChanged(processor, "ChangeOwed", () => { processor.PaidNickles++; });
        }

        /// <summary>
        /// Tests if PaidPennies changing notifies the correct Property Changes
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Paid Property")]
        public void PaidPenniesShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "PaidPennies", () => { processor.PaidPennies++; });
            Assert.PropertyChanged(processor, "AmountDue", () => { processor.PaidPennies++; });
            Assert.PropertyChanged(processor, "ChangeOwed", () => { processor.PaidPennies++; });
        }

        //Change Amounts Property Changes
        /// <summary>
        /// Tests if ChangeHundreds notifies the correct Property Change Event
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Change Property")]
        public void ChangeHundredsShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "ChangeHundreds", () => { processor.ChangeHundreds++; });
        }

        /// <summary>
        /// Tests if ChangeFifties notifies the correct Property Change Event
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Change Property")]
        public void ChangeFiftiesShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "ChangeFifties", () => { processor.ChangeFifties++; });
        }

        /// <summary>
        /// Tests if ChangeTwenties notifies the correct Property Change Event
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Change Property")]
        public void ChangeTwentiesShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "ChangeTwenties", () => { processor.ChangeTwenties++; });
        }

        /// <summary>
        /// Tests if ChangeTens notifies the correct Property Change Event
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Change Property")]
        public void ChangeTensShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "ChangeTens", () => { processor.ChangeTens++; });
        }

        /// <summary>
        /// Tests if ChangeFives notifies the correct Property Change Event
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Change Property")]
        public void ChangeFivesShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "ChangeFives", () => { processor.ChangeFives++; });
        }

        /// <summary>
        /// Tests if ChangeTwos notifies the correct Property Change Event
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Change Property")]
        public void ChangeTwosShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "ChangeTwos", () => { processor.ChangeTwos++; });
        }

        /// <summary>
        /// Tests if ChangeOnes notifies the correct Property Change Event
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Change Property")]
        public void ChangeOnesShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "ChangeOnes", () => { processor.ChangeOnes++; });
        }

        /// <summary>
        /// Tests if ChangeDollarCoins notifies the correct Property Change Event
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Change Property")]
        public void ChangeDollarCoinsShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "ChangeDollarCoins", () => { processor.ChangeDollarCoins++; });
        }

        /// <summary>
        /// Tests if ChangeHalfDollarCoins notifies the correct Property Change Event
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Change Property")]
        public void ChangeHalfDollarCoinsShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "ChangeHalfDollarCoins", () => { processor.ChangeHalfDollarCoins++; });
        }

        /// <summary>
        /// Tests if ChangeQuarters notifies the correct Property Change Event
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Change Property")]
        public void ChangeQuartersShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "ChangeQuarters", () => { processor.ChangeQuarters++; });
        }

        /// <summary>
        /// Tests if ChangeDimes notifies the correct Property Change Event
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Change Property")]
        public void ChangeDimesShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "ChangeDimes", () => { processor.ChangeDimes++; });
        }

        /// <summary>
        /// Tests if ChangeNickles notifies the correct Property Change Event
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Change Property")]
        public void ChangeNicklesShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "ChangeNickles", () => { processor.ChangeNickles++; });
        }

        /// <summary>
        /// Tests if ChangePennies notifies the correct Property Change Event
        /// </summary>
        [Fact]
        [Trait("CashDrawerProcessor", "Change Property")]
        public void ChangePenniesShouldNotifyPropertyChanged()
        {
            CashDrawer.Reset();
            CashDrawerProcessor processor = new(12.5m);
            Assert.PropertyChanged(processor, "ChangePennies", () => { processor.ChangePennies++; });
        }
    }
}