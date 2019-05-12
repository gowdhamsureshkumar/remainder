using System;

namespace ReminderApp.BO
{
    public class ReminderBO
    {
        public long Id { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime Date { get; set; }
        public string Reminder { get; set; }
    }
}
