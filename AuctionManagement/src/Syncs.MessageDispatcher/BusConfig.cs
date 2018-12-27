using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using Sparta.Core.EventHandling;

namespace Syncs.MessageDispatcher
{
    public static class EndpointFactory
    {
        public static IEndpointInstance Create()
        {
            var config = new EndpointConfiguration("AuctionManagement.Dispatcher");
            config.SendFailedMessagesTo("AuctionManagement.Dispatcher.error");
            config.UseTransport<MsmqTransport>();
            config.UsePersistence<InMemoryPersistence>();
            config.EnableInstallers();
            config.Conventions().DefiningEventsAs(a => typeof(DomainEvent).IsAssignableFrom(a));
            return Endpoint.Start(config).Result;
        }
    }
}
