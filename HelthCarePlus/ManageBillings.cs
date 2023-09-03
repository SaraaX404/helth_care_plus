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
    public partial class ManageBillings : Form
    {
        private DatabaseHelper dbHelper; 
        public ManageBillings()
        {
            dbHelper = new DatabaseHelper();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void rdb_admit_CheckedChanged(object sender, EventArgs e)
        {
            lblBal.Text = "";
            lblTot.Text = "";
            txt_pay.Text = string.Empty;
            if (rdb_admit.Checked)
            {
                lbl_res.Text = "Admit";

                List<Admit> admits = dbHelper.GetAllAdmitsWithDetails();

                // Use LINQ to filter the admits with charged status 0
                List<Admit> filteredAdmits = admits.Where(admit => admit.ChargedStatus == "Pending").ToList();



                cmb_id.DataSource = filteredAdmits;
                cmb_id.DisplayMember = "Id"; 
            }
        }

        private void rdb_apt_CheckedChanged(object sender, EventArgs e)
        {
            lblBal.Text = "";
            lblTot.Text = "";
            txt_pay.Text = string.Empty;
            if (rdb_apt.Checked)
            {
                lbl_res.Text = "Appointment";

              
                List<Appointment> app = dbHelper.GetAllAppointments();

                List<Appointment> pendingAppointments = app.Where(appointment => appointment.ChargedStatus == "Pending").ToList();



                cmb_id.DataSource = pendingAppointments;
                cmb_id.DisplayMember = "Id"; 
            }

            
        }

        private void ManageBillings_Load(object sender, EventArgs e)
        {
            List<Appointment> app = dbHelper.GetAllAppointments();
            List<Appointment> pendingAppointments = app.Where(appointment => appointment.ChargedStatus == "Pending").ToList();
            List<Appointment> doneAppointments = app.Where(appointment => appointment.ChargedStatus == "Done").ToList();

            

            if (pendingAppointments.Count < 1)
            {
                rdb_apt.Enabled = false;
            }

            List<Admit> admits = dbHelper.GetAllAdmitsWithDetails();
            List<Admit> doneAdmits = admits.Where(admit => admit.ChargedStatus == "Done").ToList();
            List<Admit> filteredAdmits = admits.Where(admit => admit.ChargedStatus == "Pending").ToList();

            


            if (filteredAdmits.Count < 1)
            {
                rdb_admit.Enabled = false;
            }


        }

        private void cmb_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblBal.Text = "";
            lblTot.Text = "";
            txt_pay.Text = string.Empty;
            if (cmb_id.SelectedItem != null)
            {

                if (rdb_admit.Checked)
                {
                    if (cmb_id.SelectedItem is Admit selectedAdmit)
                    {

                        int selectedAdmitId = selectedAdmit.Id; // Assuming 'Id' is the property that represents the ID
                        Admit admitDetails = dbHelper.GetAdmitById(selectedAdmitId);

                        data_grid.DataSource = null;

                        lblTot.Text = admitDetails.Price.ToString();

                        List<Admit> selectedAdmitList = new List<Admit>();
                        selectedAdmitList.Add(admitDetails);

                        data_grid.DataSource = selectedAdmitList;
                    }
                    else
                    {
                        // Handle the case where the selected item is not of type Admit
                        MessageBox.Show("Invalid selection in the ComboBox.");
                    }
                }
                else
                {
                    if (cmb_id.SelectedItem is Appointment selectedApp)
                    {

                        int selectedAppId = selectedApp.Id; // Assuming 'Id' is the property that represents the ID
                        Appointment appDetails = dbHelper.GetAppointmentById(selectedAppId);

                        data_grid.DataSource = null;

                        lblTot.Text = "2000";

                        List<Appointment> selectedAppList = new List<Appointment>();
                        selectedAppList.Add(appDetails);

                        data_grid.DataSource = selectedAppList;
                    }
                    else
                    {
                        // Handle the case where the selected item is not of type Admit
                        MessageBox.Show("Invalid selection in the ComboBox.");
                    }
                }


               
            }
        }

        private void btn_add_new_resource_Click(object sender, EventArgs e)
        {
            int tot = Convert.ToInt32(lblTot.Text);
            int pay = Convert.ToInt32(txt_pay.Text);

            if (tot > pay)
            {
                MessageBox.Show("This amount is not enough to pay");
            }
            else
            {
                if (rdb_admit.Checked)
                {
                    if(cmb_id.SelectedItem is Admit selectedAdmit)
                    {
                        int selectedAddId = selectedAdmit.Id;
                        dbHelper.UpdateAdmitChargedStatusById(selectedAddId);

                        List<Admit> admits = dbHelper.GetAllAdmitsWithDetails();
                        List<Admit> filteredAdmits = admits.Where(admit => admit.ChargedStatus == "Pending").ToList();

                        if (filteredAdmits.Count < 1)
                        {
                            rdb_admit.Enabled = false;
                        }

                        cmb_id.DataSource = filteredAdmits;
                        cmb_id.DisplayMember = "Id";

                    }
                   

                }

                if (rdb_apt.Checked)
                {
                    if (cmb_id.SelectedItem is Appointment selectedApp)
                    {
                        int selectedAppId = selectedApp.Id;
                        dbHelper.UpdateAppointmentChargedStatusById(selectedAppId);

                        List<Appointment> app = dbHelper.GetAllAppointments();
                        List<Appointment> pendingAppointments = app.Where(appointment => appointment.ChargedStatus == "Pending").ToList();

                        if (pendingAppointments.Count < 1)
                        {
                            rdb_apt.Enabled = false;
                        }

                        cmb_id.DataSource = pendingAppointments;
                        cmb_id.DisplayMember = "Id";

                    }


                }
                int bal = pay - tot;
                lblBal.Text = bal.ToString();

            }

            txt_pay.Text = string.Empty;
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminLanding adminLanding = new AdminLanding();
            adminLanding.Show();
            this.Hide();
        }
    }
}
