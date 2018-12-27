namespace BusinessParties.Domain
{
    public class IndividualParty : Party
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public IndividualParty(int id, string firstname, string lastname) : base(id)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }
    }
}