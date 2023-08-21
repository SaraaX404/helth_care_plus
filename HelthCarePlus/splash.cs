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
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register Register = new Register();
            Register.Show();
            this.Hide();
        }
    }
}
