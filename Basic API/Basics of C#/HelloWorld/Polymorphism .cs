using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class CompileTimePolymorphism
    {
        public void Display(int n)
        {
            Console.WriteLine("Display number : " +  n);
        }
        public void Display(string s)
        {
            Console.WriteLine("Display string : " + s);
        }
    }

    public class Engineer
    {
        public virtual void Role()
        {
            Console.WriteLine("This include all employee");
        }
    }
    public class Developer : Engineer
    {
        public override void Role()
        {
            Console.WriteLine("This is developer role");
        }
    }
    public class Polymorphism
    {
        public static void PolymorphismDemo()
        {
            CompileTimePolymorphism Obj1 = new CompileTimePolymorphism();
            Obj1.Display(111);
            Obj1.Display("Hello!!!!!!!");

            Engineer Obj2 = new Developer();
            Obj2.Role();
        }
    }
}
