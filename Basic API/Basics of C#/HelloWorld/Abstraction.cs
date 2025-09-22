using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{

    // Using abstract class
    abstract class Animal
    {
        public abstract void MakeSound(); // Abstract method
        public void Eat()                 // Non-abstract method
        {
            Console.WriteLine("Animal is eating.");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks.");
        }
    }


    // Using interface
    interface Bird
    {
        public void Fly();
    }

    class Parrot : Bird
    {
        public void Fly()
        {
            Console.WriteLine("Bird is flying");
        }
        public void Sound()
        {
            Console.WriteLine("Bird is singing");
        }
    }

    public class Abstraction
    {
        public static void AbstractionDemo()
        {
            Animal myDog = new Dog();
            myDog.MakeSound();
            myDog.Eat();

            Parrot myBird = new Parrot();
            myBird.Fly();
            myBird.Sound();
        }
    }
}
