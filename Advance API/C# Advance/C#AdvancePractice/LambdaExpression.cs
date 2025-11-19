namespace CsharpAdvancePractice
{
    /// <summary>
    /// Class containing LambdaExpressionDemo method
    /// </summary>
    internal class LambdaExpression
    {
        /// <summary>
        /// Method for lambda expression demo
        /// </summary>
        public static void LambdaExpressionDemo()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            foreach(int i in list.FindAll(x => x%2==0))
            {
                Console.WriteLine(i);
            }

            Action<string> Hello = message => { Console.WriteLine($"\nHello {message}"); };
            Hello("Kiran");
        }
    }
}
