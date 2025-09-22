using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class HashSetDemo
    {
        public static void MyHashSetDemo()
        {
            HashSet<int> set = new HashSet<int>();

            set.Add(10);
            set.Add(20);
            set.Add(30);
            set.Add(40);
            set.Add(10); // Duplicate will be ignored

            Console.WriteLine($"Count: {set.Count}"); // 4

            Console.WriteLine("Comparer: " + set.Comparer);

            Console.WriteLine($"Contains 20: {set.Contains(20)}"); // True

            set.Remove(30);
            Console.WriteLine("After removing 30: " + string.Join(", ", set)); // 10, 20, 40

            set.RemoveWhere(x => x > 30);
            Console.WriteLine("After removeWhere > 30: " + string.Join(", ", set)); // 10, 20

            set.UnionWith(new[] { 30, 40, 50 });
            Console.WriteLine("After UnionWith [30, 40, 50]: " + string.Join(", ", set)); // 10, 20, 40, 30, 50

            set.IntersectWith(new[] { 20, 30, 60 });
            Console.WriteLine("After IntersectWith [20, 30, 60]: " + string.Join(", ", set)); // 20, 30

            set.ExceptWith(new[] { 20 });
            Console.WriteLine("After ExceptWith [20]: " + string.Join(", ", set)); // 30

            set.SymmetricExceptWith(new[] { 30, 40 });
            Console.WriteLine("After SymmetricExceptWith [30, 40]: " + string.Join(", ", set)); // 40

            set.Clear();

            set.UnionWith(new[] { 1, 2, 3, 4, 5 });

            Console.WriteLine("IsSubsetOf [1,2,3,4,5,6]: " + set.IsSubsetOf(new[] { 1, 2, 3, 4, 5, 6 })); // True

            Console.WriteLine("IsSupersetOf [2,3]: " + set.IsSupersetOf(new[] { 2, 3 })); // True

            Console.WriteLine("SetEquals [1,2,3,4,5]: " + set.SetEquals(new[] { 5, 4, 3, 2, 1 })); // True

            Console.WriteLine("Overlaps [9,8,1]: " + set.Overlaps(new[] { 9, 8, 1 })); // True

            set.TrimExcess();

            Console.WriteLine("EnsureCapacity: " + set.EnsureCapacity(20));

            int[] array = new int[10];
            set.CopyTo(array);
            Console.WriteLine("Copied to array: " + string.Join(", ", array)); // first N elements copied

            set.CopyTo(array, 2);

            set.CopyTo(array, 5, 2);

            HashSet<int> anotherSet = set;
            Console.WriteLine("Equals anotherSet (same reference): " + set.Equals(anotherSet)); // True

            Console.WriteLine("Hash code: " + set.GetHashCode());

            Console.WriteLine("Type: " + set.GetType());

            set.Clear();
            Console.WriteLine($"Count after Clear: {set.Count}"); // 0
        }
    }
}
