using _01.Vehicles.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double additionalFuelCons = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double FuelConsumption => base.FuelConsumption + additionalFuelCons;

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException(Exceptions.INVALID_FUEL_QNTTY_EXC);
            }
            if ((liters*0.95) + FuelQuantity > TankCapacity)
            {
                throw new InvalidOperationException(String.Format(Exceptions.TOO_MUCH_FUEL_EXC, liters));
            }

            FuelQuantity += liters * 0.95;
        }
    }
}
