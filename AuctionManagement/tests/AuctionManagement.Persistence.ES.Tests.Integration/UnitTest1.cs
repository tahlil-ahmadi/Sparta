using System;
using AuctionManagement.Domain;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Model.Participants;
using AuctionManagement.Domain.TestsUtil;
using Xunit;

namespace AuctionManagement.Persistence.ES.Tests.Integration
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var clock = new StubClock();

            var rep = new AuctionRepository();
            var auction = new Auction(new Participant(10, "Jack"), new SellingProduct(1, "Black Shoes"), 10000, DateTime.Now.AddDays(7), clock);
            auction.PlaceBid(new Bid(2, 11000, DateTime.Now), clock);
            auction.PlaceBid(new Bid(2, 12000, DateTime.Now), clock);
            rep.Add(auction);


        }
    }

}
