using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{

    public abstract class c1
    {
        public abstract void Method1();
        public void Method2()
        {
            Console.WriteLine("Method 2");
        }
    }
    public interface IPayment
    {
        void Pay(float amount);
    }
    public interface ISuccess
    {
        void Success();
    }
    public class Cash : c1, IPayment, ISuccess
    {
        public void Pay(float amount)
        {
            Console.WriteLine($"Rs. {amount} paid with cash");
        }

        public void Success()
        {
            Console.WriteLine("Success");
        }

        public override void Method1()
        {
            Console.WriteLine("Method 1");
        }

        public void Method2()
        {
            base.Method2();
            Console.WriteLine("Method 2 in cash class");
        }
    }
    public class UPI : IPayment
    {
        public void Pay(float amount)
        {
            Console.WriteLine($"Rs. {amount} paid via UPI");
        }
    }

    public class a
    {
        public void method1()
        {
            Console.WriteLine("A M1");
        }
        public void method2()
        {
            Console.WriteLine("A M2");
        }
        public void method3()
        {
            Console.WriteLine("A M3");
        }
    }
    public class b : a
    {
        public void method1()
        {
            Console.WriteLine("B M1");
            this.method3();
        }
    }
    public class c : b
    {
        public void method2()
        {
            Console.WriteLine("C M2");
            base.method2();
        }
        public void method3()
        {
            Console.WriteLine("C M3");
        }
    }

    public class Interface
    {
        public static void InterfaceDemo()
        {
            c obj = new c();
            obj.method2();
        }
    }
}
