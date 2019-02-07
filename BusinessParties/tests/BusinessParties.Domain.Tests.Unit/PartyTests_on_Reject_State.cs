using System;
using System.Collections.Generic;
using System.Text;
using BusinessParties.Domain.Model.Parties;
using BusinessParties.Domain.Model.Parties.States;
using FluentAssertions;
using Xunit;

namespace BusinessParties.Domain.Tests.Unit
{
    public class PartyTests_on_Reject_State
    {
        private IndividualParty rejectedParty = null;
        public PartyTests_on_Reject_State()
        {
            rejectedParty = new IndividualParty(new PartyId(1), "David", "Hasselhoff");
            rejectedParty.Reject();
            rejectedParty.State.Should().BeOfType<RejectedState>(); //guard assertion
        }

        [Fact]
        public void should_throw_on_transition_to_confirm_state()
        {
           Action confirm = () => rejectedParty.Confirm();

            confirm.Should().Throw<Exception>();
        }
    }
}
