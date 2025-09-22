using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class Person
    {
        private string name;
        private int age;
        public string Name
        {
            get { return string.IsNullOrEmpty(this.name) ? "Empty" : this.name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0) age = value;
                else throw new Exception("Age must be greater than 0");
            }
        }
    }
    public class Encapsulation
    {
        public static void EncapsulationDemo()
        {
            Person Student = new Person();
            //Student.Name = "Kiran";
            Student.Age = 20;
            Console.WriteLine("Name of student is " + Student.Name + " and age is " + Student.Age);
        }
    }
}
