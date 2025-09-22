using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class StackDemo
    {
        public static void MyStackDemo()
        {
            Stack<int> stack = new Stack<int>();

            Console.WriteLine($"TryPop: {stack.TryPop(out int r)}"); // False

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            
            Console.WriteLine($"Count: {stack.Count}"); // 3

            Console.WriteLine($"Top element (Peek): {stack.Peek()}"); // 30

            Console.WriteLine($"Popped element: {stack.Pop()}"); // 30

            Console.WriteLine($"Contains 10? {stack.Contains(10)}"); // True

            Console.WriteLine("Stack copied to array:");
            Console.WriteLine(string.Join(", ", stack.ToArray())); // 20, 10

            stack.TrimExcess();

            stack.EnsureCapacity(10);

            stack.Clear();
            Console.WriteLine($"Count after Clear(): {stack.Count}"); // 0

            Stack<string> names = new Stack<string>(new[] { "Person1", "Person2", "Person3" });

            Console.WriteLine($"\nType: {names.GetType()}");

            Console.WriteLine($"HashCode: {names.GetHashCode()}");

            Stack<string> anotherNames = names;
            Console.WriteLine($"Equals(anotherNames): {names.Equals(anotherNames)}"); // True
        }
    }
}
