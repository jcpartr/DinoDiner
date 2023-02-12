using DinoDiner.Data;
using System.Collections.Specialized;

namespace DataTest
{
    /// <summary>
    /// Unit Tests for Order.cs
    /// </summary>
    public class OrderUnitTests
    {
        /// <summary>
        /// Tests if Order implements INotifyCollectionChanged
        /// </summary>
        [Fact]
        [Trait("Order", "")]
        public void ShouldImplementINotifyCollectionChangedInterface()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyCollectionChanged>(order);
        }

        /// <summary>
        /// Tests if Order implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        [Trait("Order", "")]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }

        /// <summary>
        /// Checks if Putting A Menu Item into Order Works
        /// </summary>
        [Fact]
        [Trait("Order", "")]
        public void AddingItemToOrderShouldPutItemInOrder()
        {
            Order order = new Order();
            DinoMenuItem test = new AllosaurusAllAmericanBurger();
            order.Add(test);
            Assert.Contains(test, order);
        }

        /// <summary>
        /// Checks if removing an item works
        /// </summary>
        [Fact]
        [Trait("Order", "")]
        public void RemovingItemFromOrderShouldRemoveIt()
        {
            Order order = new Order();
            DinoMenuItem test = new AllosaurusAllAmericanBurger();
            order.Add(test);
            Assert.Contains(test, order);
            order.Remove(test);
            Assert.DoesNotContain(test, order);
        }

        /// <summary>
        /// Checks if a collection changed event is triggered when an item is added
        /// </summary>
        [Fact]
        [Trait("Order", "")]
        public void AddingAnItemShouldTriggerACollectionChangedEvent()
        {
            Order order = new Order();

            DinoMenuItem test = new AllosaurusAllAmericanBurger();

            CustomAssert.NotifyCollectionChangedAdd(order, test, () =>
            {
                order.Add(test);
            });
        }

        /// <summary>
        /// Checks if a collection changed event is triggered when an item is removed
        /// </summary>
        [Fact]
        [Trait("Order", "")]
        public void RemovingAnItemShouldTriggerACollectionChangedEvent()
        {
            Order order = new Order();
            DinoMenuItem test = new AllosaurusAllAmericanBurger();
            order.Add(test);
            CustomAssert.NotifyCollectionChangedRemove(order, test, () =>
            {
                order.Remove(test);
            });
        }

        /// <summary>
        /// Checks if order number updates
        /// </summary>
        [Fact]
        [Trait("Order", "")]
        public void CreatingMultipleOrderShouldUpdateNumber()
        {
            Order order1 = new Order();
            uint num1 = order1.Number;
            Order order2 = new Order();
            uint num2 = order2.Number;
            Assert.Equal(num1 + 1, num2);
        }

    }
}
