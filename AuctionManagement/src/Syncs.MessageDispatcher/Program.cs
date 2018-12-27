using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Contracts.Auctions;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;
using Newtonsoft.Json;
using NServiceBus;
using Sparta.Core.EventHandling;
using Task = System.Threading.Tasks.Task;

namespace Syncs.MessageDispatcher
{
    class Program
    {
        private static IEndpointInstance endpoint;
        static void Main(string[] args)
        {
            endpoint = EndpointFactory.Create();

            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            connection.ConnectAsync().Wait();
            var credentials = new UserCredentials("admin", "changeit");
            connection.SubscribeToAllAsync(false, EventAppeared, SubscriptionDropped, credentials).Wait();

            Console.WriteLine("Subscription started !");
            Console.ReadLine();
        }
        private static Task EventAppeared(EventStoreSubscription arg1, ResolvedEvent resolvedEvent)
        {
            var type = Type.GetType(resolvedEvent.Event.EventType);
            if (type != null && typeof(DomainEvent).IsAssignableFrom(type))
            {
                var json = Encoding.UTF8.GetString(resolvedEvent.Event.Data);
                var domainEvent = JsonConvert.DeserializeObject(json, type);

                endpoint.Publish(domainEvent).Wait();
                Console.WriteLine("Event dispatched on bus !");
                Console.WriteLine("=====================================");
            }
            return Task.CompletedTask;
        }
        private static void SubscriptionDropped(EventStoreSubscription arg1, SubscriptionDropReason arg2, Exception arg3)
        {
            Console.WriteLine("Subscription Dropped :(");
        }
    }
}
