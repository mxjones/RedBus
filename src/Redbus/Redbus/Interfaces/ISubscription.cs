using Redbus.Events;

namespace Redbus.Interfaces
{
    public interface ISubscription
    {
        /// <summary>
        /// Token returned to the subscriber
        /// </summary>
        SubscriptionToken SubscriptionToken { get; }

        /// <summary>
        /// Publish to the subscriber
        /// </summary>
        /// <param name="eventBase"></param>
        void Publish(EventBase eventBase);
    }
}
