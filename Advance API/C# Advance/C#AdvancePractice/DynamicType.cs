namespace CsharpAdvancePractice
{
    internal class DynamicType
    {
        public static void DynamicTypeDemo()
        {
            dynamic variable;

            variable = 2;
            Console.WriteLine($"Value: {variable}, Type: {variable.GetType()}");

            // Assigning char value
            variable = 'k';
            Console.WriteLine($"Value: {variable}, Type: {variable.GetType()}");

            // Assigning boolean value
            variable = true;
            Console.WriteLine($"Value: {variable}, Type: {variable.GetType()}");

            // Assigning double value
            variable = 5.3;
            Console.WriteLine($"Value: {variable}, Type: {variable.GetType()}");

            // Assigning string value
            variable = "Hello world!";
            Console.WriteLine($"Value: {variable}, Type: {variable.GetType()}");

            // Assigning array of integers
            variable = new int[] { 1, 2, 3 };
            Console.WriteLine($"Value: {string.Join(",", variable)}, Type: {variable.GetType()}");

            // Assigning a List<int>
            variable = new List<int> { 1, 2, 3, 4 };
            Console.WriteLine($"Value: {string.Join(",", variable)}, Type: {variable.GetType()}");
        }
    }
}
