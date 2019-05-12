using ReminderApp.BL;
using ReminderApp.BO;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ReminderApp
{
    public partial class Form2 : Form
    {
        private ReminderBL reminderBL = new ReminderBL();
        private ReminderBO reminderBO = new ReminderBO();

        public Form2(ReminderBO reminder=null)
        {
            InitializeComponent();
            dtpDate.Value = DateTime.Now.Date;
            dtpTime.Value = DateTime.Now;
            if (reminder!=null)
            {
                reminderBO = new ReminderBO();
                reminderBO = reminder;
                FillFields();
                btSave.Text = "Update";
            }
        }

        private void FillFields()
        {
            txtDescription.Text = reminderBO.Reminder;
            dtpDate.Value = reminderBO.Date;
            dtpTime.Value = DateTime.ParseExact(reminderBO.Time.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btSave.Text == "Save")
                {
                    if (txtDescription.Text != "")
                    {
                        reminderBO = new ReminderBO();
                        reminderBO.Date = dtpDate.Value;
                        reminderBO.Time = new TimeSpan(Convert.ToDateTime(dtpTime.Value).Hour, Convert.ToDateTime(dtpTime.Value).Minute, Convert.ToDateTime(dtpTime.Value).Second);
                        //reminderBO.Time = new TimeSpan(Convert.ToDateTime(dtpTime.Value).Ticks);
                        reminderBO.Reminder = txtDescription.Text;
                        if (reminderBL.AddReminder(reminderBO) > 0)
                        {
                            MessageBox.Show("Task created");
                            txtDescription.Clear();
                            txtDescription.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Error found !!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter task description");
                    }
                }
                else
                {
                    reminderBO.Date = dtpDate.Value;
                    reminderBO.Time = new TimeSpan(Convert.ToDateTime(dtpTime.Value).Hour, Convert.ToDateTime(dtpTime.Value).Minute, Convert.ToDateTime(dtpTime.Value).Second);
                    reminderBO.Reminder = txtDescription.Text;
                    if (reminderBL.UpdateReminder(reminderBO) > 0)
                    {
                        MessageBox.Show("Task updated");
                    }
                    else
                    {
                        MessageBox.Show("Error found !!");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
