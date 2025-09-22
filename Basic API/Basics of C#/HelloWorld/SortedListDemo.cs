using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class SortedListDemo
    {
        public static void MySortedListDemo()
        {
            SortedList<int, string> students = new SortedList<int, string>();

            students.Add(102, "Student1");
            students.Add(101, "Student2");
            students.Add(103, "Student3");

            Console.WriteLine("Initial sorted list:");
            foreach (var kvp in students)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            students[104] = "Student4"; // Adds new entry
            students[102] = "Student5"; // Updates value for key 102

            Console.WriteLine($"\nCount: {students.Count}");

            Console.WriteLine($"ContainsKey(101): {students.ContainsKey(101)}"); // True

            Console.WriteLine($"ContainsValue(\"Student3\"): {students.ContainsValue("Student3")}"); // True

            students.Remove(103);

            students.RemoveAt(0); // Removes the item with the smallest key

            Console.WriteLine("\nAll Keys:");
            foreach (var key in students.Keys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("\nAll Values:");
            foreach (var value in students.Values)
            {
                Console.WriteLine(value);
            }

            if (students.TryGetValue(104, out string name))
            {
                Console.WriteLine($"\nValue for key 104: {name}");
            }

            int index = students.IndexOfKey(104);
            Console.WriteLine($"IndexOfKey(104): {index}");

            int valueIndex = students.IndexOfValue("Student4");
            Console.WriteLine($"IndexOfValue(\"Student4\"): {valueIndex}");

            string valueAtIndex = students.Values[index];
            Console.WriteLine($"Value at index {index}: {valueAtIndex}");

            int keyAtIndex = students.Keys[index];
            Console.WriteLine($"Key at index {index}: {keyAtIndex}");

            students.TrimExcess();

            Console.WriteLine($"\nType: {students.GetType()}");
            Console.WriteLine($"HashCode: {students.GetHashCode()}");

            SortedList<int, string> reference = students;
            Console.WriteLine($"Equals(reference): {students.Equals(reference)}"); // True

            students.Clear();
            Console.WriteLine($"Count after Clear(): {students.Count}");
        }
    }
}
