using System;

namespace Sparta.Core.EventHandling
{
    public class BaseEvent : IEvent
    {
        public Guid EventId { get; protected set; }
       
    }
}