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
    public partial class add_patient : Form
    {

        private DatabaseHelper dbHelper;

        
        public add_patient()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Boolean res =  dbHelper.InsertPatientData(txt_first_name.Text, txt_last_name.Text, txt_pa_contact.Text, Convert.ToInt32(txt_age.Text), cmb_gender.Text);

        if (res)
            {
                manage_patients manage_Patients = new manage_patients();
                manage_Patients.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Cannot insert the data");
            }
        }
    }
}
