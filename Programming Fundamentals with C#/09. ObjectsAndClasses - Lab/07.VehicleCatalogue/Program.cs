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
            string input = Console.ReadLine();
            Catalogue catalogue = new Catalogue();
            while (input != "end")
            {
                string[] data = input.Split("/");
                string type = data[0];
                string brand = data[1];
                string model = data[2];
                int hpOrWeight = int.Parse(data[3]);

                switch (type)
                {
                    case "Truck":
                        Truck truck = new Truck(brand, model, hpOrWeight);
                        catalogue.Trucks.Add(truck);
                        break;
                    case "Car":
                        Car car = new Car(brand, model, hpOrWeight);
                        catalogue.Cars.Add(car);
                        break;
                }
                input = Console.ReadLine();
            }

            if (catalogue.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in catalogue.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalogue.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in catalogue.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }


    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public int Weight { get; set; }

        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }
    }
    class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }
        public Car(string brand, string model, int hp)
        {
            Brand = brand;
            Model = model;
            HorsePower = hp;
        }
    }

    class Catalogue
    {
        public List<Truck> Trucks { get; set; }

        public List<Car> Cars { get; set; }
        public Catalogue()
        {
            Trucks = new List<Truck>();
            Cars = new List<Car>();
        }

    }

}

