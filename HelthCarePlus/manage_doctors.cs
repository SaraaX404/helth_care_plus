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
    public partial class manage_doctors : Form
    {
        public manage_doctors()
        {
            InitializeComponent();
        }

        private void btn_add_new_doctor_Click(object sender, EventArgs e)
        {
            add_doctor add_Doctor = new add_doctor();
            add_Doctor.Show();
            this.Hide();
        }
    }
}
