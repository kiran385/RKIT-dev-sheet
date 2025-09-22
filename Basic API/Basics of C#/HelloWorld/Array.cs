using System;

namespace HelloWorld
{
    public class Array
    {
        public static void ArrayDemo()
        {
            // 1D array
            int[] numbers = new int[5]; // Declaration and memory allocation
            int[] values = { 100, 100, 30, 40, 50, 60 }; // Initialization with values
            
            Console.WriteLine("1D array with for loop");
            for(int i=0; i<numbers.Length; i++)
            {
                //numbers[i] = i;
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("\n1D array with foreach loop");
            foreach (int i in values)
            {
                Console.Write(i + " ");  
            }
            Console.WriteLine();

            // 2D array
            Console.WriteLine("\n2D array with for loop");
            int[,] grid = new int[2, 3] { { 11,12,13 }, { 21,22,23 } };

            for(int i=0; i<grid.GetLength(0); i++)
            {
                for(int j=0; j<grid.GetLength(1); j++)
                {
                    Console.Write(grid[i,j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n2D array with foreach loop");
            foreach(int i in grid)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // Jagged array
            int[][] jaggedArray = new int[3][]; // 3 elements, each is an array
            jaggedArray[0] = new int[] { 1 };
            jaggedArray[1] = new int[] { 2, 3 };
            jaggedArray[2] = new int[] { 4, 5, 6 };

            Console.WriteLine("\nJagged array with for loop");
            for(int i=0;i<jaggedArray.Length;i++)
            {
                for(int j = 0; j < jaggedArray[i].Length;j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nJagged array with foreach loop");
            foreach(int[] subArray in jaggedArray)
            {
                foreach(int i in subArray)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine() ;
            }

            // Array methods

            // Sort elements of array
            System.Array.Sort(values);

            // Reverse order of element
            System.Array.Reverse(jaggedArray);

            // IndexOf returns first occurrence of the value
            Console.WriteLine("\nIndexOf method output: " + System.Array.IndexOf(values, 100));

            // LastIndexOf returns last occurrence of the value
            Console.WriteLine("\nLastIndexOf method output: " + System.Array.LastIndexOf(values, 100));

            // Clear resets to default value
            System.Array.Clear(values, 1, 2);

            // Copy range of elements 
            System.Array.Copy(values, numbers, 3);
        }
    }
}