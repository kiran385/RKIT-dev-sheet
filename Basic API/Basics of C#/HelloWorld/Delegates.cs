using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public delegate void HelloWorldDelegate(string message);

    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
    }

    internal class StudentManager
    {
        public delegate bool StudentFilter(Student student);
        public static void FilterStudent (List<Student> students,StudentFilter filter)
        {
            foreach (Student student in students)
            {
                if(filter(student))
                {
                    Console.WriteLine(student.Name);
                }
            }
        }
    }

    internal class Delegates
    {
        public static void DelegatesDemo()
        {
            HelloWorldDelegate del = new HelloWorldDelegate(PrintMessage);
            del("Hello from Delegate");

            List<Student> list = new List<Student>();
            list.Add(new Student { Name = "A", Age = 20, Grade = 95 }) ;
            list.Add(new Student { Name = "B", Age = 21, Grade = 80 }) ;

            Console.WriteLine("\nStudent with age above 20");
            StudentManager.FilterStudent(list, l => l.Age > 20);

            Console.WriteLine("\nStudent with grade above 80");
            StudentManager.FilterStudent(list, l => l.Grade > 80);

        }
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
