using System;
namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            FamilyCar car = new FamilyCar(150,5.00);
            Console.WriteLine(car.FuelConsumption);

            RaceMotorcycle racemotorcycle = new RaceMotorcycle(10,30);
            Console.WriteLine(racemotorcycle.FuelConsumption);
            CrossMotorcycle crossMotorcycle = new CrossMotorcycle(5,20);
            Console.WriteLine(crossMotorcycle.FuelConsumption);
            Console.WriteLine(crossMotorcycle.Fuel);
            crossMotorcycle.Drive(10);
            Console.WriteLine(crossMotorcycle.Fuel);

        }
    }
}

