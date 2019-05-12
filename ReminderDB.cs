using System;
using System.Data;
using System.Data.SqlClient;

namespace ReminderApp.DAL
{
    public class ReminderDB
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter adp;

        public ReminderDB()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=ReminderDB;Integrated Security=True");
        }

        public DataTable GetReminder(string query)
        {
            try
            {
                con.Open();
                adp = new SqlDataAdapter(query, con);
                var dt = new DataTable();
                adp.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public long UpsertDeleteReminder(string query)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                var res = cmd.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
