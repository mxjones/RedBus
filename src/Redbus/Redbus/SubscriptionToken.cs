using System;

namespace Redbus
{
    /// <summary>
    /// A Token representing a Subscription
    /// </summary>
    public class SubscriptionToken
    {
        internal SubscriptionToken(Type eventItemType)
        {
            _uniqueTokenId = Guid.NewGuid();
            _eventItemType = eventItemType;
        }
        
        public Guid Token { get { return _uniqueTokenId; } }
        public Type EventItemType { get { return _eventItemType; } }

        private readonly Guid _uniqueTokenId;
        private readonly Type _eventItemType;
    }
}
