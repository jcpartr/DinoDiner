using System.Collections.Specialized;
using Xunit.Sdk;

namespace DataTest
{
    /// <summary>
    /// Custom Testing functions
    /// </summary>
    public static class CustomAssert
    {
        /// <summary>
        /// Code is from Testing Custom Events
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="newItem"></param>
        /// <param name="testCode"></param>
        /// <exception cref="NotifyCollectionChangedWrongActionException"></exception>
        /// <exception cref="NotifyCollectionChangedAddException"></exception>
        /// <exception cref="NotifyCollectionChangedNotTriggeredException"></exception>
        public static void NotifyCollectionChangedAdd<T>(INotifyCollectionChanged collection, T newItem, Action testCode)
        {
            // A flag to indicate if the event triggered successfully
            bool notifySucceeded = false;

            // An event handler to attach to the INotifyCollectionChanged and be 
            // notified when the Add event occurs.
            NotifyCollectionChangedEventHandler handler = (sender, args) =>
            {
                // Make sure the event is an Add event
                if (args.Action != NotifyCollectionChangedAction.Add)
                {
                    throw new NotifyCollectionChangedWrongActionException(NotifyCollectionChangedAction.Add, args.Action);
                }

                // Make sure we added just one item
                if (args.NewItems?.Count != 1)
                {
                    // We'll use the collection of added items as the second argument
                    throw new NotifyCollectionChangedAddException(newItem, args.NewItems);
                }

                // Make sure the added item is what we expected
                if (!args.NewItems[0].Equals(newItem))
                {
                    // Here we only have one item in the changed collection, so we'll report it directly
                    throw new NotifyCollectionChangedAddException(newItem, args.NewItems[0]);
                }

                // If we reach this point, the NotifyCollectionChanged event was triggered successfully
                // and contains the correct item! We'll set the flag to true so we know.
                notifySucceeded = true;
            };

            // Now we connect the event handler 
            collection.CollectionChanged += handler;

            // And attempt to trigger the event by running the actionCode
            // We place this in a try/catch to be able to utilize the finally 
            // clause, but don't actually catch any exceptions
            try
            {
                testCode();
                // After this code has been run, our handler should have 
                // triggered, and if all went well, the notifySucceed is true
                if (!notifySucceeded)
                {
                    // If notifySucceed is false, the event was not triggered
                    // We throw an exception denoting that
                    throw new NotifyCollectionChangedNotTriggeredException(NotifyCollectionChangedAction.Add);
                }
            }
            // We don't actually want to catch an exception - we want it to 
            // bubble up and be reported as a failing test.  So we don't 
            // have a catch () {} clause to this try/catch.
            finally
            {
                // However, we *do* want to remove the event handler. We do 
                // this in a finally block so it will happen even if we do 
                // have an exception occur. 
                collection.CollectionChanged -= handler;
            }
        }

        public static void NotifyCollectionChangedRemove<T>(INotifyCollectionChanged collection, T oldItem, Action testCode)
        {
            // A flag to indicate if the event triggered successfully
            bool notifySucceeded = false;

            // An event handler to attach to the INotifyCollectionChanged and be 
            // notified when the Remove event occurs.
            NotifyCollectionChangedEventHandler handler = (sender, args) =>
            {
                // Make sure the event is an Remove event
                if (args.Action != NotifyCollectionChangedAction.Remove)
                {
                    throw new NotifyCollectionChangedWrongActionException(NotifyCollectionChangedAction.Remove, args.Action);
                }

                // Make sure we removed just one item
                if (args.OldItems?.Count != 1)
                {
                    // We'll use the collection of added items as the second argument
                    throw new NotifyCollectionChangedAddException(oldItem, args.OldItems);
                }

                // Make sure the added item is what we expected
                if (!args.OldItems[0].Equals(oldItem))
                {
                    // Here we only have one item in the changed collection, so we'll report it directly
                    throw new NotifyCollectionChangedAddException(oldItem, args.OldItems[0]);
                }

                // If we reach this point, the NotifyCollectionChanged event was triggered successfully
                // and contains the correct item! We'll set the flag to true so we know.
                notifySucceeded = true;
            };

            // Now we connect the event handler 
            collection.CollectionChanged += handler;

            // And attempt to trigger the event by running the actionCode
            // We place this in a try/catch to be able to utilize the finally 
            // clause, but don't actually catch any exceptions
            try
            {
                testCode();
                // After this code has been run, our handler should have 
                // triggered, and if all went well, the notifySucceed is true
                if (!notifySucceeded)
                {
                    // If notifySucceed is false, the event was not triggered
                    // We throw an exception denoting that
                    throw new NotifyCollectionChangedNotTriggeredException(NotifyCollectionChangedAction.Remove);
                }
            }
            // We don't actually want to catch an exception - we want it to 
            // bubble up and be reported as a failing test.  So we don't 
            // have a catch () {} clause to this try/catch.
            finally
            {
                // However, we *do* want to remove the event handler. We do 
                // this in a finally block so it will happen even if we do 
                // have an exception occur. 
                collection.CollectionChanged -= handler;
            }
        }

        public class NotifyCollectionChangedNotTriggeredException : XunitException
        {
            public NotifyCollectionChangedNotTriggeredException(NotifyCollectionChangedAction expectedAction) : base($"Expected a NotifyCollectionChanged event with an action of {expectedAction} to be invoked, but saw none.") { }
        }

        public class NotifyCollectionChangedWrongActionException : XunitException
        {
            public NotifyCollectionChangedWrongActionException(NotifyCollectionChangedAction expectedAction, NotifyCollectionChangedAction actualAction) : base($"Expected a NotifyCollectionChanged event with an action of {expectedAction} to be invoked, but saw {actualAction}") { }
        }

        public class NotifyCollectionChangedAddException : XunitException
        {
            public NotifyCollectionChangedAddException(object expected, object actual) : base($"Expected a NotifyCollectionChanged event with an action of Add and object {expected} but instead saw {actual}") { }
        }

        public class NotifyCollectionChangedRemoveException : XunitException
        {
            public NotifyCollectionChangedRemoveException(object expectedItem, int expectedIndex, object actualItem, int actualIndex) : base($"Expected a NotifyCollectionChanged event with an action of Remove and object {expectedItem} at index {expectedIndex} but instead saw {actualItem} at index  {actualIndex}") { }
        }




    }
}
