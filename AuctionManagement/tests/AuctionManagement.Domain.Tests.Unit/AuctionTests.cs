using System;
using AuctionManagement.Domain.Model.Auctions.Exceptions;
using AuctionManagement.Domain.TestsUtil;
using FluentAssertions;
using Xunit;

namespace AuctionManagement.Domain.Tests.Unit
{
    public class AuctionTests
    {
        [Fact]
        public void should_be_constructed_properly()
        {
            var builder = new AuctionTestBuilder();

            var auction = builder.Build();

            auction.Id.Should().NotBeEmpty();
            auction.SellerId.Should().Be(builder.SellerId);
            auction.Product.Should().BeEquivalentTo(builder.Product);
            auction.StartingPrice.Should().Be(builder.StartingPrice);
            auction.EndDateTime.Should().Be(builder.EndDateTime);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void should_throw_when_starting_price_is_not_valid(int startingPrice)
        {
            var builder = new AuctionTestBuilder().WithStartingPrice(startingPrice);

            Action constructor = () => builder.Build();

            constructor.Should().Throw<InvalidStartingPriceException>();
        }

        [Fact]
        public void should_throw_when_end_date_is_past()
        {
            var builder = new AuctionTestBuilder().WithSomePastEndDate();

            Action constructor = () => builder.Build();

            constructor.Should().Throw<PastEndDateException>();
        }
    }
}
