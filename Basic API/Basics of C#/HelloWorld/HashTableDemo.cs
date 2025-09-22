using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class HashTableDemo
    {
        public static void MyHashTableDemo()
        {
            Hashtable hashtable = new Hashtable();

            hashtable.Add("id", 101);
            hashtable.Add("name", "Person1");
            hashtable.Add("active", true);
            hashtable["role"] = "Admin";

            Console.WriteLine("Hashtable contents:");
            foreach(DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"{entry.Key} - {entry.Value}");
            }

            Console.WriteLine($"\nCount: {hashtable.Count}");

            Console.WriteLine($"\nContainsKey(\"id\")? {hashtable.ContainsKey("id")}");
            Console.WriteLine($"ContainsValue(\"Person1\")? {hashtable.ContainsValue("Person1")}");

            Console.WriteLine($"Contains(\"role\")? {hashtable.Contains("role")}");

            Hashtable cloned = (Hashtable)hashtable.Clone();
            Console.WriteLine("\nCloned Hashtable:");
            foreach (DictionaryEntry entry in cloned)
            {
                Console.WriteLine($"{entry.Key} - {entry.Value}");
            }

            hashtable.Remove("active");
            Console.WriteLine("\nAfter removing 'active':");
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"{entry.Key} - {entry.Value}");
            }

            Console.WriteLine("\nKeys:");
            foreach (var key in hashtable.Keys)
                Console.WriteLine(key);

            Console.WriteLine("\nValues:");
            foreach (var value in hashtable.Values)
                Console.WriteLine(value);

            DictionaryEntry[] array = new DictionaryEntry[hashtable.Count];
            hashtable.CopyTo(array, 0);
            Console.WriteLine("\nCopied to array:");
            foreach (var entry in array)
                Console.WriteLine($"{entry.Key} - {entry.Value}");

            Console.WriteLine($"\nIsReadOnly: {hashtable.IsReadOnly}");
            Console.WriteLine($"IsFixedSize: {hashtable.IsFixedSize}");
            Console.WriteLine($"IsSynchronized: {hashtable.IsSynchronized}");

            hashtable.Clear();
            Console.WriteLine("\nHashtable after Clear:");
            Console.WriteLine($"Count: {hashtable.Count}");
        }
    }
}
