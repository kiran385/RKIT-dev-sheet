namespace WebAPIwithDB.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float CGPA { get; set; }

        public int AdmissionYear { get; set; }
    }
}