using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    class Car
    {
        public string Model { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public Car(string name, int km, int fuel)
        {
            Model = name;
            Mileage = km;
            Fuel = fuel;
        }
        public override string ToString()
        {
            return $"{Model} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int cars = int.Parse(Console.ReadLine());
            List<Car> allCars = new List<Car>();
            for (int i = 0; i < cars; i++)
            {
                string[] array = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string model = array[0];
                int mileage = int.Parse(array[1]);
                int fuel = int.Parse(array[2]);

                Car car = new Car(model, mileage, fuel);
                allCars.Add(car);
            }
            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] array = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string command = array[0];
                string model = array[1];
                Car currentCar = allCars.FirstOrDefault(x => x.Model == model);
                switch (command)
                {
                    case "Drive":

                        int mileage = int.Parse(array[2]);
                        int fuel = int.Parse(array[3]);

                        if (currentCar.Fuel < fuel)
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        else
                        {
                            currentCar.Mileage += mileage;
                            currentCar.Fuel -= fuel;
                            Console.WriteLine($"{model} driven for {mileage} kilometers. {fuel} liters of fuel consumed.");
                        }
                        if (currentCar.Mileage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {model}!");
                            allCars.Remove(currentCar);
                        }
                        break;
                    case "Refuel":

                        int fuelToAdd = int.Parse(array[2]);

                        if (fuelToAdd + currentCar.Fuel > 75)
                        {
                            int requiredFuel = 75 - currentCar.Fuel;
                            currentCar.Fuel += requiredFuel;
                            Console.WriteLine($"{model} refueled with {requiredFuel} liters");
                        }
                        else if (fuelToAdd + currentCar.Fuel <= 75)
                        {
                            currentCar.Fuel += fuelToAdd;
                            Console.WriteLine($"{model} refueled with {fuelToAdd} liters");
                        }

                        break;
                    case "Revert":

                        int kms = int.Parse(array[2]);
                        currentCar.Mileage -= kms;
                        if (currentCar.Mileage < 10000)
                        {
                            currentCar.Mileage = 10000;
                        }
                        else
                        {
                            Console.WriteLine($"{model} mileage decreased by {kms} kilometers");
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            foreach (Car car in allCars.OrderByDescending(x => x.Mileage).ThenBy(x => x.Model))
            {
                Console.WriteLine(car);
            }

        }
    }
}
