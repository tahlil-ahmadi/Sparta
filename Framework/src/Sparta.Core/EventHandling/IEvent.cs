using System;

namespace Sparta.Core.EventHandling
{
    public interface IEvent
    {
        Guid EventId { get; }
    }
}
