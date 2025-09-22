using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
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

    // public class s : SealedClass         // can not inherite sealed class

    public partial class Vehicle
    {
        public int GetWheels()
        {
            return wheels;
        }
    }

    public  class TypesOfClass
    {
        public static void TypesOfClassDemo()
        {
            StaticClass.Method1 ();

            new SealedClass().Method1();
            new SealedClass().Method2();

            Console.WriteLine("\nPartial class output");
            Vehicle Car = new Vehicle("Car", 4);
            Console.WriteLine($"{Car.name} has {Car.GetWheels()} wheels");
        }
    }
}
