using System;
using AuctionManagement.Domain.Model.Auctions;
using Xunit;

namespace AuctionManagement.Persistence.ES.Tests.Integration
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var rep = new AuctionRepository();
            var auction = new Auction(10, new SellingProduct(1, "Black Shoes"), 10000, DateTime.Now.AddDays(7));
            auction.PlaceBid(new Bid(2, 11000, DateTime.Now));
            auction.PlaceBid(new Bid(2, 12000, DateTime.Now));

            rep.Add(auction);


            //var rep = new AuctionRepository();
            //var id = Guid.Parse("7ca38e9b-c5aa-4171-8378-99c5fb87b47e");
            //var auction = rep.GetById(id);
        }
    }
}
