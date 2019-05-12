using ReminderApp.BL;
using ReminderApp.BO;
using System;
using System.Windows.Forms;

namespace ReminderApp
{
    public partial class Form1 : Form
    {
        private ReminderBL reminderBL = new ReminderBL();
        private ReminderBO reminderBO = new ReminderBO();
        private ReminderBO reminderBODisplay = new ReminderBO();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadReminders();
        }

        private void LoadReminders()
        {
            reminderBO.Date = dtpDate.Value;
            var dt = reminderBL.GetReminder(reminderBO);
            if (dt != null && dt.Rows.Count>0)
            {
                dgvReminders.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvReminders.Rows.Add();
                    dgvReminders.Rows[i].Cells[0].Value = dt.Rows[i]["Time"].ToString();
                    dgvReminders.Rows[i].Cells[0].Tag = dt.Rows[i]["Id"].ToString();
                    dgvReminders.Rows[i].Cells[1].Value = dt.Rows[i]["Reminder"].ToString();
                    dgvReminders.Rows[i].Cells[1].Tag = dt.Rows[i]["Date"].ToString();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 frmTask = new Form2();
            frmTask.ShowDialog();
            LoadReminders();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form2 frmTask = new Form2(GetSelectedRowDetails());
            frmTask.ShowDialog();
            LoadReminders();
        }

        private ReminderBO GetSelectedRowDetails()
        {
            var selectedReminder=new ReminderBO();
            if (dgvReminders.SelectedCells.Count > 0)
            {
                selectedReminder.Id = Convert.ToInt64(dgvReminders.SelectedCells[0].Tag.ToString());
                selectedReminder.Time = new TimeSpan(Convert.ToDateTime(dgvReminders.SelectedCells[0].Value.ToString()).Hour,Convert.ToDateTime(dgvReminders.SelectedCells[0].Value.ToString()).Minute,Convert.ToDateTime(dgvReminders.SelectedCells[0].Value.ToString()).Second);
                selectedReminder.Reminder = dgvReminders.SelectedCells[1].Value.ToString();
                selectedReminder.Date = Convert.ToDateTime(dgvReminders.SelectedCells[1].Tag.ToString());
            }
            return selectedReminder;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure ?", "Reminder", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                var res = reminderBL.DeleteReminder(GetSelectedRowDetails());
            }
            LoadReminders();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadReminders();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            LoadDisplayReminders();
        }

        private void LoadDisplayReminders()
        {
            reminderBODisplay.Date = DateTime.Now;
            var dt = reminderBL.GetReminder(reminderBODisplay);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    reminderBODisplay.Time = new TimeSpan(Convert.ToDateTime(dt.Rows[i]["Time"].ToString()).Hour, Convert.ToDateTime(dt.Rows[i]["Time"].ToString()).Minute, Convert.ToDateTime(dt.Rows[i]["Time"].ToString()).Second);
                    if (reminderBODisplay.Time.ToString().Contains((DateTime.Now.Hour + ":" + DateTime.Now.Minute+":" + DateTime.Now.Second).ToString()))
                    {
                        Form3 frmReminderDisplay = new Form3(dt.Rows[i]["Reminder"].ToString());
                        frmReminderDisplay.Show();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
