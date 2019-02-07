using Sparta.Domain;

namespace BusinessParties.Domain.Model.Parties
{
    public class PartyId : ValueObject
    {
        public long Id { get; private set; }
        protected PartyId() { }
        public PartyId(long id)
        {
            Id = id;
        }
        protected bool Equals(PartyId other)
        {
            return Id == other.Id;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PartyId) obj);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
