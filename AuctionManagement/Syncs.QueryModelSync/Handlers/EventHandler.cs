using System;
using AuctionManagement.Domain.Contracts.Auctions;
using MongoDB.Driver;
using Sparta.Domain;
using Syncs.QueryModelSync.QueryModel;

namespace Syncs.QueryModelSync.Handlers
{
    public class AuctionEventHandler
    {
        public void Handle(AuctionOpened @event)
        {
            var collection = GetCollection();
            var auction = new Auction()
            {
                Id = @event.Id,
                Product = new SellingProduct()
                {
                    CategoryId = @event.ProductCategoryId,
                    CategoryName = "Something !",    //should be loaded,
                    Name = @event.ProductName
                },
                EndDateTime = @event.EndDateTime
            };
            collection.InsertOne(auction);
        }

        public void Handle(BidPlaced @event)
        {
        }

        private static IMongoCollection<Auction> GetCollection()
        {
            //TODO: refactor this codes
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("AuctionManagementQuery");
            var collection = db.GetCollection<Auction>("Auctions");
            return collection;
        }
    }
}