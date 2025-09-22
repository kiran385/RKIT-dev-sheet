using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class DictionaryDemo
    {
        public static void MyDictionaryDemo()
        {
            Dictionary<string, int> ages = new Dictionary<string, int>();

            ages.Add("Person1", 30);
            ages.Add("Person2", 25);
            ages.Add("Person3", 35);

            ages["Person4"] = 28; 
            ages["Person1"] = 31;

            Console.WriteLine("Count: " + ages.Count);

            Console.WriteLine("\nKeys:");
            Console.WriteLine(string.Join(", ", ages.Keys));

            Console.WriteLine("\nValues:");
            Console.WriteLine(string.Join(", ", ages.Values));

            Console.WriteLine("\nContains key 'Person2': " + ages.ContainsKey("Person2"));

            Console.WriteLine("\nContains value 35: " + ages.ContainsValue(35));

            if (ages.TryGetValue("Person3", out int person3Age))
            {
                Console.WriteLine("\nPerson3's age: " + person3Age);
            }

            ages.Remove("Person4");

            Console.WriteLine($"\nTryAdd Person5: {ages.TryAdd("Person5", 22)}"); // True

            Console.WriteLine($"\nEnsureCapacity: {ages.EnsureCapacity(10)}");

            ages.TrimExcess();

            Console.WriteLine("\nKey comparer: " + ages.Comparer);

            Console.WriteLine("\nAll key-value pairs:");
            foreach (KeyValuePair<string, int> kvp in ages)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            Dictionary<string, int> anotherDict = ages;
            Console.WriteLine("\nages.Equals(anotherDict): " + ages.Equals(anotherDict)); // True (same reference)

            Console.WriteLine("\nHash code: " + ages.GetHashCode());

            Console.WriteLine("\nGetType: " + ages.GetType());

            ages.Clear();
        }
    }
}
