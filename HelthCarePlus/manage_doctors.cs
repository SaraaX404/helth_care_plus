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
    public partial class manage_doctors : Form
    {

        private DatabaseHelper dbHelper;
        public manage_doctors()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();    
        }


        public void doctors_load(object sender, EventArgs e)
        {
            List<Doctor> doctors = dbHelper.GetAllDoctors();

            grid_doctors.DataSource = doctors;
        }

        private void btn_add_new_doctor_Click(object sender, EventArgs e)
        {
            add_doctor add_Doctor = new add_doctor();
            add_Doctor.Show();
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
