using System;
using Redbus.Events;
using Redbus.Interfaces;

namespace Redbus
{
    internal class Subscription<TEventBase> : ISubscription where TEventBase : EventBase
    {
        public SubscriptionToken SubscriptionToken { get; }

        public Subscription(Action<TEventBase> action, SubscriptionToken token)
        {
            _action = new WeakReference<Action<TEventBase>>(action ?? throw new ArgumentNullException(nameof(action)));
            SubscriptionToken = token ?? throw new ArgumentNullException(nameof(token));
        }

        public void Publish(EventBase eventItem)
        {
            if (!(eventItem is TEventBase))
                throw new ArgumentException("Event Item is not the correct type.");

            Action<TEventBase> action;
            if (_action.TryGetTarget(out action))
                action.Invoke(eventItem as TEventBase);
            else
                throw new SubscriptionExpiredException(this);
        }

        private readonly WeakReference<Action<TEventBase>> _action;
    }
}
