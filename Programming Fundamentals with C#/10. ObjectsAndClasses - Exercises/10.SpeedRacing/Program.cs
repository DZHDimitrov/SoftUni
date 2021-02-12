using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ObjectsAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] data = Console.ReadLine().Split();

                string model = data[0];
                int fuelAmount = int.Parse(data[1]);
                double fuelConsumption = double.Parse(data[2]);
                Car car = new Car(model, fuelAmount, fuelConsumption);

                cars.Add(car);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string text = command[0];
                string model = command[1];
                int wantedKm = int.Parse(command[2]);

                Car car = cars.Where(x => x.Model == model).ToList().First();

                bool isPossibleToTravel = car.isPossibleToTravel(car, wantedKm);

                if (isPossibleToTravel)
                {
                    car.FuelAmount -= car.FuelConsumptionPerKm * wantedKm;
                    car.TravelledDistance += wantedKm;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                input = Console.ReadLine();
            }
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public int TravelledDistance { get; set; }

        public Car(string model, int fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = fuelConsumption;
            TravelledDistance = 0;
        }
        public bool isPossibleToTravel(Car car, int wantedKm)
        {
            double result = wantedKm * car.FuelConsumptionPerKm;
            if (result > car.FuelAmount)
            {
                return false;
            }
            return true;
        }
    }

}

