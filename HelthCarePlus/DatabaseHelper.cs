using System;
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

        public class ResourceData
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public DateTime CreateAt { get; set; }

          
        }

        // Method to retrieve data from the "resource" table
        public List<ResourceData> GetResourceData()
        {
            List<ResourceData> resourceData = new List<ResourceData>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT ID, Name, CreatedAt FROM resources";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            DateTime createdAt = reader.GetDateTime(2);

                            ResourceData data = new ResourceData
                            {
                                ID = id,
                                Name = name,
                                CreateAt = createdAt
                            };

                            resourceData.Add(data);
                        }
                    }
                }
            }

            return resourceData;
        }

        public bool InsertResourceData(string name)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO resources (Name) VALUES (@name)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                    

                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if the insertion was successful (1 row affected)
                        return rowsAffected == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
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
            public string DoctorName { get; set; }
            public string PatientName { get; set; }
            public DateTime AppointmentDate { get; set; }
            public string AppointmentTime { get; set; }

            public string ChargedStatus { get; set; }
        }

        public class Admit
        {
            public int Id { get; set; }
            public int PatientId { get; set; }
            
            public DateTime DateAdmitted { get; set; }
            public string PatientFirstName { get; set; }
            public string PatientLastName { get; set; }

            public string ChargedStatus { get; set; }
            public int RoomNumber { get; set; }

            public int Price { get; set; }
           
        }

        public List<Admit> GetAllAdmitsWithDetails()
        {
            List<Admit> admits = new List<Admit>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
            SELECT a.id, a.patient_id, a.room_id, a.date_admitted, a.charged,
                   p.first_name AS patient_first_name, p.last_name AS patient_last_name,
                   r.room_number, r.ac, r.price
            FROM admits AS a
            JOIN patient AS p ON a.patient_id = p.id
            JOIN room AS r ON a.room_id = r.id";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int admitId = Convert.ToInt32(reader["id"]);
                            int patientId = Convert.ToInt32(reader["patient_id"]);
                            int roomId = Convert.ToInt32(reader["room_id"]);
                            DateTime dateAdmitted = Convert.ToDateTime(reader["date_admitted"]);
                            int charged = Convert.ToInt32(reader["charged"]);
                            string patientFirstName = reader["patient_first_name"].ToString();
                            string patientLastName = reader["patient_last_name"].ToString();
                            int roomNumber = Convert.ToInt32(reader["room_number"]);
                            int roomAC = Convert.ToInt32(reader["ac"]);
                            int price = Convert.ToInt32(reader["price"]); 
                            string chargedStatus = charged == 0 ? "Pending" : "Done";

                            Admit admit = new Admit
                            {
                                Id = admitId,
                                PatientId = patientId,
                                DateAdmitted = dateAdmitted,
                                ChargedStatus = chargedStatus, // Use the mapped value
                                PatientFirstName = patientFirstName,
                                PatientLastName = patientLastName,
                                RoomNumber = roomNumber,
                                Price = price
                            };

                            admits.Add(admit);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }

            return admits;
        }

        public Admit GetAdmitById(int admitId)
        {
            Admit admit = null;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT a.id, a.patient_id, a.room_id, a.date_admitted, a.charged,
                       p.first_name AS patient_first_name, p.last_name AS patient_last_name,
                       r.room_number, r.ac, r.price
                FROM admits AS a
                JOIN patient AS p ON a.patient_id = p.id
                JOIN room AS r ON a.room_id = r.id
                WHERE a.id = @admitId"; // Use a parameter for the admitId
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@admitId", admitId); // Add the parameter

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Parse the data as before
                            int patientId = Convert.ToInt32(reader["patient_id"]);
                            int roomId = Convert.ToInt32(reader["room_id"]);
                            DateTime dateAdmitted = Convert.ToDateTime(reader["date_admitted"]);
                            int charged = Convert.ToInt32(reader["charged"]);
                            string patientFirstName = reader["patient_first_name"].ToString();
                            string patientLastName = reader["patient_last_name"].ToString();
                            int roomNumber = Convert.ToInt32(reader["room_number"]);
                            int roomAC = Convert.ToInt32(reader["ac"]);
                            int price = Convert.ToInt32(reader["price"]);
                            string chargedStatus = charged == 0 ? "Pending" : "Done";

                            admit = new Admit
                            {
                                Id = admitId,
                                PatientId = patientId,
                                DateAdmitted = dateAdmitted,
                                ChargedStatus = chargedStatus, // Use the mapped value
                                PatientFirstName = patientFirstName,
                                PatientLastName = patientLastName,
                                RoomNumber = roomNumber,
                                Price = price
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }

            return admit;
        }


        public List<KeyValuePair<int, string>> GetPatientDataForComboBox()
        {
            List<KeyValuePair<int, string>> patientData = new List<KeyValuePair<int, string>>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id, CONCAT(first_name, ' ', last_name) AS full_name FROM patient";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int patientId = Convert.ToInt32(reader["id"]);
                            string fullName = reader["full_name"].ToString();

                            patientData.Add(new KeyValuePair<int, string>(patientId, fullName));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }

            return patientData;
        }

        public List<KeyValuePair<int, string>> GetRoomDataForComboBox()
        {
            List<KeyValuePair<int, string>> roomData = new List<KeyValuePair<int, string>>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id, room_number FROM room";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int roomId = Convert.ToInt32(reader["id"]);
                            string roomNumber = reader["room_number"].ToString();

                            roomData.Add(new KeyValuePair<int, string>(roomId, "Room " + roomNumber));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }

            return roomData;
        }

        public bool CreateAdmit(int patientId, int roomId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO admits (patient_id, room_id) VALUES (@patientId, @roomId)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@patientId", patientId);
                    command.Parameters.AddWithValue("@roomId", roomId);

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



        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
    SELECT a.id, a.patient_id, a.doctor_id, a.date, a.time, 
           p.first_name as patient_first_name, p.last_name as patient_last_name, 
           d.first_name as doctor_first_name, d.last_name as doctor_last_name,
           CASE
               WHEN a.charged = '0' THEN 'Pending'
               WHEN a.charged = '1' THEN 'Done'
               ELSE 'Unknown'
           END as ChargedStatus
    FROM appointment AS a
    JOIN patient AS p ON a.patient_id = p.id
    JOIN doctor AS d ON a.doctor_id = d.id"; 
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int appointmentId = Convert.ToInt32(reader["id"]);
                            int patientId = Convert.ToInt32(reader["patient_id"]);
                            int doctorId = Convert.ToInt32(reader["doctor_id"]);
                            DateTime appointmentDate = Convert.ToDateTime(reader["date"]);
                            string appointmentTime = reader["time"].ToString();
                            string patientName = reader["patient_first_name"].ToString() + " " + reader["patient_last_name"].ToString();
                            string doctorName = reader["doctor_first_name"].ToString() + " " + reader["doctor_last_name"].ToString();
                            string ChanrgedStatus = reader["ChargedStatus"].ToString();


                          

                            Appointment appointment = new Appointment
                            {
                               
                                Id = appointmentId,
                                AppointmentDate = appointmentDate.Date,
                                AppointmentTime = appointmentTime,
                                PatientName = patientName,
                                DoctorName = doctorName,
                                ChargedStatus = ChanrgedStatus
                            };

                            appointments.Add(appointment);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.ToString());
                }
            }

            return appointments;
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            Appointment appointment = null;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT a.id, a.patient_id, a.doctor_id, a.date, a.time, 
           p.first_name as patient_first_name, p.last_name as patient_last_name, 
           d.first_name as doctor_first_name, d.last_name as doctor_last_name,
           CASE
               WHEN a.charged = '0' THEN 'Pending'
               WHEN a.charged = '1' THEN 'Done'
               ELSE 'Unknown'
           END as ChargedStatus
    FROM appointment AS a
    JOIN patient AS p ON a.patient_id = p.id
    JOIN doctor AS d ON a.doctor_id = d.id
                WHERE a.id = @appointmentId"; // Use a parameter for the appointmentId
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@appointmentId", appointmentId); // Add the parameter

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int patientId = Convert.ToInt32(reader["patient_id"]);
                            int doctorId = Convert.ToInt32(reader["doctor_id"]);
                            DateTime appointmentDate = Convert.ToDateTime(reader["date"]);
                            string appointmentTime = reader["time"].ToString();
                            string patientName = reader["patient_first_name"].ToString() + " " + reader["patient_last_name"].ToString();
                            string doctorName = reader["doctor_first_name"].ToString() + " " + reader["doctor_last_name"].ToString();
                            string ChanrgedStatus = reader["ChargedStatus"].ToString();

                            appointment = new Appointment
                            {
                                Id = appointmentId,
                                AppointmentDate = appointmentDate.Date,
                                AppointmentTime = appointmentTime,
                                PatientName = patientName,
                                DoctorName = doctorName,
                                ChargedStatus = ChanrgedStatus
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.ToString());
                }
            }

            return appointment;
        }

        public bool UpdateAppointmentChargedStatusById(int appointmentId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE appointment SET charged = 1 WHERE id = @appointmentId";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@appointmentId", appointmentId);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected (1 means success, 0 means no matching appointment found)
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.ToString());
                    return false; // Return false to indicate an error occurred
                }
            }
        }


        public bool UpdateAdmitChargedStatusById(int admitId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE admits SET charged = 1 WHERE id = @admitId";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@admitId", admitId);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected (1 means success, 0 means no matching admit found)
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.ToString());
                    return false; // Return false to indicate an error occurred
                }
            }
        }




    }
}
