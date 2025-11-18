using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAdvancePractice
{
    internal class LambdaExpression
    {
        public static void LambdaExpressionDemo()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            foreach(int i in list.FindAll(x => x%2==0))
            {
                Console.WriteLine(i);
            }

            Action<string> Hello = message => { Console.WriteLine($"\nHello {message}"); };
            Hello("Kiran");
        }
    }
}
