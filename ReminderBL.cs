using ReminderApp.BO;
using ReminderApp.DAL;
using System.Data;

namespace ReminderApp.BL
{
    public class ReminderBL
    {
        private ReminderDB reminderDB = new ReminderDB();

        public long AddReminder(ReminderBO reminderBO)
        {
            var query = "INSERT INTO tblReminder([Time],[Reminder],[Date]) VALUES ('"+reminderBO.Time+"','"+reminderBO.Reminder+"','"+reminderBO.Date.Date+"')";
            return reminderDB.UpsertDeleteReminder(query);
        }

        public long UpdateReminder(ReminderBO reminderBO)
        {
            var query = "UPDATE tblReminder SET [Time]='"+reminderBO.Time+ "', [Reminder]='"+reminderBO.Reminder+ "', [Date]='"+reminderBO.Date.Date+"' WHERE [Id]="+reminderBO.Id;
            return reminderDB.UpsertDeleteReminder(query);
        }

        public long DeleteReminder(ReminderBO reminderBO)
        {
            var query = "DELETE FROM tblReminder WHERE [Id]=" + reminderBO.Id;
            return reminderDB.UpsertDeleteReminder(query);
        }

        public DataTable GetReminder(ReminderBO reminderBO)
        {
            var query = "SELECT * FROM tblReminder WHERE Date ='"+reminderBO.Date.Date+"'";
            return reminderDB.GetReminder(query);
        }
    }
}
