using _01.Vehicles.Common;
using _01.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private const string succDriveMSG = "{0} travelled {1} km";

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }

        public virtual double FuelConsumption { get; }

        public void Drive(double distance)
        {
            if (distance * FuelConsumption > FuelQuantity)
            {
                throw new InvalidOperationException(string.Format(Exceptions.notEnoughFuelExc,this.GetType().Name));
            }
            else
            {
                FuelQuantity -= FuelConsumption * distance;
                Console.WriteLine(String.Format(succDriveMSG,this.GetType().Name,distance));
            }          
        }

        public virtual void Refuel(double liters)
        {
            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
