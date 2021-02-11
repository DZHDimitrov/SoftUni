using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Vehicle> allVehicles = new List<Vehicle>();

            while (input != "End")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = FirstCharToUpper(data[0]);
                string model = data[1];
                string color = data[2];
                int horsePower = int.Parse(data[3]);
                Vehicle currentVehicle = new Vehicle(type, model, color, horsePower);
                allVehicles.Add(currentVehicle);

                input = Console.ReadLine();
            }

            string anotherInput = Console.ReadLine();

            while (anotherInput != "Close the Catalogue")
            {
                string model = anotherInput;
                Vehicle currentVehicle = allVehicles.FirstOrDefault(x => x.Model == model);
                Console.WriteLine(currentVehicle);
                anotherInput = Console.ReadLine();
            }
            List<Vehicle> cars = allVehicles.Where(x => x.Type == "Car").ToList();
            List<Vehicle> trucks = allVehicles.Where(x => x.Type == "Truck").ToList();


            double averageCars = 0.00;
            double averageTrucks = 0.00;
            if (cars.Count > 0)
            {
                double totalCarHp = allVehicles.Where(x => x.Type == "Car").Select(x => x.HorsePower).Sum();
                averageCars = totalCarHp / cars.Count;
            }
            if (trucks.Count > 0)
            {
                double totalTruckHp = allVehicles.Where(x => x.Type == "Truck").Select(x => x.HorsePower).Sum();
                averageTrucks = totalTruckHp / trucks.Count;
            }



            Console.WriteLine($"Cars have average horsepower of: {averageCars:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTrucks:F2}.");
        }
        public static string FirstCharToUpper(string typeVehicle)
        {
            return typeVehicle.First().ToString().ToUpper() + typeVehicle.Substring(1);
        }

    }
    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {Type}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {HorsePower}");

            return sb.ToString().TrimEnd();
        }
    }


}
