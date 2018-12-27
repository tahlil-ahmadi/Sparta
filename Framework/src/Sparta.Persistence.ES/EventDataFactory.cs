using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using Sparta.Core.EventHandling;
using Sparta.Domain;

namespace Sparta.Persistence.ES
{
    public static class EventDataFactory
    {
        public static EventData Create(DomainEvent @event)
        {
            var type = @event.GetType().AssemblyQualifiedName;
            var serialized = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));
            return new EventData(@event.EventId, type, true, serialized,null);
        }

        public static List<EventData> Create(IEnumerable<DomainEvent> events)
        {
            return events.Select(Create).ToList();
        }
    }
}
