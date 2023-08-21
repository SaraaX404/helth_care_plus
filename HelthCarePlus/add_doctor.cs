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
    public partial class add_doctor : Form
    {
        private DatabaseHelper dbHelper;
        public add_doctor()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        List<int> selectedDayIds = new List<int>();

   

        private async void button1_Click(object sender, EventArgs e)
        {
           Boolean res = dbHelper.InsertDoctorData(txt_first_name.Text, txt_last_name.Text, txt_doc_contact.Text, txt_sps.Text);
            if(res)
            {
                int id = dbHelper.GetLastInsertedDoctorId();
                if (sunday.Checked)
                {
                    selectedDayIds.Add(1);
                }

                if (monday.Checked)
                {
                    selectedDayIds.Add(2);
                }

                if (tuesday.Checked)
                {
                    selectedDayIds.Add(3);
                }

                if (wednesday.Checked)
                {
                    selectedDayIds.Add(4);
                }

                if (thursday.Checked)
                {
                    selectedDayIds.Add(5);
                }

                if (friday.Checked)
                {
                    selectedDayIds.Add(6);
                }

                if (saturday.Checked)
                {
                    selectedDayIds.Add(7);
                }

                dbHelper.InsertScheduleData(id, selectedDayIds);
                manage_doctors manage_Doctors = new manage_doctors();
                manage_Doctors.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("There is a error");
            }
        }
    }
}
