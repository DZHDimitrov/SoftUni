using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    class Car
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            double result = distance * FuelConsumption;
            if (FuelQuantity - result > 0)
            {
                
                FuelQuantity -= result;
                Console.WriteLine("Good Ride!!!");
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            return $"Make: {Make} Model: {Model} Year: { Year}Fuel: { FuelQuantity:F2}";
        }
    }
}
