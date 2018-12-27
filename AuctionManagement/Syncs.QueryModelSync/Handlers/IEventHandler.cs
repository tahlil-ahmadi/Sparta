using System.Collections.Generic;
using System.Text;
using Sparta.Domain;

namespace Syncs.QueryModelSync.Handlers
{
    public interface IEventHandler<T> where T : DomainEvent
    {
        void Handle(T @event);
    }
}
