namespace CsharpAdvancePractice
{
    /// <summary>
    /// Class containing example of generic method
    /// </summary>
    public partial class GenericsClass
    {
        /// <summary>
        /// Static method calling other methods
        /// </summary>
        public static void GenericsDemo()
        {
            Console.WriteLine(CompareValues(10, 20));
            Console.WriteLine(CompareValues("10", "10"));
        }

        /// <summary>
        /// Compare values using object type
        /// </summary>
        /// <param name="x">Value 1</param>
        /// <param name="y">Value 2</param>
        /// <returns>True if values are same else False</returns>
        public static bool CompareValues(object x, object y)
        {
            return x == y;
        }

        /// <summary>
        /// Compare values using generics T type
        /// </summary>
        /// <typeparam name="T">Type of parameter</typeparam>
        /// <param name="x">Value 1</param>
        /// <param name="y">Value 2</param>
        /// <returns>True if values are same else False</returns>
        public static bool CompareValues<T>(T x, T y)
        {
            return x.Equals(y);
        }
    }
}
