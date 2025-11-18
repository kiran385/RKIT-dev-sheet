using System.Collections.Generic;
using System.Configuration;
using DatabaseCRUD.Models;
using MySql.Data.MySqlClient;

namespace DatabaseCRUD.BAL
{
    /// <summary>
    /// BL_Student class
    /// </summary>
    public class BL_Student
    {
        private string connectionString;

        /// <summary>
        /// Constructor for class BL_Student
        /// </summary>
        public BL_Student()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        }

        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns>List of students</returns>
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            string query = "select id, name, cgpa, admission_year from student";
            
            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using(MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                CGPA = reader.GetFloat("cgpa"),
                                AdmissionYear = reader.GetInt32("admission_year")
                            });
                        }
                    }
                }
            }
            return students;
        }

        /// <summary>
        /// Get student by its id
        /// </summary>
        /// <param name="id">Student id</param>
        /// <returns>Student data if found</returns>
        public Student GetStudentById(int id)
        {
            Student student = null;
            string query = $"select * from student where id = {id}";

            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            student = new Student
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                CGPA = reader.GetFloat("CGPA"),
                                AdmissionYear = reader.GetInt32("admission_year")
                            };
                        }
                    }
                }
            }
            return student;
        }

        /// <summary>
        /// Add new student
        /// </summary>
        /// <param name="student">Student data</param>
        /// <returns>True if data added else false</returns>
        public bool AddStudent(Student student)
        {
            string query = $"insert into student(id, name, cgpa, admission_year) values('{student.Id}', '{student.Name}', '{student.CGPA}', '{student.AdmissionYear}')";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                int rowsAffected;
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    rowsAffected = command.ExecuteNonQuery();
                }
                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Update student data
        /// </summary>
        /// <param name="id">Student id</param>
        /// <param name="student">New student data</param>
        /// <returns>True if data updated else false</returns>
        public bool UpdateStudent(int id, Student student)
        {
            string query = $"update student set id = '{student.Id}', name = '{student.Name}', cgpa = '{student.CGPA}', admission_year = {student.AdmissionYear} where id = {id}";

            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                int rowsAffected;
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    rowsAffected = command.ExecuteNonQuery();
                }
                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Delete student data by its id
        /// </summary>
        /// <param name="id">Student id</param>
        /// <returns>True if data deleted else false</returns>
        public bool DeleteStudent(int id)
        {
            string query = $"delete from student where id = {id}";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                int rowsAffected;
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    rowsAffected = command.ExecuteNonQuery();
                }
                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}