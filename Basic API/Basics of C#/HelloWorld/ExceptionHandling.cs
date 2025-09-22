using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException() : base("Age must be greater than 0 and less than 150") { }
    }
    public class ExceptionHandling
    {
        public static void ExceptionHandlingDemo()
        {
            try
            {
                int a = 10, b = 0;
                //Console.WriteLine(a / b);

                int[] numbers = new int[] { 1, 2, 3 };
                //Console.WriteLine(numbers[5]);

                Console.Write("Enter your age : ");
                int i = int.Parse(Console.ReadLine());
                if(i <= 0)
                {
                    throw new InvalidAgeException();
                }
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
            catch (InvalidAgeException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("\nFinally block\n");
            }
        }
    }
}
