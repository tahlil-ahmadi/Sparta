using System;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Model.Participants;

namespace AuctionManagement.Domain.TestsUtil
{
    public class AuctionTestBuilder
    {
        public Participant Seller { get; private set; }
        public SellingProduct Product { get; private set; }
        public int StartingPrice { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public AuctionTestBuilder()
        {
            this.Product = new SellingProduct(2,"X");
            this.Seller = new Participant(3, "Jack");
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
            return new Auction(Seller, Product, StartingPrice, EndDateTime);
        }
    }
}
