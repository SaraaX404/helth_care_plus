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
    public partial class AddAppointments : Form
    {
        private DatabaseHelper dbHelper;
        private bool doctorAndPatientSelected = false;
        public AddAppointments()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            comboBoxDocs.SelectedIndexChanged += comboBoxDocs_SelectedIndexChanged;
            comboBoxPatients.SelectedIndexChanged += comboBoxPatients_SelectedIndexChanged;
        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ComboBoxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void comboBoxDocs_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckEnableDateTimeSelection();
            CheckAndUpdateWarningLabel();
        }

        private void comboBoxPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckEnableDateTimeSelection();
        }

        private void InitApps(object sender, EventArgs e)
        {
            lblwarning.Hide();
            comboBoxAppointmentTime.Items.Clear();

            DateTime startTime = DateTime.Today.AddHours(8); // Start from 8:00 AM
            DateTime lunchBreakStart = DateTime.Today.AddHours(13); // Lunch break at 1:00 PM
            DateTime dinnerBreakStart = DateTime.Today.AddHours(20); // Dinner break at 8:00 PM
            DateTime endTime = DateTime.Today.AddHours(23); // Up to 11:00 PM

            TimeSpan interval = TimeSpan.FromMinutes(20);

            while (startTime <= endTime)
            {
                if (startTime != lunchBreakStart && startTime != dinnerBreakStart)
                {
                    comboBoxAppointmentTime.Items.Add(startTime.ToString("hh:mm tt"));
                }

                if (startTime.TimeOfDay == lunchBreakStart.TimeOfDay || startTime.TimeOfDay == dinnerBreakStart.TimeOfDay)
                {
                    startTime += TimeSpan.FromMinutes(30); // Add 30 minutes for break gaps
                }
                else
                {
                    startTime += interval; // Add 40 minutes for regular gaps
                }
            }

            PopulatePatients();
            PopulateDoctors();
            CheckEnableDateTimeSelection();
         
        }

        private void PopulateDoctors()
        {
            List<DatabaseHelper.Doctor> doctors = dbHelper.GetAllDoctors();

            foreach (DatabaseHelper.Doctor doctor in doctors)
            {
                comboBoxDocs.Items.Add(new KeyValuePair<int, string>(doctor.Id, doctor.FirstName + " " + doctor.LastName));
            }

            comboBoxDocs.DisplayMember = "Value";
            comboBoxDocs.ValueMember = "Key";
        }

        private void CheckAndUpdateWarningLabel()
        {
            if (comboBoxDocs.SelectedItem != null)
            {
                KeyValuePair<int, string> selectedDoctor = (KeyValuePair<int, string>)comboBoxDocs.SelectedItem;
                int selectedDoctorId = selectedDoctor.Key;

                // Check if the selected doctor is available on the selected date
                bool doctorAvailable = IsDoctorAvailable(selectedDoctorId, dateSetApp.Value);
             

                if (!doctorAvailable)
                {
                    // The doctor is not available, show warning label
                    lblwarning.Show();
                    button1.Enabled = false;
                }
                else
                {
                    // The doctor is available, hide warning label
                    lblwarning.Hide();
                    button1.Enabled = true;
                }
            }
            else
            {
                // Either doctor or patient is not selected, hide warning label
                lblwarning.Show();
                button1.Enabled = false;
            }
        }

        private void CheckEnableDateTimeSelection()
        {
            if (comboBoxPatients.SelectedItem != null && comboBoxDocs.SelectedItem != null)
            {
                // Both doctor and patient are selected, enable date and time selection
                doctorAndPatientSelected = true;
                dateSetApp.Enabled = true;
                comboBoxAppointmentTime.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                // Either doctor or patient is not selected, disable date and time selection
                doctorAndPatientSelected = false;
                dateSetApp.Enabled = false;
                comboBoxAppointmentTime.Enabled = false;
                button1.Enabled = false;
            }
        }

        public void PopulatePatients()
        {
            List<DatabaseHelper.Patient> patients = dbHelper.GetAllPatients();

            foreach (DatabaseHelper.Patient patient in patients)
            {
               comboBoxPatients.Items.Add(new KeyValuePair<int, string>(patient.Id, patient.FirstName + " " + patient.LastName));
            }

            comboBoxPatients.DisplayMember = "Value";
            comboBoxPatients.ValueMember = "Key";
        }

        private bool IsDoctorAvailable(int doctorId, DateTime selectedDate)
        {
            int selectedDayId = (int)selectedDate.DayOfWeek + 1; // DayOfWeek starts from Sunday (0), so we add 1

            // Check the doctor's schedule for the selected day
            return dbHelper.IsDoctorAvailableOnDay(doctorId, selectedDayId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxPatients.SelectedItem != null && comboBoxDocs.SelectedItem != null && comboBoxAppointmentTime.SelectedItem != null)
            {
                KeyValuePair<int, string> selectedDoctor = (KeyValuePair<int, string>)comboBoxDocs.SelectedItem;
                int doctorId = selectedDoctor.Key;

                DateTime selectedDate = dateSetApp.Value.Date;
                string selectedTime = comboBoxAppointmentTime.SelectedItem.ToString();

                // Check if the selected time slot is already booked
                bool isTimeSlotBooked = dbHelper.IsTimeSlotBooked(doctorId, selectedDate, selectedTime);

                if (isTimeSlotBooked)
                {
                    // The selected time slot is already booked
                    lblwarning.Visible = true;
                    lblwarning.Text = "This time slot is already booked. Please choose a different time.";
                    
                }
                else
                {
                    // The selected time slot is available, proceed with appointment insertion
                    int patientId = ((KeyValuePair<int, string>)comboBoxPatients.SelectedItem).Key;

                 

                    bool isInserted = dbHelper.InsertAppointmentData(patientId, doctorId, selectedDate, selectedTime);
                    if (isInserted)
                    {
                        // Successfully inserted the appointment
                        lblwarning.Visible = false; // Hide the warning label
                        ManageAppointment manageAppointment = new ManageAppointment();
                        manageAppointment.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Failed to insert the appointment
                        MessageBox.Show("Failed to add appointment.");
                    }
                }
            }
            else
            {
                // Handle case when patient, doctor, or appointment time is not selected
                MessageBox.Show("Please select patient, doctor, and appointment time.");
            }
        }
    }
}
