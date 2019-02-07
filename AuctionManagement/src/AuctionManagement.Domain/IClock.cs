using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionManagement.Domain
{
    //TODO: move to framework
    public interface IClock
    {
        DateTime Now();
    }
    public class SystemClock : IClock
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
