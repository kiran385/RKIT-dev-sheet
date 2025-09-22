using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Input
    {
        public static void InputDemo()
        {
            Console.Write("Enter some input : ");
            //int input = Convert.ToInt16(Console.ReadLine());
            //Console.WriteLine(input);
            string input = Console.ReadLine();
            int i;
            int.TryParse(input, out i);
            Console.WriteLine(i);

            //const double a = 10.25;

            //Console.WriteLine("{0}",a); 
            //Console.WriteLine("{0:0}",a); 
            //Console.WriteLine("{0:0.0}",a); 
            //Console.WriteLine("{0:0.00}",a); 
            //Console.WriteLine("{0:0.00000}",a); 
        }
    }
}
