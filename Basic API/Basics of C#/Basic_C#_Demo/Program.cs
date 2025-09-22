using System;
using StudentManagementSystem;

namespace StudentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Student Management Menu ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        StudentManager.AddStudent();
                        break;
                    case "2":
                        StudentManager.ViewStudents();
                        break;
                    case "3":
                        StudentManager.DeleteStudent();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}