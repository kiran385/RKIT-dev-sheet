using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class ArrayListDemo
    {
        public static void MyArrayListDemo()
        {
            ArrayList list = new ArrayList();

            list.Add(10);
            list.Add("AA");
            list.AddRange(new object[] { 30, 40, 50 });

            list.Insert(0, 5);

            list.InsertRange(3, new object[] { 'B', 27 });
            
            Console.WriteLine("ArrayList after Add, AddRange, Insert, InsertRange:");
            Console.WriteLine(string.Join(',', list.ToArray()));

            Console.WriteLine($"\nCount: {list.Count}");
            Console.WriteLine($"Capacity: {list.Capacity}");
            list.Capacity = 20;
            Console.WriteLine($"Updated Capacity: {list.Capacity}");
            list.TrimToSize();
            Console.WriteLine($"Capacity after TrimToSize: {list.Capacity}");
            Console.WriteLine($"IsFixedSize: {list.IsFixedSize}");
            Console.WriteLine($"IsReadOnly: {list.IsReadOnly}");
            Console.WriteLine($"IsSynchronized: {list.IsSynchronized}");

            Console.WriteLine($"\nContains 30? {list.Contains(30)}");
            Console.WriteLine($"IndexOf 30: {list.IndexOf(30)}");
            Console.WriteLine($"LastIndexOf 30: {list.LastIndexOf(30)}");

            ArrayList clonedList = (ArrayList)list.Clone();
            Console.WriteLine("\nCloned list:");
            Console.WriteLine(string.Join(',', clonedList.ToArray()));

            ArrayList range = list.GetRange(2, 3);
            Console.WriteLine("\nGetRange(2,3):");
            Console.WriteLine(string.Join(',', range.ToArray()));

            list.Remove(25);
            list.RemoveAt(0);
            list.RemoveRange(0, 2);

            Console.WriteLine("\nList after Remove, RemoveAt, RemoveRange:");
            Console.WriteLine(string.Join(',', list.ToArray()));

            Console.WriteLine("\nToArray:");
            Console.WriteLine(string.Join(",", list.ToArray()));

            list.Reverse();
            Console.WriteLine("\nReversed list:");
            Console.WriteLine(string.Join(',', list.ToArray()));

            list.Clear();
            Console.WriteLine("\nList after Clear:");
            Console.WriteLine($"Count: {list.Count}");
        }
    }
}
