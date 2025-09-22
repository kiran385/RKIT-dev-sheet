using System;
using System.Data;

namespace StudentManagementSystem
{
    internal class StudentManager
    {
        private static List<Student> students = new List<Student>();

        public static void AddStudent()
        {
            Student student = new Student();

            Console.Write("\nEnter Student ID : ");
            student.StudentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Student Name : ");
            student.Name = Console.ReadLine();

            Console.Write("Enter Student Age : ");
            student.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter Academic Year : ");
            student.AcademicYear = (Year)int.Parse(Console.ReadLine());

            if(StudentFile.SaveToFile(student))
            {
                Console.WriteLine("\nStudent Added Successfully");
            }
        }

        public static void ViewStudents()
        {
            students = StudentFile.LoadFromFile();

            if (students.Count > 0)
            {
                Console.WriteLine("\n{0,-12} | {1,-20} | {2,-10} | {3,-15}", 
                    "Student ID", "Name", "Age", "Academic Year");
                Console.WriteLine(new String('-', 65));

                foreach (Student student in students)
                {
                    Console.WriteLine("{0,-12} | {1,-20} | {2,-10} | {3,-15}", 
                        student.StudentId, student.Name, student.Age, student.AcademicYear);
                }
            }
            else
            {
                Console.WriteLine("\nNo Student Found!!");
            }
        }

        public static void DeleteStudent()
        {
            Console.Write("\nEnter Student Id to delete : ");
            int Id = int.Parse(Console.ReadLine());

            students = StudentFile.LoadFromFile();
            var student = students.Find(s => s.StudentId == Id);

            if(student != null)
            {
                StudentFile.DeleteFromFile(student);
                Console.WriteLine($"\nStudent with Id {Id} is deleted successfully");
            }
            else
            {
                Console.WriteLine($"\nNo Student found with Id {Id}");
            }
        }

    }
}
