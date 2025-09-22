using System;
using System.Collections.Generic;

namespace HelloWorld
{
    public class GenericCollections
    {
        public static void GenericCollectionsDemo()
        {
            // List
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Insert(0, 0);
            Console.WriteLine("List output");
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("Index of 1 is {0}",list.IndexOf(1));

            // Dictionary
            Dictionary<int,string> d = new Dictionary<int,string>();
            d[1] = "One";
            d[2] = "Two";
            Console.WriteLine("\nDictionary output");
            //foreach (var value in d.Values)
            //{
            //    Console.WriteLine(value);
            //}
            foreach(KeyValuePair<int,string> pair in d)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }

            // Hashset
            HashSet<int> h = new HashSet<int>();
            h.Add(10);
            h.Add(20);
            h.Add(10);
            Console.WriteLine("\nHashSet output");
            foreach (var item in h)
            {
                Console.WriteLine(item);
            }

            // Stack
            Stack<int> s = new Stack<int>();
            s.Push(100);
            s.Push(200);
            Console.WriteLine("\nStack output");
            foreach (var item in s)
            {
                Console.WriteLine(item);
            }

            // Queue
            Queue<string> q = new Queue<string>();
            q.Enqueue("One");
            q.Enqueue("Two");
            Console.WriteLine("\nQueue output");
            foreach (var item in q)
            {
                Console.WriteLine(item);
            }

            // SortedList
            SortedList<int,int> keyValuePairs = new SortedList<int,int>();
            keyValuePairs.Add(10, 20);
            keyValuePairs.Add(5, 30);
            Console.WriteLine("\nSortedList output");
            foreach (var item in keyValuePairs)
            {
                Console.WriteLine(item);
            }
        }
    }
}
