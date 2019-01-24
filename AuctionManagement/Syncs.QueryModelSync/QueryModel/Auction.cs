using System;
using System.Collections.Generic;

namespace Syncs.QueryModelSync.QueryModel
{
    internal class Auction
    {
        public Guid Id { get; set; }
        public Participant Seller { get;  set; }
        public SellingProduct Product { get;  set; }
        public int StartingPrice { get;  set; }
        public DateTime EndDateTime { get;  set; }
        public List<Bid> Bids { get;  set; }
    }
}