using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class Manager : Employee
    {
        public new void GetDetails()
        {
            Console.WriteLine("This is hiding base class Employee method");
        }
    }
    public class MethodHiding
    {

        public static void MethodHidingDemo()
        {
            Manager employee = new Manager();
            employee.GetDetails();
        }
    }
}
