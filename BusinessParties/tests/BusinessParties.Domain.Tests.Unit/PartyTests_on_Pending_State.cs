using System;
using System.Collections.Generic;
using System.Text;
using BusinessParties.Domain.Model.Parties;
using BusinessParties.Domain.Model.Parties.States;
using FluentAssertions;
using Xunit;

namespace BusinessParties.Domain.Tests.Unit
{
    public class PartyTests_on_Pending_State
    {
        [Fact]
        public void should_transit_to_confirm_state()
        {
            var party = new IndividualParty(new PartyId(1), "David", "Hasselhoff");

            party.Confirm();

            party.State.Should().BeOfType<ConfirmedState>();
        }

        [Fact]
        public void should_transit_to_reject_state()
        {
            var party = new IndividualParty(new PartyId(1), "David", "Hasselhoff");

            party.Reject();

            party.State.Should().BeOfType<RejectedState>();
        }
    }
}
