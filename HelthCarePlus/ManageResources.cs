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
    public partial class ManageResources : Form
    {

        private DatabaseHelper dbHelper;
        public ManageResources()
        {

            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void ManageResources_Load(object sender, EventArgs e)
        {
            List<ResourceData> data = dbHelper.GetResourceData();
            grid_resources.DataSource = data;
        }

        private void btn_add_new_resource_Click(object sender, EventArgs e)
        {
            bool res = dbHelper.InsertResourceData(txt_resources.Text);
            if(!res)
            {
                MessageBox.Show("Cannot Insert Data");
            }
            else
            {
                MessageBox.Show("Insert Completed");
                List<ResourceData> data = dbHelper.GetResourceData();
                grid_resources.DataSource = data;
            }
        }
    }
}
