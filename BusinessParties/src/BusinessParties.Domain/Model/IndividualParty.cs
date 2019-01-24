namespace BusinessParties.Domain.Model
{
    public class IndividualParty : Party
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        protected IndividualParty() { }
        public IndividualParty(PartyId id, string firstname, string lastname) : base(id)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }
    }
}