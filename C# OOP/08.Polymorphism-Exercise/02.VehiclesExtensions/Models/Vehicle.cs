using _01.Vehicles.Common;
using _01.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {

        private double fuelQuantity;


        protected Vehicle(double fuelQuantity, double fuelConsumption , int tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            
        }

        public double FuelQuantity 
        {
            get
            {
                return fuelQuantity;
            }
            protected set
            {
                if (value > TankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption { get; protected set; }

        public int TankCapacity { get; }

        public virtual void Drive(double distance)
        {
            if (distance * FuelConsumption > FuelQuantity)
            {
                throw new InvalidOperationException(string.Format(Exceptions.notEnoughFuelExc,this.GetType().Name));
            }
            else
            {
                FuelQuantity -= FuelConsumption * distance;
                Console.WriteLine(String.Format(Exceptions.succDriveMSG,this.GetType().Name,distance));
            }          
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException(Exceptions.INVALID_FUEL_QNTTY_EXC);
            }
            if (liters + FuelQuantity > TankCapacity)
            {
                throw new InvalidOperationException(String.Format(Exceptions.TOO_MUCH_FUEL_EXC, liters));
            }
            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
