using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using WebAPIDemo.Models;
using System.Net;
using WebAPIDemo.BAL;
using System.Web.Http.Cors;

namespace WebAPIDemo.Controllers
{

    /// <summary>
    /// Student controller which contains methods to view, add and delete student
    /// </summary>
    //[EnableCors(origins: "https://www.facebook.com/", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/studentlist")]
    //[JWTAuthorizationFilter]
    public class StudentsV1Controller : ApiController
    {
        // Connection string [MySQL database]
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        /// <summary>
        /// Method for get all student data
        /// </summary>
        /// <returns>List of student data</returns>
        [Route("")]
        [JWTAuthorizationFilter("Admin", "User")]
        public IHttpActionResult GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from student",connection);
                MySqlDataReader reader = command.ExecuteReader();

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
            }
            if (students.Count == 0)
            {
                return Content(HttpStatusCode.NotFound, "No student found!!");
            }
            return Ok(students);
        }

        /// <summary>
        /// Method for get student by id
        /// </summary>
        /// <param name="id">student id</param>
        /// <returns>student data</returns>
        [Route("{id}")]
        public IHttpActionResult GetStudentById(int id)
        {
            Student student = null;
            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from student where id = @ID", connection);
                command.Parameters.AddWithValue("@ID", id);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    student = new Student
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        CGPA = Convert.ToSingle(reader["CGPA"]),
                        AdmissionYear = Convert.ToUInt16(reader["admission_year"])
                    };
                }
            }
            if (student == null)
            {
                return Content(HttpStatusCode.NotFound, $"Student with id {id} is not found!!");
            }
            return Ok(student);
        }

        /// <summary>
        /// Method for add new student to database
        /// </summary>
        /// <param name="student">student id, name, cgpa and academic year</param>
        /// <returns>Success message if student added to database</returns>
        [JWTAuthorizationFilter("Admin")]
        [Route("")]
        public IHttpActionResult Post(Student student)
        {
            if(student == null)
            {
                return BadRequest("Invalid data!!");
            }
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("insert into student(id,name,cgpa,admission_year) values (@Id,@Name,@CGPA,@AdmissionYear)", connection);
                command.Parameters.AddWithValue("@Id", student.Id);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@CGPA", student.CGPA);
                command.Parameters.AddWithValue("@AdmissionYear", student.AdmissionYear);
                command.ExecuteNonQuery();
            }
            return Ok("Student added successfully");
        }

        /// <summary>
        /// Method for delete student by id
        /// </summary>
        /// <param name="id">student id</param>
        /// <returns>Appropriate message if student deleted or not</returns>
        [JWTAuthorizationFilter("Admin")]
        [Route("{id}")]
        public IHttpActionResult DeleteStudent(int id)
        {
            int rowsAffected;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("delete from student where id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                rowsAffected = command.ExecuteNonQuery();
            }
            if (rowsAffected > 0)
            {
                return Ok($"Student with id {id} deleted successfully");
            }
            return Content(HttpStatusCode.NotFound, $"Student with id {id} is not found!!");
        }
    }
}
