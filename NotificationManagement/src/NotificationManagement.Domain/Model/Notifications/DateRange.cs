using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotificationManagement.Domain.Model.Notifications
{
    public struct DateRange
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public DateRange(DateTime startDate, DateTime endDate) : this()
        {
            if (startDate >= endDate) throw new Exception("Invalid range");

            this.Start = startDate;
            this.End = endDate;
        }

        public List<DateTime> GetDaysBetween()
        {
            var startDate = Start;
            return Enumerable.Range(0, Days)
                .Select(offset => startDate.AddDays(offset))
                .ToList();
        }
        public int Days => (End - Start).Days + 1;
    }
}
