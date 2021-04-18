using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Common
{
    public static class Exceptions
    {
        public const string notEnoughFuelExc = "{0} needs refueling";
        public const string INVALID_VEHICLE_EXC = "Invalid input!";
        public const string TOO_MUCH_FUEL_EXC = "Cannot fit {0} fuel in the tank";
        public const string INVALID_FUEL_QNTTY_EXC = "Fuel must be a positive number";
        public const string succDriveMSG = "{0} travelled {1} km";
    }
}
