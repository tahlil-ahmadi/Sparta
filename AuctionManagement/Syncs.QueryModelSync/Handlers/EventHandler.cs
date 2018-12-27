using System;
using AuctionManagement.Domain.Contracts.Auctions;
using Sparta.Domain;

namespace Syncs.QueryModelSync.Handlers
{
    public class AuctionEventHandler
    {
        public void Handle(AuctionOpened @event)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("AuctionOpened Handled !");
        }

        public void Handle(BidPlaced @event)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("BidPlace Handled !");
        }
    }
}