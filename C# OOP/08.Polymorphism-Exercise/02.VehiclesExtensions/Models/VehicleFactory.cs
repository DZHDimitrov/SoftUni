using _01.Vehicles.Common;
using _02.VehiclesExtension.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    public class VehicleFactory
    {
        public VehicleFactory()
        {

        }

        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity,double fuelConsumption,int tankCapacity)
        {
            Vehicle vehicle = null;
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                throw new InvalidOperationException(Exceptions.INVALID_VEHICLE_EXC);
            }
            return vehicle;
        }
    }
}
