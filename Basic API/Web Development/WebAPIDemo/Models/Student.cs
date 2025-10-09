using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    /// <summary>
    /// Student modal
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Student id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Student name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Student CGPA
        /// </summary>
        public float CGPA { get; set; }
        /// <summary>
        /// Admission year of student
        /// </summary>
        public int AdmissionYear { get; set; }
    }
}