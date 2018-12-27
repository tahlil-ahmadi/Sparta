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

            Action placeBid = ()=> auction.PlaceBid(bid);

            placeBid.Should().Throw<InvalidBidException>();
        }
    }
}
