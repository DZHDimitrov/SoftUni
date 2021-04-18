using _01.Vehicles.Common;
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

        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity,double fuelConsumption)
        {
            Vehicle vehicle = null;
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            else
            {
                throw new InvalidOperationException(Exceptions.INVALID_VEHICLE_EXC);
            }
            return vehicle;
        }
    }
}
