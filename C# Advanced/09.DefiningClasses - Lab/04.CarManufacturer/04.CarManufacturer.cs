using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double quantity = double.Parse(Console.ReadLine());
            double consumption = double.Parse(Console.ReadLine());
            Engine engine1 = new Engine(524,1000);
            Engine engine2 = new Engine(450, 890);
            Tire[] tires = new Tire[4] { new Tire(1, 2.2), new Tire(1, 2.2), new Tire(1, 2.2), new Tire(1, 2.2) };

            Car car = new Car(make, model, year, quantity, consumption, engine1,tires);

            Console.WriteLine($"{car.Make} {car.Model} {car.Year} {car.FuelQuantity} {car.FuelConsumption} {car.Engine.HorsePower} {car.Engine.CubicCapacity} {car.Tires.Length}");
                  
        }
    }
}
