using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HelthCarePlus.DatabaseHelper;

namespace HelthCarePlus
{
    public partial class ManageAppointment : Form
    {
        private DatabaseHelper dbHelper;

        public ManageAppointment()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void LoadAppointments(object sender, EventArgs e)
        {
            List<Appointment> apps = dbHelper.GetAllAppointments();
            

            // Append the log messages to the TextBox
            foreach (Appointment app in apps)
            {
                string logMessage = $"Appointment ID: {app.Id}, Patient: {app.PatientName}, Doctor: {app.DoctorName}, Date: {app.AppointmentDate}";
                
            }
            grid_apps.DataSource = apps;
        }

        private void btn_add_new_app_Click(object sender, EventArgs e)
        {
            AddAppointments addAppointments = new AddAppointments();
            addAppointments.Show();
            this.Hide();
        }
    }
}