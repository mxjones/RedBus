using Redbus.Interfaces;
using System;

namespace Redbus
{
    internal class SubscriptionExpiredException : Exception
    {
        public ISubscription Subscription { get; }

        public SubscriptionExpiredException(ISubscription subscription) : base()
        {
            Subscription = subscription;
        }
    }
}
