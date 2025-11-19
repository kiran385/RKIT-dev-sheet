namespace CsharpAdvancePractice
{
    /// <summary>
    /// Abstract class declared using abstract keyword
    /// </summary>
    public abstract class AbstractClass
    {
        /// <summary>
        /// Abstract method which has no implementation
        /// </summary>
        public abstract void Method1();

        /// <summary>
        /// Non abstract method which has implementation
        /// </summary>
        public void Method2()
        {
            Console.WriteLine("Abstract class method");
        }
    }

    /// <summary>
    /// Static class declared using static keyword
    /// </summary>
    public static class StaticClass
    {
        /// <summary>
        /// Static method 
        /// </summary>
        public static void Method1()
        {
            Console.WriteLine("Static class method");
        }
    }

    /// <summary>
    /// Sealed class declared using sealed keyword
    /// And inherit AbstractClass
    /// </summary>
    public sealed class SealedClass : AbstractClass
    {
        /// <summary>
        /// Override method of abstract class
        /// </summary>
        public override void Method1()
        {
            Console.WriteLine("Sealed class method");
        }
    }

    //public class s : SealedClass         // can not inherite sealed class

    /// <summary>
    /// Partial class declared using partial keyword
    /// </summary>
    public partial class GenericsClass
    {
        /// <summary>
        /// Static method
        /// </summary>
        public static void Method1()
        {
            Console.WriteLine("This is partial class");
        }
    }

    /// <summary>
    /// Class containing all other class access
    /// </summary>
    internal class TypesOfClass
    {
        /// <summary>
        /// Static method which access all methods
        /// </summary>
        public static void TypesOfClassDemo()
        {
            StaticClass.Method1();

            new SealedClass().Method1();
            new SealedClass().Method2();

            Console.WriteLine($"Partial class output: {GenericsClass.CompareValues(10, 10)}");
        }
    }
}
