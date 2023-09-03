using Google.Protobuf.WellKnownTypes;
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
    public partial class ManageAdmits : Form
    {

        private DatabaseHelper dbHelper;
        public ManageAdmits()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void user_load(object sender, EventArgs e)
        {
            List<Admit> admits = dbHelper.GetAllAdmitsWithDetails();
            grid_admits.DataSource = admits;
        }

        private void btn_add_new_admit_Click(object sender, EventArgs e)
        {
            AddNewAdmit addNewAdmit = new AddNewAdmit();
            addNewAdmit.Show();
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
