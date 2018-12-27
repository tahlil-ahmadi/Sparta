using System;
using AuctionManagement.Domain.Contracts.Auctions;
using AuctionManagement.Domain.Model.Auctions.Exceptions;
using Sparta.Domain;

namespace AuctionManagement.Domain.Model.Auctions
{
    public partial class Auction : EventSourcedAggregateRoot<Guid>
    {
        public int SellerId { get; private set; }
        public SellingProduct Product { get; private set; }
        public int StartingPrice { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public Bid WinningBid { get; private set; }
        protected Auction(){}
        public Auction(int sellerId, SellingProduct product, int startingPrice, DateTime endDateTime)
        {
            if (startingPrice <= 0) throw new InvalidStartingPriceException();
            if (endDateTime <= DateTime.Now) throw new PastEndDateException();

            Causes(new AuctionOpened(Guid.NewGuid(), sellerId, product.CategoryId, product.Name, startingPrice, endDateTime));
        }
        public void PlaceBid(Bid bid)
        {
            GuardAgainstClosedAuction();
            GuardAgainstInvalidBidAmount(bid.Amount);
            GuardAgainstInvalidBidder(bid.BidderId);

            Causes(new BidPlaced(this.Id, bid.Amount, bid.OfferDateTime, bid.BidderId));
        }
        private void GuardAgainstClosedAuction()
        {
            if (this.IsClosed()) throw new InvalidAuctionStateException();
        }
        private bool IsClosed()
        {
            return this.EndDateTime < DateTime.Now;
        }
        private void GuardAgainstInvalidBidAmount(int bidAmount)
        {
            var maxOffer = GetMaxOffer();
            if (bidAmount <= maxOffer) throw new InvalidBidException();
        }
        private int GetMaxOffer()
        {
            if (IsFirstOffer())
                return this.StartingPrice;

            return this.WinningBid.Amount;
        }
        private bool IsFirstOffer()
        {
            return this.WinningBid == null;
        }
        private void GuardAgainstInvalidBidder(int bidderId)
        {
            if (this.SellerId == bidderId) throw new BidderSameAsSellerException();
        }
      
    }
}