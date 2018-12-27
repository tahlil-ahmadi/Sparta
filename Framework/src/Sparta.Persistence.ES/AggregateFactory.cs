using System;
using System.Collections.Generic;
using Sparta.Core.EventHandling;
using Sparta.Domain;

namespace Sparta.Persistence.ES
{
    public static class AggregateFactory
    {
        public static T Create<T,TKey>(List<DomainEvent> domainEvents) 
            where T : EventSourcedAggregateRoot<TKey>
        {
            var entity = (T)Activator.CreateInstance(typeof(T), true);
            domainEvents.ForEach(a=> entity.Apply(a));
            return entity;
        }
    }
}
