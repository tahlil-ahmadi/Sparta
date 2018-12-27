using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationManagement.Domain.Model.Notifications
{
    public abstract class Notification
    {
        public Guid Id { get; }
        public string Receiver { get;  }
        public string Text { get;  }
        public TimeSpan MaxRetryValidTime { get; }
        public bool IsSent { get; private set; }
        public DateTime SendDateTime { get; private set; }
        protected Notification(string receiver, string text, TimeSpan maxRetryValidTime)
        {
            Id = Guid.NewGuid();
            Receiver = receiver;
            Text = text;
            MaxRetryValidTime = maxRetryValidTime;
        }

        public void MarkAsSent()
        {
            this.IsSent = true;
            this.SendDateTime = DateTime.Now;
        }
    }
}
