using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redbus.Events
{
    /// <summary>
    /// Generic event with payload
    /// </summary>
    public class PayloadEvent<TPayload> : EventBase
    {
        /// <summary>
        /// The Payload for this event
        /// </summary>
        public TPayload Payload { get; protected set; }

        public PayloadEvent(TPayload payload)
        {
            Payload = payload;
        }
    }
}
