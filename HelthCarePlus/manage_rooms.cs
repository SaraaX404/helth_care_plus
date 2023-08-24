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
    public partial class manage_rooms : Form
    {

        private DatabaseHelper dbHelper;
        public manage_rooms()
        {
            dbHelper = new DatabaseHelper();
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            AdminLanding adminLanding = new AdminLanding();
            adminLanding.Show();
            this.Hide();
        }

        private void room_load(object sender, EventArgs e)
        {
            List<DatabaseHelper.Room> rooms = dbHelper.GetAllRooms();
            grid_rooms.DataSource = rooms;
        }

        private void btn_add_new_room_Click(object sender, EventArgs e)
        {
            add_room add_Room = new add_room();
            add_Room.Show();
            this.Hide();
        }
    }
}
