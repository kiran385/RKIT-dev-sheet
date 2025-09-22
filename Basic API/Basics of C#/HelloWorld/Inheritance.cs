using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class Employee
    {
        string name;
        int age;
        public Employee() 
        {
            //Console.WriteLine("Parent class constructor");
        }
        public Employee(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void GetDetails()
        {
            Console.Write($"Employee name is {name} and age is {age}");
        }
    }

    public class FullTime : Employee
    {
        private float yearlySalary;
        public FullTime(string name, int age) : base(name,age)
        {
            //Console.WriteLine("Child class constructor");
        }
        public float YearlySalary
        {
            get { return yearlySalary; }
            set { yearlySalary = value; }
        }
    }

    public class PartTime : Employee
    {
        private float hourlySalary;
        public PartTime(string name, int age) : base(name,age)
        {
            //Console.WriteLine("Child class constructor");
        }
        public float HourlySalary
        {
            get { return hourlySalary; }
            set { hourlySalary = value; }
        }
    }

    public class Inheritance
    {
        public static void InheritanceDemo()
        {
            FullTime emp1 = new FullTime("Full Time", 25);
            emp1.GetDetails();
            emp1.YearlySalary = 500000;
            Console.WriteLine($" and yearly salary is {emp1.YearlySalary}");

            PartTime emp2 = new PartTime("Part Time", 30);
            emp2.GetDetails();
            emp2.HourlySalary = 200;
            Console.WriteLine($" and hourly salary is {emp2.HourlySalary}");
        }
    }
}
