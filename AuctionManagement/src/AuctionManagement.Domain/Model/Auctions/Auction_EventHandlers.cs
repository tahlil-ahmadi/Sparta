﻿using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Domain.Contracts.Auctions;
using Sparta.Domain;

namespace AuctionManagement.Domain.Model.Auctions
{
    public partial class Auction
    {
        public void Causes(DomainEvent @event)
        {
            Apply((dynamic)@event);
            Publish(@event);
        }
        public void Apply(AuctionOpened @event)
        {
            this.Id = @event.Id;
            this.EndDateTime = @event.EndDateTime;
            this.Product = new SellingProduct(@event.ProductCategoryId, @event.ProductName);
            this.SellerId = @event.SellerId;
            this.StartingPrice = @event.StartingPrice;
        }
        public void Apply(BidPlaced @event)
        {
            this.WinningBid = new Bid(@event.BidderId, @event.Amount, @event.EventCreateDateTime);
        }
    }
}
