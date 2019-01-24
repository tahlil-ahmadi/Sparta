using System;

namespace Syncs.QueryModelSync.QueryModel
{
    internal class Bid
    {
        public Participant Bidder { get; set; }
        public int Amount { get; set; }
        public DateTime OfferDateTime { get; set; }
    }
}