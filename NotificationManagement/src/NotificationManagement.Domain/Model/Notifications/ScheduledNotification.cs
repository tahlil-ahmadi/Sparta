using System;

namespace NotificationManagement.Domain.Model.Notifications
{
    public class ScheduledNotification : Notification
    {
        public DateTime ScheduleDateTime { get; set; }
        public ScheduledNotification(string receiver, string text, TimeSpan maxRetryValidTime) 
            : base(receiver, text, maxRetryValidTime)
        {
        }
    }
}