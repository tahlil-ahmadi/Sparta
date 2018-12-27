using System;
using Sparta.Core.EventHandling;

namespace AuctionManagement.Domain.Contracts.Auctions
{
    public class BidPlaced : DomainEvent
    {
        public Guid AuctionId { get; private set; }
        public int Amount { get; private set; }
        public DateTime CreateDateTime { get; private set; }
        public int BidderId { get; private set; }
        public BidPlaced(Guid auctionId, int amount, DateTime dateTime, int bidderId)
        {
            AuctionId = auctionId;
            Amount = amount;
            CreateDateTime = dateTime;
            BidderId = bidderId;
        }
    }
}