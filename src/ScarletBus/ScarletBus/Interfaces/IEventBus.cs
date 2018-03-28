using System;
using Redbus.Events;

namespace Redbus.Interfaces
{
    /// <summary>
    /// Defines an interface to subscribe and publish events
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// Subscribes to the specified event type with the specified action
        /// </summary>
        /// <typeparam name="TEventBase">The type of event</typeparam>
        /// <param name="action">The Action to invoke when an event of this type is published</param>
        /// <returns>A <see cref="SubscriptionToken"/> to be used when calling <see cref="Unsubscribe"/></returns>
        SubscriptionToken Subscribe<TEventBase>(Action<TEventBase> action) where TEventBase : EventBase;

        /// <summary>
        /// Unsubscribe from the Event type related to the specified <see cref="SubscriptionToken"/>
        /// </summary>
        /// <param name="token">The <see cref="SubscriptionToken"/> received from calling the Subscribe method</param>
        void Unsubscribe(SubscriptionToken token);

        /// <summary>
        /// Publishes the specified event to any subscribers for the <see cref="TEventBase"/> event type
        /// </summary>
        /// <typeparam name="TEventBase">The type of event</typeparam>
        /// <param name="eventItem">Event to publish</param>
        void Publish<TEventBase>(TEventBase eventItem) where TEventBase : EventBase;

        /// <summary>
        /// Publishes the specified event to any subscribers for the <see cref="TEventBase"/> event type asychronously
        /// </summary>
        /// <remarks> This is a wrapper call around the synchronous  method as this method is naturally synchronous (CPU Bound) </remarks>
        /// <typeparam name="TEventBase">The type of event</typeparam>
        /// <param name="eventItem">Event to publish</param>
        void PublishAsync<TEventBase>(TEventBase eventItem) where TEventBase : EventBase;

        /// <summary>
        /// Publishes the specified event to any subscribers for the <see cref="TEventBase"/> event type asychronously
        /// and 
        /// </summary>
        /// <remarks> This is a wrapper call around the synchronous  method as this method is naturally synchronous (CPU Bound) </remarks>
        /// <typeparam name="TEventBase">The type of event</typeparam>
        /// <param name="eventItem">Event to publish</param>
        /// <param name="callback"><see cref="AsyncCallback"/> that is called on completion</param>
        void PublishAsync<TEventBase>(TEventBase eventItem, AsyncCallback callback) where TEventBase : EventBase;
    }
}
