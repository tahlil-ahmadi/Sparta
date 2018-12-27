using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using AuctionManagement.Domain.Contracts.Auctions;
using AuctionManagement.Domain.Model.Auctions;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using Sparta.Persistence.ES;

namespace AuctionManagement.Persistence.ES
{
    public class AuctionRepository : EventSourcedRepository<Guid, Auction>, IAuctionRepository
    {
       

    }
}
