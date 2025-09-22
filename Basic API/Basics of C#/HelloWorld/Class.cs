using System;

namespace HelloWorld
{
    public partial class Vehicle
    {
        int wheels;
        public string name;
        public Vehicle(string name,int wheels) 
        {
            this.name = name;
            this.wheels = wheels;
        }
        public Vehicle(string name)
        {
            this.name = name;
        }

        // Property for get and set private fields
        public int Wheels
        {
            get { return wheels; }
            set { wheels = value; }
        }
    }
    public class Class
    {
        public static void ClassDemo()
        {
            Vehicle Car = new Vehicle("Car",4);
            Console.WriteLine($"{Car.name} has {Car.Wheels} wheels");

            Vehicle Bike = new Vehicle("Bike");
            Bike.Wheels = 2;
            Console.WriteLine($"{Bike.name} has {Bike.Wheels} wheels");
        }
    }
}
