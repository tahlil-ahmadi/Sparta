using System;
using System.Collections.Generic;
using System.Text;
using Sparta.Core.EventHandling;

namespace AuctionManagement.Domain.Contracts.Auctions
{
    public class AuctionOpened : DomainEvent
    {
        public Guid Id { get; private set; }
        public int SellerId { get; private set; }
        public int ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public int StartingPrice { get; set; }
        public DateTime EndDateTime { get; set; }
        public AuctionOpened(Guid id, int sellerId, int productCategoryId, string productName, int startingPrice, DateTime endDateTime)
        {
            Id = id;
            SellerId = sellerId;
            ProductCategoryId = productCategoryId;
            ProductName = productName;
            StartingPrice = startingPrice;
            EndDateTime = endDateTime;
        }
    }
}
