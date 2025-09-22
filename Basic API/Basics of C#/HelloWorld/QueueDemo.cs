using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class QueueDemo
    {
        public static void MyQueueDemo()
        {
            Queue<int> queue = new Queue<int>();

            Console.WriteLine($"TryDequeue: {queue.TryDequeue(out int r)}"); // False

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Console.WriteLine($"Count: {queue.Count}"); // 3

            Console.WriteLine($"Peek: {queue.Peek()}"); // 10

            Console.WriteLine($"Dequeued: {queue.Dequeue()}"); // 10

            Console.WriteLine($"Contains 20? {queue.Contains(20)}"); // True

            Console.WriteLine("ToArray result:");
            Console.WriteLine(string.Join(", ", queue.ToArray())); // 20, 30

            queue.Clear();
            Console.WriteLine($"Count after Clear(): {queue.Count}"); // 0

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            int[] arr = new int[10];
            queue.CopyTo(arr, 5);
            Console.WriteLine("ToArray: " + string.Join(',', arr));

            queue.TrimExcess();
            
            queue.EnsureCapacity(10);

            Console.WriteLine($"Type: {queue.GetType()}");

            Console.WriteLine($"HashCode: {queue.GetHashCode()}");

            Queue<int> anotherQueue = queue;
            Console.WriteLine($"Equals anotherQueue: {queue.Equals(anotherQueue)}"); // True
        }
    }
}
