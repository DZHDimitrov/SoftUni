using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumption = double.Parse(data[2]);

                Car car = new Car();
                car.Model = model;
                car.FuelAmount = fuelAmount;
                car.FuelConsumptionPerKm = fuelConsumption;
                car.TravelledDistance = 0;

                cars.Add(car);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string model = data[1];
                int km = int.Parse(data[2]);

                var car = cars.FirstOrDefault(x => x.Model == model);
                car.Drive(km);
                
                input = Console.ReadLine();
            }
            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }
        }
    }
}
