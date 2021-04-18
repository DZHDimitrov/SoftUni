using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double additionalFuelCons = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumption => base.FuelConsumption + additionalFuelCons;

        public override void Refuel(double liters)
        {
            FuelQuantity += liters * 0.95;
        }
    }
}
