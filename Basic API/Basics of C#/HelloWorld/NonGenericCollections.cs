using System;
using System.Collections;

namespace HelloWorld
{
    public class NonGenericCollections
    {
        public static void NonGenericCollectionsDemo()
        {
            // ArrayList
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add("String in ArrayList");
            Console.WriteLine("ArrayList output");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            // HashTable
            Hashtable ht = new Hashtable();
            ht["name"] = "Name in HashTable";
            ht["id"] = 1;
            Console.WriteLine("\nHashtable output");
            foreach (var value in ht.Values)
            {
                Console.WriteLine(value);
            }

            // SortedList
            SortedList sl = new SortedList();
            sl["b"] = "Banana";
            sl["a"] = "Apple";
            sl["c"] = "Cherry";
            Console.WriteLine("\nSortedList output");
            foreach (var item in sl.Values)
            {
                Console.WriteLine(item);
            }

            // Stack
            Stack s = new Stack();
            s.Push(10);
            s.Push(20);
            s.Push(30);
            Console.WriteLine("\nStack output");
            foreach (var item in s)
            {
                Console.WriteLine(item);
            }

            // Queue
            Queue q = new Queue();
            q.Enqueue(100);
            q.Enqueue(200);
            q.Enqueue(300);
            Console.WriteLine("\nQueue output");
            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
        }
    }
}
