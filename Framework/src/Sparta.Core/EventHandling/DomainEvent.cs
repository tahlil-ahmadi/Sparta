using System;

namespace Sparta.Core.EventHandling
{
    public abstract class DomainEvent : IEvent
    {
        public Guid EventId { get; }
        public DateTime EventCreateDateTime { get; private set; }
        protected DomainEvent()
        {
            this.EventId = Guid.NewGuid();
            this.EventCreateDateTime = DateTime.Now;
        }

    }
}
