﻿using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double consumption = double.Parse(Console.ReadLine());
            double quantity = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Console.WriteLine(firstCar.WhoAmI());
            Car secondCar = new Car(make,model,year);
            Console.WriteLine(secondCar.WhoAmI());
            Car thirdCar = new Car(make,model,year,quantity,consumption);
            Console.WriteLine(thirdCar.WhoAmI());

        }
    }
}