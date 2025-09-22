using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public interface interface1
    {
        void method1();
    }
    public interface interface2
    {
        void method1();
    }
    public class class1 : interface1, interface2
    {
        public void method1()
        {
            Console.WriteLine("This is interface1 method");
        }
        public void method2()
        {
            Console.WriteLine("This is interface2 method");
        }
    }
    public class MultipleInheritance
    {
        public static void MultipleInheritanceDemo()
        {
            class1 obj = new class1();
            obj.method1();
            obj.method2();
        }
    }
}
