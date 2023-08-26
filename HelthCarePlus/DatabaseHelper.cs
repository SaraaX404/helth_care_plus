﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace HelthCarePlus
{
    internal class DatabaseHelper
    {
        private static readonly string _connectionString = "Server=localhost;Port=3306;Database=helth_care_plus;Uid=root;Pwd=805914";


        public class UserSession
        {
            private static UserSession _instance;

            public int RoleId { get; private set; }

            private UserSession()
            {
                // Private constructor to prevent direct instantiation
            }

            public static UserSession Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new UserSession();
                    }
                    return _instance;
                }
            }

            public void SetRoleId(int roleId)
            {
                RoleId = roleId;
            }
        }

        

        public Dictionary<int, string> GetRoleNames()
        {
            Dictionary<int, string> roleNames = new Dictionary<int, string>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, name FROM role"; // Assuming 'id' is the column for role ID
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int roleId = Convert.ToInt32(reader["id"]);
                            string roleName = reader["name"].ToString();

                            roleNames.Add(roleId, roleName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return roleNames;
        }
        public bool InsertUserData(string firstName, string lastName, int roleId, string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string hashedPassword = HashPassword(password);

                    string query = "INSERT INTO user (first_name, last_name, role_id, username, password) VALUES (@firstName, @lastName, @roleId, @username, @password)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@roleId", roleId);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", hashedPassword);

                    int rowsAffected = command.ExecuteNonQuery();
                    UserSession.Instance.SetRoleId(roleId);
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }


        public bool AuthenticateUser(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT password, role_id FROM user WHERE username = @username";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashedPasswordFromDatabase = reader["password"].ToString();
                            int roleId = Convert.ToInt32(reader["role_id"]);

                            if (hashedPasswordFromDatabase != null)
                            {
                                string hashedPasswordInput = HashPassword(password);
                                if (hashedPasswordFromDatabase.Equals(hashedPasswordInput))
                                {
                                    UserSession.Instance.SetRoleId(roleId); // Set the role ID in the session
                                    return true;
                                }
                            }
                        }
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }



        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public class User
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int RoleId { get; set; }
            public string Username { get; set; }
            public string Status { get; set; }

        }

        public class Doctor
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Contact { get; set; }
            public string Specialize { get; set; }
        }

        public bool InsertDoctorData(string firstName, string lastName, string contact, string specialize)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO doctor (first_name, last_name, contact, specialize) VALUES (@firstName, @lastName, @contact, @specialize)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@contact", contact);
                    command.Parameters.AddWithValue("@specialize", specialize);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }


        public int GetLastInsertedDoctorId()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT LAST_INSERT_ID()"; // MySQL function to get the last inserted ID
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // ExecuteScalar returns the first column of the first row from the result set
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int lastInsertedId))
                    {
                        return lastInsertedId;
                    }
                    else
                    {
                        return -1; // Some default value or error indication
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                    return -1; // Some default value or error indication
                }
            }
        }

        public class Schedule
        {
            public int DoctorId { get; set; }
            public int DayId { get; set; }
        }

        public bool InsertScheduleData(int doctorId, List<int> selectedDayIds)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();


                    foreach (int dayId in selectedDayIds)

                    {
                        string query = "INSERT INTO schedule (doc_id, day_id) VALUES (@doctorId, @dayId)";
                      
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@doctorId", doctorId);
                        command.Parameters.AddWithValue("@dayId", dayId);
                        

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected <= 0)
                        {
                            // If insertion fails for any day, return false
                            return false;
                        }
                    }

                    return true; // All days were inserted successfully
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }


        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, first_name, last_name, role_id,status, username FROM user";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int userId = Convert.ToInt32(reader["id"]);
                            string firstName = reader["first_name"].ToString();
                            string lastName = reader["last_name"].ToString();
                            int roleId = Convert.ToInt32(reader["role_id"]);
                            string username = reader["username"].ToString();
                            string status = reader["status"].ToString();

                            User user = new User
                            {
                                Id = userId,
                                FirstName = firstName,
                                LastName = lastName,
                                RoleId = roleId,
                                Username = username,
                                Status = status
                            };

                            users.Add(user);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Console.WriteLine(ex.ToString());
                }
            }

            return users;
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, first_name, last_name, contact, specialize FROM doctor";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int doctorId = Convert.ToInt32(reader["id"]);
                            string firstName = reader["first_name"].ToString();
                            string lastName = reader["last_name"].ToString();
                            string contact = reader["contact"].ToString();
                            string specialize = reader["specialize"].ToString();

                            Doctor doctor = new Doctor
                            {
                                Id = doctorId,
                                FirstName = firstName,
                                LastName = lastName,
                                Contact = contact,
                                Specialize = specialize
                            };

                            doctors.Add(doctor);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
              
                }
            }

            return doctors;
        }

        public class Patient
        {

            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Contact { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
        }


        public bool InsertPatientData(string firstName, string lastName, string contact, int age, string gender)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO patient (first_name, last_name, contact, age, gender) VALUES (@firstName, @lastName, @contact, @age, @gender)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@contact", contact);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@gender", gender);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }

        public bool IsTimeSlotBooked(int doctorId, DateTime date, string time)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM appointment WHERE doctor_id = @doctorId AND date = @date AND time = @time";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@doctorId", doctorId);
                    command.Parameters.AddWithValue("@date", date.Date); // Use only the date portion
                    command.Parameters.AddWithValue("@time", time);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0; // If count is greater than 0, the time slot is booked
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                    return false; // Return false in case of an exception
                }
            }
        }

        public bool InsertAppointmentData(int patientId, int doctorId, DateTime date, string time)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO appointment (patient_id, doctor_id, date, time) VALUES (@patientId, @doctorId, @date, @time)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@patientId", patientId);
                    command.Parameters.AddWithValue("@doctorId", doctorId);
                    command.Parameters.AddWithValue("@date", date.Date); // Store only the date portion
                    command.Parameters.AddWithValue("@time", time);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }

        public bool IsDoctorAvailableOnDay(int doctorId, int dayId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM schedule WHERE doc_id = @doctorId AND day_id = @dayId";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@doctorId", doctorId);
                    command.Parameters.AddWithValue("@dayId", dayId);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0; // If there are any records, the doctor is available
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, first_name, last_name, contact, age, gender FROM patient";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader["first_name"].ToString();
                            string lastName = reader["last_name"].ToString();
                            string contact = reader["contact"].ToString();
                            int age = Convert.ToInt32(reader["age"]);
                            string gender = reader["gender"].ToString();
                            int id = Convert.ToInt32(reader["id"]);

                            Patient patient = new Patient
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                Contact = contact,
                                Age = age,
                                Gender = gender,
                                Id = id
                            };

                            patients.Add(patient);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return patients;
        }

        public bool InsertRoomData(int roomNumber, int price, int ac)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO room (room_number, price, ac) VALUES (@roomNumber, @price, @ac)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@roomNumber", roomNumber);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@ac", ac);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }

        public List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id, room_number, price, ac FROM room";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int roomId = Convert.ToInt32(reader["id"]);
                            int roomNumber = Convert.ToInt32(reader["room_number"]);
                            int price = Convert.ToInt32(reader["price"]);
                            int ac = Convert.ToInt32(reader["ac"]);

                            Room room = new Room
                            {
                                Id = roomId,
                                RoomNumber = roomNumber,
                                Price = price,
                                Ac = ac
                            };

                            rooms.Add(room);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return rooms;
        }

        public class Room
        {
            public int Id { get; set; }
            public int RoomNumber { get; set; }
            public int Price { get; set; }
            public int Ac { get; set; }
        }

        public class Appointment
        {
            public int Id { get; set; }
            public int DoctorId { get; set; }
            public int PatientId { get; set; }
            public DateTime AppointmentDate { get; set; }
        }

        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, patient_id, doctor_id, date, time FROM appointment";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int appointmentId = Convert.ToInt32(reader["id"]);
                            int patientId = Convert.ToInt32(reader["patient_id"]);
                            int doctorId = Convert.ToInt32(reader["doctor_id"]);
                            DateTime appointmentDate = Convert.ToDateTime(reader["date"]);
                            TimeSpan appointmentTime = TimeSpan.Parse(reader["time"].ToString());

                            Appointment appointment = new Appointment
                            {
                                Id = appointmentId,
                                PatientId = patientId,
                                DoctorId = doctorId,
                                AppointmentDate = appointmentDate.Date + appointmentTime
                            };

                            appointments.Add(appointment);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return appointments;
        }




    }
}
