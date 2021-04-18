using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Contracts
{
    public interface IVehicle : IDriveable, IRefuelable
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }
    }
}
