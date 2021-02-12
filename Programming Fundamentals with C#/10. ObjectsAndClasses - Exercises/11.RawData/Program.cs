using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];

                Engine engine = new Engine(enginePower, engineSpeed);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo);

                cars.Add(car);
            }

            string cargosType = Console.ReadLine();

            foreach (Car car in cars)
            {
                if (car.Cargo.Type == "fragile" && car.Cargo.Weight < 1000)
                {
                    Console.WriteLine(car.Model);
                }
                else if (car.Cargo.Type == "flamable" && car.Engine.Power > 250)
                {
                    Console.WriteLine(car.Model);
                }
            }

        }
    }

    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }

        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }

    }
    class Cargo
    {
        public int Weight { get; set; }
        public string Type { get; set; }

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
    }
    class Engine
    {
        public int Power { get; set; }
        public int Speed { get; set; }

        public Engine(int power, int speed)
        {
            Power = power;
            Speed = speed;
        }
    }
}

