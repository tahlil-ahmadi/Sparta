using System;
using BusinessParties.Domain.Model.Parties;
using BusinessParties.Domain.Model.Parties.States;
using FluentAssertions;
using Xunit;

namespace BusinessParties.Domain.Tests.Unit
{
    public abstract class PartyTests
    {
        [Fact]
        public void Should_be_created_in_pending_state()
        {
            var party = CreateParty();

            party.State.Should().BeOfType<PendingState>();
        }

        protected abstract Party CreateParty();
    }

    public class IndividualPartyTests : PartyTests
    {
        protected override Party CreateParty()
        {
            return new IndividualParty(new PartyId(1),"David","Hasselhoff");
        }
    }
    public class LegalPartyTests : PartyTests
    {
        protected override Party CreateParty()
        {
            return new LegalParty(new PartyId(2));
        }
    }
}
