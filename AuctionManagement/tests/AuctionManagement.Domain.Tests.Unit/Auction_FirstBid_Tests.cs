using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Model.Auctions.Exceptions;
using AuctionManagement.Domain.TestsUtil;
using FluentAssertions;
using Xunit;

namespace AuctionManagement.Domain.Tests.Unit
{
    public class Auction_FirstBid_Tests
    {
        [Fact]
        public void should_throw_if_bid_amount_is_bigger_than_starting_price()
        {
            var auction = new AuctionTestBuilder().WithStartingPrice(1000).Build();
            var bid = new Bid(10, 900, DateTime.Now);

            Action placeBid = ()=> auction.PlaceBid(bid, new StubClock());

            placeBid.Should().Throw<InvalidBidException>();
        }

        [Fact]
        public void should_throw_if_auction_has_ended()
        {
            var clock = new StubClock(new DateTime(2010,10,15));
            var auction =new AuctionTestBuilder()
                                .WithEndDateTime(new DateTime(2010,11, 15))
                                .WithClock(clock)
                                .Build();
            var bid = new Bid(2,999999, clock.Now());   //move to a factory (createValidBid);
            clock.TimeTravelTo(new DateTime(2010, 11, 16));

            Action placeBid = () => auction.PlaceBid(bid, clock);

            placeBid.Should().Throw<InvalidAuctionStateException>();
        }
    }
}
