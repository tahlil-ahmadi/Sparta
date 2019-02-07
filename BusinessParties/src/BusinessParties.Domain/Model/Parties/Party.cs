using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BusinessParties.Domain.Model.Parties.States;

namespace BusinessParties.Domain.Model.Parties
{
    public abstract class Party
    {
        private IList<Phone> _phones;
        public IReadOnlyCollection<Phone> Phones => new ReadOnlyCollection<Phone>(_phones);
        public PartyId Id { get; private set; }
        public PartyState State { get; private set; }
        protected Party() { }
        protected Party(PartyId id)
        {
            Id = id;
            this.State = new PendingState();
        }
        public void Confirm()
        {
            this.State = this.State.GotoConfirm();
        }

        public void AssignPhones(List<Phone> phones)
        {
            if (State.CanModify())
                this._phones = this._phones.Update(phones);
            else
                throw new Exception("Invalid state");
        }
    }
}
