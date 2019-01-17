using System;

namespace AuctionManagement.Application.Contracts
{
    public class PlaceBidCommand
    {
        public int BidderId { get; set; }
        public Guid AuctionId { get; set; }
        public int BidAmount { get; set; }
    }
}