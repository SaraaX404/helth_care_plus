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
    public partial class AddNewAdmit : Form
    {

        private DatabaseHelper dbHelper; 
        public AddNewAdmit()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void load_admit(object sender, EventArgs e)
        {
            List<KeyValuePair<int, string>> patientData = dbHelper.GetPatientDataForComboBox();
            List<KeyValuePair<int, string>> roomData = dbHelper.GetRoomDataForComboBox();

            foreach (var patient in patientData)
            {
                select_patient.Items.Add(patient);
            }

            foreach (var room in roomData)
            {
                select_room.Items.Add(room);
            }

            select_patient.DisplayMember = "Value";
            select_patient.ValueMember = "Key";

            select_room.DisplayMember = "Value";
            select_room.ValueMember = "Key";

        }

        private void btn_addmit_Click(object sender, EventArgs e)
        {
            if(select_patient.SelectedItem == null || select_room.SelectedItem == null) {

                MessageBox.Show("Please Fill The Feilds");


            }
            else
            {
                KeyValuePair<int, string> selectedPatient = (KeyValuePair<int, string>)select_patient.SelectedItem;
                int selectedPatientId = selectedPatient.Key;

                KeyValuePair<int, string> selectedRoom = (KeyValuePair<int, string>)select_room.SelectedItem;
                int selectedRoomId = selectedRoom.Key;

                Boolean result =  dbHelper.CreateAdmit(selectedPatientId, selectedRoomId);


                if (result)
                {
                    ManageAdmits manageAdmits = new ManageAdmits();
                    manageAdmits.Show();
                    this.Hide();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminLanding adminLanding = new AdminLanding();
            adminLanding.Show();
            this.Hide();
        }
    }
}
