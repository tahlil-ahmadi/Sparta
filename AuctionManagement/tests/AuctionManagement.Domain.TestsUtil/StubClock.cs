using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionManagement.Domain.TestsUtil
{
    public class StubClock : IClock
    {
        private DateTime _now;
        public StubClock(DateTime? now = null)
        {
            if (now == null) now = DateTime.Now;
            _now = now.Value;
        }
        public void TimeTravelTo(DateTime date)
        {
            _now = date;
        }
        public DateTime Now()
        {
            return _now;
        }
    }
}
