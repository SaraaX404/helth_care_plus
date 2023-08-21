using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelthCarePlus
{
    public partial class Register : Form
    {
        private DatabaseHelper dbHelper;
        public Register()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
          
        }

        private void Register_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> roleNames = dbHelper.GetRoleNames();

            foreach (var role in roleNames)
            {
                select_roles.Items.Add(new KeyValuePair<int, string>(role.Key, role.Value));
            }

            select_roles.DisplayMember = "Value";
            select_roles.ValueMember = "Key";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (select_roles.SelectedItem != null)
            {
                KeyValuePair<int, string> selectedRole = (KeyValuePair<int, string>)select_roles.SelectedItem;
                int selectedRoleId = selectedRole.Key;
                Boolean result = dbHelper.InsertUserData(txt_first_name.Text, txt_last_name.Text, selectedRoleId, txt_username.Text, txt_password.Text);
                if(result)
                {
                    AdminLanding adminLanding = new AdminLanding();
                    adminLanding.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Cannot register users");
                }

            }
            else
            {
                
            }
        }
    }
}
