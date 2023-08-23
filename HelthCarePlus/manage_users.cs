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
    public partial class ManageUsers : Form
    {

        private DatabaseHelper dbHelper;
        public ManageUsers()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }


        public void users_load(object sender, EventArgs e)
        {
            List<User> users = dbHelper.GetAllUsers();
            
            grid_users.DataSource = users;
        }

        private void grid_users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_download_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminLanding adminLanding = new AdminLanding();
            adminLanding.Show();
            this.Hide();
        }
    }
}
