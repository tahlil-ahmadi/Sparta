using System;
using AuctionManagement.Domain.Model.Auctions;

namespace AuctionManagement.Domain.TestsUtil
{
    public class AuctionTestBuilder
    {
        public int SellerId { get; private set; }
        public SellingProduct Product { get; private set; }
        public int StartingPrice { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public AuctionTestBuilder()
        {
            this.Product = new SellingProduct(2,"X");
            this.SellerId = 3;
            this.EndDateTime = DateTime.Now.AddDays(7);
            this.StartingPrice = 1000;
        }

        public AuctionTestBuilder WithStartingPrice(int startingPrice)
        {
            this.StartingPrice = startingPrice;
            return this;
        }
        public AuctionTestBuilder WithSomePastEndDate()
        {
            this.EndDateTime = DateTime.Now.AddDays(-1);
            return this;
        }
        public Auction Build()
        {
            return new Auction(SellerId, Product, StartingPrice, EndDateTime);
        }
    }
}
