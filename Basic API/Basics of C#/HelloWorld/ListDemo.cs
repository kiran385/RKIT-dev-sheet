using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class ListDemo
    {
        public static void MyListDemo()
        {
            List<int> numbers = new List<int>();

            numbers.Add(10);
            numbers.Add(20);
            numbers.AddRange(new[] { 30, 40, 50 });
            numbers.Insert(0, 5);
            numbers.InsertRange(3, new[] { 25, 27 });

            Console.WriteLine("List after Add, AddRange, Insert, InsertRange:");
            Console.WriteLine(string.Join(',',numbers));

            Console.WriteLine($"\nCount: {numbers.Count}");
            Console.WriteLine($"Capacity: {numbers.Capacity}");
            numbers.Capacity = 20;
            Console.WriteLine($"Updated Capacity: {numbers.Capacity}");

            Console.WriteLine($"\nContains 30? {numbers.Contains(30)}");
            Console.WriteLine($"IndexOf 30: {numbers.IndexOf(30)}");
            Console.WriteLine($"LastIndexOf 30: {numbers.LastIndexOf(30)}");
            Console.WriteLine($"Exists > 40? {numbers.Exists(x => x > 40)}");

            Console.WriteLine($"\nFind First > 20: {numbers.Find(x => x > 20)}");
            Console.WriteLine($"Find Last > 20: {numbers.FindLast(x => x > 20)}");
            Console.WriteLine($"FindIndex > 20: {numbers.FindIndex(x => x > 20)}");
            Console.WriteLine($"FindLastIndex > 20: {numbers.FindLastIndex(x => x > 20)}");

            List<int> found = numbers.FindAll(x => x > 20);
            Console.WriteLine("All elements > 20:");
            Console.WriteLine(string.Join(',', found));

            numbers.Sort();
            Console.WriteLine("\nSorted list:");
            Console.WriteLine(string.Join(',', numbers));

            numbers.Reverse();
            Console.WriteLine("\nReversed list:");
            Console.WriteLine(string.Join(',', numbers));

            numbers.Sort();
            int index = numbers.BinarySearch(30);
            Console.WriteLine($"\nBinarySearch for 30: Index = {index}");

            List<string> asStrings = numbers.ConvertAll(x => "Num: " + x);
            Console.WriteLine("\nConvertAll result:");
            foreach (var s in asStrings)
                Console.WriteLine(s);

            int[] array = new int[10];
            numbers.CopyTo(array, 2);
            Console.WriteLine("\nArray after CopyTo (starting at index 2):");
            foreach (var n in array)
                Console.Write($"{n} ");
            Console.WriteLine();

            numbers.Remove(25);
            Console.WriteLine("\nAfter Remove(25):");
            Console.WriteLine(string.Join(',', numbers));

            numbers.RemoveAt(0);
            Console.WriteLine("After RemoveAt(0):");
            Console.WriteLine(string.Join(',', numbers));

            numbers.RemoveRange(0, 2);
            Console.WriteLine("After RemoveRange(0, 2):");
            Console.WriteLine(string.Join(',', numbers));

            numbers.RemoveAll(x => x > 40);
            Console.WriteLine("After RemoveAll(x > 40):");
            Console.WriteLine(string.Join(',', numbers));

            numbers.TrimExcess();
            Console.WriteLine($"\nCapacity after TrimExcess: {numbers.Capacity}");

            numbers.EnsureCapacity(100);
            Console.WriteLine($"Capacity after EnsureCapacity(100): {numbers.Capacity}");

            int[] toArray = numbers.ToArray();
            Console.WriteLine("\nArray from ToArray:");
            foreach (var n in toArray)
                Console.Write($"{n} ");
            Console.WriteLine();

            var readOnlyList = numbers.AsReadOnly();
            //readOnlyList.Add(50);                // gives error because given list is read only list

            Console.WriteLine($"\nEquals: {numbers.Equals(readOnlyList)}"); // False because reference is not same

            Console.WriteLine($"\nHash code of list: {numbers.GetHashCode()}");

            Console.WriteLine($"\nGetType: {numbers.GetType()}");

            Console.WriteLine($"\nTrueForAll (numbers > 0): {numbers.TrueForAll(n => n>0)}");

            Console.WriteLine($"\nGetRange: {string.Join(',',numbers.GetRange(1, 2))}");

            numbers.Clear();
            Console.WriteLine($"\nList cleared. Count: {numbers.Count}");
        }
    }
}
