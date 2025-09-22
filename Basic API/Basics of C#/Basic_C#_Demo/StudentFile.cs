using System;
using System.Data;
using System.IO;
using System.Text.Json;

namespace StudentManagementSystem
{
    internal class StudentFile
    {
        private static string fileName = "students.json";
        public static bool SaveToFile(Student student)
        {
            if (!File.Exists(fileName))
            {
                try
                {
                    File.Create(Path.Combine(Directory.GetCurrentDirectory(), fileName));
                    //Console.WriteLine("File created successfully");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            List<Student> existingStudents = LoadFromFile();

            DataTable table = new DataTable();
            table.Columns.Add("StudentId", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Age", typeof(int));
            table.Columns.Add("AcademicYear", typeof(Year));

            table.PrimaryKey = new DataColumn[] { table.Columns["StudentId"] };

            foreach (var s in existingStudents)
            {
                table.Rows.Add(s.StudentId, s.Name, s.Age, s.AcademicYear);
            }

            if (table.Rows.Find(student.StudentId) != null)
            {
                Console.WriteLine($"\nStudent with Id {student.StudentId} already exist!");
                return false;
            }

            existingStudents.Add(student);
            string data = JsonSerializer.Serialize(existingStudents, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, data);

            return true;
        }

        public static List<Student> LoadFromFile()
        {
            if(!File.Exists(fileName))
            {
                return new List<Student>();
            }
            string data = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Student>>(data) ?? new List<Student>();
        }

        public static void DeleteFromFile(Student student)
        {
            List<Student> existingStudents = LoadFromFile();
            existingStudents.RemoveAll(s => s.StudentId == student.StudentId);
            string data = JsonSerializer.Serialize(existingStudents, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, data);
        }
    }
}
