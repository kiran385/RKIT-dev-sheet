using System;
using System.Text;

namespace HelloWorld
{
    public class StringDemo
    {
        public static void MyStringDemo()
        {
            string s = "Hello World";
            string s2 = @"\n This is another string";  //verbatim string

            Console.WriteLine(s);
            Console.WriteLine(s2);

            Console.WriteLine($"Length : {s.Length}");  //string interpolation

            Console.WriteLine($"ToUpper : {s.ToUpper()}");

            Console.WriteLine($"ToLower : {s.ToLower()}");

            Console.WriteLine($"StartsWith : {s.StartsWith("Hello")}");

            Console.WriteLine($"EndsWith : {s.EndsWith("world")}");

            Console.WriteLine($"Contains : {s.Contains("ll")}");

            Console.WriteLine($"IndexOf : {s.IndexOf("l")}");

            Console.WriteLine($"LastIndexOf : {s.LastIndexOf("l")}");

            Console.WriteLine($"Equals : {s.Equals("Hello World")}");

            Console.WriteLine($"Replace : {s.Replace("ll","RR")}");

            Console.WriteLine($"Remove : {s.Remove(5)}");

            Console.WriteLine($"Insert : {s.Insert(5," This is Code")}");

            Console.WriteLine($"PadLeft : {s.PadLeft(15,'*')}");

            Console.WriteLine($"PadRight : {s.PadRight(15,'*')}");

            foreach (var item in s.Split(' ')) {  Console.WriteLine($"Split : {item}"); }

            Console.WriteLine($"Trim : {s.Insert(0,"   |   ").Trim()}");

            Console.WriteLine($"Substring : {s.Substring(6,3)}");

            foreach(var c in "abc".ToCharArray()) { Console.WriteLine($"ToCharArray : {c}"); }

            Console.WriteLine($"IsNullOrEmpty : {string.IsNullOrEmpty("")}");

            Console.WriteLine($"IsNullOrWhiteSpace : {string.IsNullOrWhiteSpace(" ")}");

            StringBuilder sb = new StringBuilder("Hello");

            sb.Append(" World");
            Console.WriteLine($"Append : {sb}");

            sb.Insert(5, ",");
            Console.WriteLine($"Insert : {sb}");

            sb.Replace("World", "C#");
            Console.WriteLine($"Replace : {sb}");

            sb.Remove(5, 2);
            Console.WriteLine($"Remove : {sb}");

            sb.Length = 5;
            Console.WriteLine($"Length of 5 : {sb}");
        }
    }
}
