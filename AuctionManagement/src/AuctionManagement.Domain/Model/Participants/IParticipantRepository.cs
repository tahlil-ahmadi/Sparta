using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Domain.Model.Auctions;

namespace AuctionManagement.Domain.Model.Participants
{
    public interface IParticipantRepository
    {
        Participant Get(long id);
    }
}
