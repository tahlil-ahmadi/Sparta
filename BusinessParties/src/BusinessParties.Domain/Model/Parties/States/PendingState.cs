namespace BusinessParties.Domain.Model.Parties.States
{
    public class PendingState : PartyState
    {
        public override bool CanModify() => true;
        public override PartyState GotoConfirm()
        {
            return new ConfirmedState();
        }
    }
}