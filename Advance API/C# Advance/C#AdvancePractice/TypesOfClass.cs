using CsharpAdvancePractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAdvancePractice
{
    public abstract class AbstractClass
    {
        public abstract void Method1();
        public void Method2()
        {
            Console.WriteLine("Abstract class method");
        }
    }
    public static class StaticClass
    {
        public static void Method1()
        {
            Console.WriteLine("Static class method");
        }
    }

    public sealed class SealedClass : AbstractClass
    {
        public override void Method1()
        {
            Console.WriteLine("Sealed class method");
        }
    }
    //public class s : SealedClass         // can not inherite sealed class

    public partial class GenericsClass
    {
        public static void Method1()
        {
            Console.WriteLine("This is partial class");
        }
    }

    internal class TypesOfClass
    {
        public static void TypesOfClassDemo()
        {
            StaticClass.Method1();

            new SealedClass().Method1();
            new SealedClass().Method2();

            Console.WriteLine($"Partial class output: {GenericsClass.CompareValues(10, 10)}");
        }
    }
}
