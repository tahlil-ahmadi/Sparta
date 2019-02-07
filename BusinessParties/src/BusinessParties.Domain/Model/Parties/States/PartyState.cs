using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessParties.Domain.Model.Parties.States
{
    public abstract class PartyState
    {
        public virtual bool CanModify() => false;
        public virtual PartyState GotoConfirm()
        {
            throw new Exception("Invalid State");
        }

        public virtual PartyState GotoReject()
        {
            throw new Exception("Invalid State");
        }
    }
}
