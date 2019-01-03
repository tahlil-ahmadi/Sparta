using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;
using Newtonsoft.Json;
using Sparta.Core.EventHandling;
using Syncs.QueryModelSync.Handlers;

namespace Syncs.QueryModelSync
{
    class Program
    {
        static void Main(string[] args)
        {
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

                var handler = new AuctionEventHandler();
                handler.Handle((dynamic)domainEvent);
            }
            return Task.CompletedTask;
        }
        private static void SubscriptionDropped(EventStoreSubscription arg1, SubscriptionDropReason arg2, Exception arg3)
        {
            Console.WriteLine("Subscription Dropped :(");
        }
    }
}
