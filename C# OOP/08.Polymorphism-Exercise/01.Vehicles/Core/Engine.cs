using _01.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Core
{
    public class Engine : IEngine
    {
        private VehicleFactory vehicleFactory;
        private Vehicle car;
        private Vehicle truck;
        public Engine()
        {
            vehicleFactory = new VehicleFactory();
        }

        public void Run()
        {
            car = this.ProcessVehicleInfo();
            truck = this.ProcessVehicleInfo();

            int vehicles = int.Parse(Console.ReadLine());

            for (int i = 0; i < vehicles; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string command = cmdArgs[0];
                string vehicle = cmdArgs[1];
                double args = double.Parse(cmdArgs[2]);
                try
                {
                    CallVehicle(command, vehicle, args);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private void CallVehicle(string command, string vehicle, double args)
        {
            if (command == "Drive")
            {
                if (vehicle == "Car")
                {
                    car.Drive(args);
                }
                else if (vehicle == "Truck")
                {
                    truck.Drive(args);
                }
            }
            else if (command == "Refuel")
            {
                if (vehicle == "Car")
                {
                    car.Refuel(args);
                }
                else if (vehicle == "Truck")
                {
                    truck.Refuel(args);
                }
            }
        }

        private Vehicle ProcessVehicleInfo()
        {
            Vehicle vehicle;
            string[] cmdArgs = Console.ReadLine().Split();
            string type = cmdArgs[0];
            double fuelQuantity = double.Parse(cmdArgs[1]);
            double fuelConsumption = double.Parse(cmdArgs[2]);
            vehicle = vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption);

            return vehicle;
        }
    }
}
