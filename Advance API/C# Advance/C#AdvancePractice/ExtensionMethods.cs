namespace CsharpAdvancePractice
{
    /// <summary>
    /// Class containing extension methods
    /// </summary>
    internal static class ExtensionMethods
    {
        /// <summary>
        /// Method for extension method demo
        /// </summary>
        public static void ExtensionMethodsDemo()
        {
            int a = 15, b = 20;
            Console.WriteLine($"Is even {a}: " + a.IsEven());
            Console.WriteLine($"Is even {b}: " + b.IsEven());

            string str = "hello world";
            Console.WriteLine("String: " + str.ChangeFirstLetter());

            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine("Square of list values");
            foreach (int i in list.Square()) Console.WriteLine(i);
        }

        /// <summary>
        /// Checks if number is even or not
        /// </summary>
        /// <param name="i">number to check</param>
        /// <returns>true if number is even else false</returns>
        public static bool IsEven(this int i)
        {
            return i % 2 == 0;
        }

        /// <summary>
        /// Change first letter of string to upper case
        /// </summary>
        /// <param name="str">string parameter</param>
        /// <returns>string after applied changes</returns>
        public static string ChangeFirstLetter(this string str)
        {
            if(str.Length > 0)
            {
                char[] chars = str.ToCharArray();
                chars[0] = char.ToUpper(chars[0]);
                return new string(chars);
            }
            return str;
        }

        /// <summary>
        /// Square every value of list
        /// </summary>
        /// <param name="list">list of int</param>
        /// <returns>list of squared values</returns>
        public static List<int> Square(this List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i] * list[i];
            }
            return list;
        }
    }
}
