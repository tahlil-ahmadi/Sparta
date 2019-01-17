using System;
using System.Collections.Generic;
using System.Text;
using Sparta.Core.EventHandling;
using Sparta.Domain;

namespace AuctionManagement.Domain.Model.Participants
{
    public class Participant: EventSourcedAggregateRoot<int>
    {
        public string Name { get; private set; }
        public Participant(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public override void Apply(DomainEvent @event) { }
    }
}
