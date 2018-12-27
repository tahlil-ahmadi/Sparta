using System.Net;
using EventStore.ClientAPI;
using Sparta.Domain;

namespace Sparta.Persistence.ES
{
    public abstract class EventSourcedRepository<TKey, TAggregate>
                    where TAggregate : EventSourcedAggregateRoot<TKey>
    {
        public TAggregate GetById(TKey id)
        {
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            connection.ConnectAsync().Wait();
            var stream = GetStreamName(id);
            var streamEvents = connection.ReadStreamEventsForwardAsync(stream, 0, 4096, false).Result;
            var domainEvents = DomainEventFactory.Create(streamEvents.Events);
            return AggregateFactory.Create<TAggregate,TKey>(domainEvents);
        }

        public void Add(TAggregate aggregate)
        {
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            connection.ConnectAsync().Wait();

            var changes = aggregate.GetChanges();
            var eventData = EventDataFactory.Create(changes);
            var streamName = GetStreamName(aggregate.Id);

            connection.AppendToStreamAsync(streamName, ExpectedVersion.Any, eventData).Wait();
        }

        private string GetStreamName(TKey id)
        {
            return $"{typeof(TAggregate).Name}-{id}";
        }
    }
}
