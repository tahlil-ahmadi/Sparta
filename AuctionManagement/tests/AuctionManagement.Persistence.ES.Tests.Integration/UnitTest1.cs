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
            rep.Add(auction);


            //var rep = new AuctionRepository();
            //var id = Guid.Parse("7ca38e9b-c5aa-4171-8378-99c5fb87b47e");
            //var auction = rep.Get(id);
        }
    }

}
