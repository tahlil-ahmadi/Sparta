using System;

namespace AuctionManagement.Application.Contracts
{
    public class OpenAuctionCommand
    {
        public long SellerId { get; set; }
        public int StartingPrice { get; set; }
        public string Product { get; set; }
        public int CategoryId { get; set; }
        public DateTime EndDatetime { get; set; }
    }
}
