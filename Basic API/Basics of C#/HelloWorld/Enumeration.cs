using System;
using System.Collections.Generic;

namespace HelloWorld
{
    public enum WeekDay
    {
        Monday, Tuesday, Wednesday, Thursday = 10, Friday, Saturday, Sunday
    }
    public class Enumeration
    {
        public static void EnumerationDemo()
        {
            foreach(WeekDay d in Enum.GetValues(typeof(WeekDay)))
            {
                Console.WriteLine($"{(int)d} - {d}");
            }
        }
    }
}
