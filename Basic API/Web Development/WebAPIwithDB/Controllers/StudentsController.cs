using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;
using WebAPIwithDB.Models;

namespace WebAPIwithDB.Controllers
{
    public class StudentsController : ApiController
    {
        // Connection string [MySQL database]
        //private string connectionString = "Server=localhost;Database=kb;User ID=Admin;Password=gs@123;SslMode=None;";
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        // GET: api/students
        public IHttpActionResult Get()
        {
            List<Student> students = new List<Student>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from student", connection);
                MySqlDataReader reader = command.ExecuteReader(); // reader reads each row from table row by row

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        CGPA = Convert.ToSingle(reader["CGPA"]),
                        AdmissionYear = Convert.ToUInt16(reader["admission_year"])
                    });
                }

                if (students.Count == 0)
                {
                    // Returns 404 if no students found
                    return NotFound();
                }
                return Ok(students);
            }
        }

        public IHttpActionResult Get(int id)
        {
            Student student = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from student where id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    student = new Student
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        CGPA = Convert.ToSingle(reader["CGPA"]),
                        AdmissionYear = Convert.ToInt16(reader["admission_year"])
                    };
                }
                if (student == null)
                {
                    return NotFound();
                }
            }
            return Ok(student);
        }

        public IHttpActionResult Post(Student student)
        {
            if (student == null)
            {
                return BadRequest("Invalid input data");
            }
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("insert into student (id,name,cgpa,admission_year) values(@Id,@Name,@CGPA,@AdmissionYear)", connection);
                command.Parameters.AddWithValue("@Id", student.Id);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@CGPA", student.CGPA);
                command.Parameters.AddWithValue("@AdmissionYear", student.AdmissionYear);
                command.ExecuteNonQuery();
            }
            return Created("api/students", student);
        }

        public IHttpActionResult Delete(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("delete from student where id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    return NotFound();
                }
            }
            return Ok($"Student with id {id} deleted successfully");
        }
    }
}