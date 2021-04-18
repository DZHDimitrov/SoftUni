using _01.Vehicles.Common;
using _01.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double FuelConsumption => base.FuelConsumption + 1.4;

        public void DriveEmpty(double distance)
        {
            FuelConsumption -= 1.4;

            if (distance * FuelConsumption > FuelQuantity)
            {
                throw new InvalidOperationException(string.Format(Exceptions.notEnoughFuelExc, this.GetType().Name));
            }
            else
            {
                FuelQuantity -= FuelConsumption * distance;
                Console.WriteLine(String.Format(Exceptions.succDriveMSG, this.GetType().Name, distance));
            }
        }
        
    }
}
