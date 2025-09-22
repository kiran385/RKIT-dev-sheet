using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class Method
    {
        public static void MethodDemo()
        {
            // Simple method 
            DisplayName();

            // method with arguments
            DisplayName("Kiran Baraiya");

            // method with named arguments
            DisplayName(age: 20, name: "Kiran Baraiya");

            int a = 10;

            // Argument passed by value
            Change(a);
            Console.WriteLine($"Argument passed by value : {a}");

            // Argument passed by reference
            Change(ref a);
            Console.WriteLine($"Argument passed by reference : {a}");

            // Argument passed by out
            OutMethod(out int b);
            Console.WriteLine($"Argument passed by out : {b}");
        }

        public static void DisplayName()
        {
            Console.WriteLine("This method shows name");
        }

        // Method with default parameters
        public static void DisplayName(string name, int age = 19)
        {
            Console.WriteLine($"My name is {name} and age is {age}");
        }

        public static void Change(int a)
        {
            a = 100;
        }
        
        public static void Change(ref int a)
        {
            a = 100;
        }

        public static void OutMethod(out int b)
        {
            b = 1000;
        }
    }
}
