using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BusinessParties.Domain.Model
{
    public abstract class Party
    {
        private IList<Phone> _phones;
        public IReadOnlyCollection<Phone> Phones => new ReadOnlyCollection<Phone>(_phones);
        public PartyId Id { get; private set; }
        public bool IsConfirmed { get; private set; }
        protected Party() { }
        protected Party(PartyId id)
        {
            Id = id;
        }
        public void Confirm()
        {
            this.IsConfirmed = true;
        }

        public void AssignPhones(List<Phone> phones)
        {
            this._phones = this._phones.Update(phones);
        }
    }
}
