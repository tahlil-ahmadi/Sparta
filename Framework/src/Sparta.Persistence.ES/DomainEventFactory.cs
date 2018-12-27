using System;
using System.Collections.Generic;
using System.Text;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using Sparta.Core.EventHandling;
using Sparta.Domain;

namespace Sparta.Persistence.ES
{
    public static class DomainEventFactory
    {
        public static List<DomainEvent> Create(ResolvedEvent[] events)
        {
            var domainEvents = new List<DomainEvent>();
            foreach (var @event in events)
            {
                var data = Encoding.UTF8.GetString(@event.Event.Data);
                var type = Type.GetType(@event.Event.EventType);

                var instance = JsonConvert.DeserializeObject(data, type) as DomainEvent;
                domainEvents.Add(instance);
            }
            return domainEvents;
        }
    }
}
