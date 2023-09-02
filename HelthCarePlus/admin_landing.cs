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
    public partial class AdminLanding : Form
    {
        private DatabaseHelper dbHelper;
        public AdminLanding()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadUIComponentsOnRole();   
        }


        private void LoadUIComponentsOnRole()
        {
            int roleId = UserSession.Instance.RoleId;
           /* if(roleId == 1)
            {

            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            manage_doctors manage_Doctors = new manage_doctors();
            manage_Doctors.Show();
            this.Hide();
        }

        private void btn_manage_users_Click(object sender, EventArgs e)
        {
            ManageUsers manageUsers = new ManageUsers();
            manageUsers.Show(); 
            this.Hide();
        }

        private void btn_manage_paitents_Click(object sender, EventArgs e)
        {
            manage_patients manage_Patients = new manage_patients();
            manage_Patients.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manage_rooms manage_Rooms = new manage_rooms();
            manage_Rooms.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ManageAppointment manageAppointment = new ManageAppointment();
            manageAppointment.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManageAdmits manageAdmits = new ManageAdmits();
            manageAdmits.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ManageResources manageResources = new ManageResources();
            manageResources.Show();
            this.Hide();
        }
    }
}
