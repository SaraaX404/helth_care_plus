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
    public partial class add_room : Form
    {
        private DatabaseHelper dbHelper;

        public add_room()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int ac = 0;


            manage_rooms manage_Rooms = new manage_rooms();

            if (rd_ac.Checked)
            {
                ac = 1;

            }else if(rd_ac.Checked) {
                ac = 0;

            }
            else
            {
                MessageBox.Show("Please Select AC or Non AC");
                return;
            }

            dbHelper.InsertRoomData(Convert.ToInt32(txt_room_number.Text), Convert.ToInt32(txt_price.Text), ac);
            manage_Rooms.Show();
            this.Hide();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminLanding adminLanding = new AdminLanding();
            adminLanding.Show();
            this.Hide();
        }
    }
}
