using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class DataType
    {
        public static void DataTypeDemo()
        {
            // Data types
            int i = 2;
            long l = 120000L;
            float f = 3.14F;
            double d = 13.13;
            char c = 'K';
            string s = "Kiran";
            bool b = true;
            Console.WriteLine($" i : {i} \n l : {l} \n f : {f} \n d : {d} \n c : {c} \n s : {s} \n b : {b}");

            // Type casting 
            d = i;
            Console.WriteLine($"Implicit casting (int to double) : {d}");
            i = (int)f;
            Console.WriteLine($"Explicit casting (float to int) : {i}");
            Console.WriteLine($"To int : {Convert.ToInt16(f)}");
            Console.WriteLine($"To String : {Convert.ToString(f)}");
            Console.WriteLine($"To Boolean : {Convert.ToBoolean(f)}");
            Console.WriteLine($"To char : {Convert.ToChar(65)}");
            Console.WriteLine($"Parse : {int.Parse("999")}");
            Console.WriteLine($"TryParse : {int.TryParse("1000", out int result)} and value is {result}");
        }
    }
}
