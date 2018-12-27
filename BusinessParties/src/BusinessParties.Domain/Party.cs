using System;

namespace BusinessParties.Domain
{
    public abstract class Party
    {
        public int Id { get; private set; }
        public bool IsConfirmed { get; private set; }
        protected Party(int id)
        {
            Id = id;
        }
        public void Confirm()
        {
            this.IsConfirmed = true;
        }
    }
}
