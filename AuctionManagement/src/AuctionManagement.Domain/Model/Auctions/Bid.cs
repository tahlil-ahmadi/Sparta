using System;

namespace AuctionManagement.Domain.Model.Auctions
{
    public class Bid
    {
        public int BidderId { get; set; }
        public int Amount { get; set; }
        public DateTime OfferDateTime { get; set; }
        public Bid(int bidderId, int amount, DateTime offerDateTime)
        {
            BidderId = bidderId;
            Amount = amount;
            OfferDateTime = offerDateTime;
        }
    }
}
