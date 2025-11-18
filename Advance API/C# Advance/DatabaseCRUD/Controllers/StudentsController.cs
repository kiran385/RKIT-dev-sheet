using DatabaseCRUD.BAL;
using DatabaseCRUD.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DatabaseCRUD.Controllers
{
    /// <summary>
    /// Controller for student APIs
    /// </summary>
    public class StudentsController : ApiController
    {
        private BL_Student _objStudent = new BL_Student();

        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns>List of students</returns>
        public IHttpActionResult Get()
        {
            List<Student> students = _objStudent.GetAllStudents();
            if(students.Count > 0)
            {
                return Ok(students);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No student found!!");
            }
        }

        /// <summary>
        /// Get student by its id
        /// </summary>
        /// <param name="id">Student id</param>
        /// <returns>Student data if found</returns>
        public IHttpActionResult Get(int id)
        {
            Student student = _objStudent.GetStudentById(id);
            if(student != null)
            {
                return Ok(student);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No student found!!");
            }
        }

        /// <summary>
        /// Add new student
        /// </summary>
        /// <param name="student">Student data</param>
        /// <returns>Appropriate message if data added or not</returns>
        public IHttpActionResult Post(Student student)
        {
            bool isSuccess = _objStudent.AddStudent(student);
            if(isSuccess)
            {
                return Content(HttpStatusCode.OK, "Student added successfully");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Something went wrong!!");
            }
        }

        /// <summary>
        /// Update student data
        /// </summary>
        /// <param name="id">Student id</param>
        /// <param name="student">New student data</param>
        /// <returns>Appropriate message if data updated or not</returns>
        public IHttpActionResult Put(int id, Student student)
        {
            Student s = _objStudent.GetStudentById(id);
            if(s != null)
            {
                bool isSuccess = _objStudent.UpdateStudent(id, student);
                if (isSuccess)
                {
                    return Content(HttpStatusCode.OK, "Student updated successfully");
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "Something went wrong!!");
                }
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No student found!!");
            }
        }

        /// <summary>
        /// Delete student data by its id
        /// </summary>
        /// <param name="id">Student id</param>
        /// <returns>Appropriate message if data deleted or not</returns>
        public IHttpActionResult Delete(int id)
        {
            Student student = _objStudent.GetStudentById(id);
            if(student != null)
            {
                bool isDeleted = _objStudent.DeleteStudent(id);
                if (isDeleted)
                {
                    return Content(HttpStatusCode.OK, "Student deleted successfully");
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "Something went wrong!!");
                }
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No student found!!");
            }
        }
    }
}
