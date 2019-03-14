using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.TestsUtil;
using FluentAssertions;
using TestStack.BDDfy;
using Xunit;

namespace AuctionManagement.Domain.Tests.Unit
{
    public class AuctionFirstBidTests
    {
        private Auction _auction;
        private StubClock _clock;
        private Action _placeBid;

        [Fact]
        public void should_throw_if_auction_has_ended()
        {
            this.Given(a => a.GivenThereIsAClosedAuction())
                .When(a => a.WhenITryToPlaceBidOnIt())
                .Then(a => a.ThenItShouldThrowException())
                .BDDfy();
        }

        private void GivenThereIsAClosedAuction()
        {
            _clock = new StubClock(new DateTime(2010, 10, 15));
            _auction = new AuctionTestBuilder()
                .WithEndDateTime(new DateTime(2010, 11, 15))
                .WithClock(_clock)
                .Build();
        }
        private void WhenITryToPlaceBidOnIt()
        {
            var bid = new Bid(2, 999999, _clock.Now());   //move to a factory (createValidBid);
            _clock.TimeTravelTo(new DateTime(2010, 11, 16));
            _placeBid =()=> this._auction.PlaceBid(bid, _clock);
        }
        private void ThenItShouldThrowException()
        {
            _placeBid.Should().Throw<Exception>();
        }
    }
}
