using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventAggregator.CoreBits.Interfaces;

namespace EventAggregator.CoreBits.Classes
{
    public class EventAggregatorClass : IEventAggregator
    {
        private readonly Dictionary<Type, List<WeakReference>> _eventSubscriberLists = new Dictionary<Type, List<WeakReference>>();
        private readonly object _lock = new object();

        public void Subscribe(object subscriber)
        {
            lock (_lock)
            {
                var subscriberTypes = subscriber.GetType().GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubscriber<>));
                var weakReference = new WeakReference(subscriber);
                foreach (var subscriberType in subscriberTypes)
                {
                    var subscribers = GetSubscribers(subscriberType);
                    subscribers.Add(weakReference);
                }
            }
        }
        public void Publish<TEvent>(TEvent eventToPublish)
        {
            var subscriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEvent));
            var subscribers = GetSubscribers(subscriberType);
            List<WeakReference> subscribersToRemove = new List<WeakReference>();

            foreach (var weakSubscriber in subscribers)
            {
                if (weakSubscriber.IsAlive)
                {
                    var subscriber = (ISubscriber<TEvent>)weakSubscriber.Target;
                    var syncContext = SynchronizationContext.Current;
                    if (syncContext == null)
                    {
                        syncContext = new SynchronizationContext();
                    }
                    syncContext.Post(s => subscriber.OnEvent(eventToPublish), null);
                }
                else
                {
                    subscribersToRemove.Add(weakSubscriber);
                }
            }

            if (subscribersToRemove.Any())
            {
                lock (_lock)
                {
                    foreach (var remove in subscribersToRemove)
                    {
                        subscribers.Remove(remove);
                    }
                }
            }
        }

        private List<WeakReference> GetSubscribers(Type subscriberType)
        {
            List<WeakReference> subscribers;
            lock (_lock)
            {
                //Note: Checking to see if the 'topic'/subscription type already exists
                var found = _eventSubscriberLists.TryGetValue(subscriberType, out subscribers);
                //Note: If the topic doesn't exists then we make a new list of references and create the entry in the dictionary
                if (!found)
                {
                    subscribers = new List<WeakReference>();
                    _eventSubscriberLists.Add(subscriberType, subscribers);
                }
            }
            return subscribers;
        }
    }
}
