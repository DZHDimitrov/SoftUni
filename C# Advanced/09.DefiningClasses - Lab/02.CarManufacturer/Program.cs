using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "VW";
            car.Model = "Golf";
            car.Year = 2009;
            car.FuelConsumption = 50;
            car.FuelQuantity = 500;
            car.Drive(5);
            car.WhoAmI();
        }
    }
}
