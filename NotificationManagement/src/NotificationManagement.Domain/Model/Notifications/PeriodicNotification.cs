using System;

namespace NotificationManagement.Domain.Model.Notifications
{
    public class PeriodicNotification : Notification
    {
        public DateRange DateRange { get; set; }
        public TimeSpan Interval { get; set; }
        public PeriodicNotification(string receiver, string text, TimeSpan maxRetryValidTime) 
            : base(receiver, text, maxRetryValidTime)
        {
        }
        public void SetPeriod(DateRange range, TimeSpan interval)
        {
            this.DateRange = range;
            this.Interval = interval;
        }
    }
}