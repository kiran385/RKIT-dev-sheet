namespace DatabaseCRUD.Models
{
    /// <summary>
    /// Student Model
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
        /// Current CGPA
        /// </summary>
        public float CGPA { get; set; }

        /// <summary>
        /// Student admission year
        /// </summary>
        public int AdmissionYear { get; set; }
    }
}