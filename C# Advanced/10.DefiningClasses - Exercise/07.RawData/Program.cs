using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < lines; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = data[0];
                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);

                Engine engine = new Engine();
                engine.Speed = engineSpeed;
                engine.Power = enginePower;

                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];

                Cargo cargo = new Cargo();
                cargo.CargoWeight = cargoWeight;
                cargo.CargoType = cargoType;

                double tire1Pressure = double.Parse(data[5]);
                int tire1age = int.Parse(data[6]);
                Tire tire1 = new Tire(tire1Pressure, tire1age);

                double tire2Pressure = double.Parse(data[7]);
                int tire2age = int.Parse(data[8]);
                Tire tire2 = new Tire(tire2Pressure, tire2age);

                double tire3Pressure = double.Parse(data[9]);
                int tire3age = int.Parse(data[10]);
                Tire tire3 = new Tire(tire3Pressure, tire3age);

                double tire4Pressure = double.Parse(data[11]);
                int tire4age = int.Parse(data[12]);
                Tire tire4 = new Tire(tire4Pressure, tire4age);

                Tire[] tires = new Tire[4] { tire1, tire2, tire3, tire4 };

                Car currentCar = new Car(model, engine, tires, cargo);

                cars.Add(currentCar);
            }
            string command = Console.ReadLine();
            
            if (command == "fragile")
            {
                foreach (Car item in cars.Where(x=>x.Cargo.CargoType == "fragile"))
                {
                    foreach (var tire in item.Tires)
                    {
                        if (tire.Pressure<1)
                        {
                            Console.WriteLine(item.Model);
                            break;
                        }
                    }
                    
                }
            }
            else if (command == "flamable")
            {
                foreach (Car item in cars.Where(x=>x.Cargo.CargoType == "flamable").Where(x=>x.Engine.Power > 250))
                {
                    Console.WriteLine(item.Model);
                }
            }
        }
    }
}
