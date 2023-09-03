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
    public partial class manage_patients : Form

    {
        private DatabaseHelper dbHelper;
        public manage_patients()
        {   
            dbHelper = new DatabaseHelper();
            InitializeComponent();
        }

        private void manage_patients_Load(object sender, EventArgs e)
        {

            List<Patient> patient = dbHelper.GetAllPatients();

                grid_patients.DataSource = patient;
            
        }

        private void btn_add_new_patient_Click(object sender, EventArgs e)
        {
            add_patient add_Patient = new add_patient();
            add_Patient.Show();
            this.Hide();
        }

        private void back_Click(object sender, EventArgs e)
        {
            AdminLanding adminLanding = new AdminLanding();
            adminLanding.Show();
            this.Hide();
        }
    }
}
