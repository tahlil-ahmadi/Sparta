using System;
using System.Linq.Expressions;
using AuctionManagement.Application.Contracts;
using AuctionManagement.Domain;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Model.Participants;

namespace AuctionManagement.Application
{
    public class AuctionCommandHandlers
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IClock _clock;

        public AuctionCommandHandlers(IAuctionRepository auctionRepository, 
                                       IParticipantRepository participantRepository,
                                       IClock clock)
        {
            _auctionRepository = auctionRepository;
            _participantRepository = participantRepository;
            _clock = clock;
        }

        public void Handle(OpenAuctionCommand command)
        {
            var seller = _participantRepository.Get(command.SellerId);
            var product = new SellingProduct(command.CategoryId, command.Product);
            var auction = new Auction(seller, product, command.StartingPrice, command.EndDatetime, _clock);
            _auctionRepository.Add(auction);
        }

        public void Handle(PlaceBidCommand command)
        {
            var auction = _auctionRepository.GetById(command.AuctionId);
            var bid = new Bid(command.BidderId, command.BidAmount, DateTime.Now);
            auction.PlaceBid(bid, _clock);
            //update auction
        }
    }
}
