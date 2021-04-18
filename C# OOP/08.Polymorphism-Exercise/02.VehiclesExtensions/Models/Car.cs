using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double additionalFuelCons = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + additionalFuelCons;
    }
}
