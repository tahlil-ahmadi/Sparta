using System.Collections.Generic;
using System.Collections.ObjectModel;
using Sparta.Core.EventHandling;

namespace Sparta.Domain
{
    public abstract class EventSourcedAggregateRoot<TKey>
    {
        public TKey Id { get; protected set; }

        private List<DomainEvent> _changes;
        protected EventSourcedAggregateRoot()
        {
            this._changes = new List<DomainEvent>();
        }
        public void Publish<T>(T @event) where T: DomainEvent
        {
            this._changes.Add(@event);
        }
        public ReadOnlyCollection<DomainEvent> GetChanges()
        {
            return this._changes.AsReadOnly();
        }
        public void ClearChanges()
        {
            this._changes.Clear();
        }
        public abstract void Apply(DomainEvent @event);
    }
}
