using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int engines = int.Parse(Console.ReadLine());
            List<Engine> allEngines = new List<Engine>();

            for (int i = 0; i < engines; i++)
            {
                string[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Queue<string> queue = new Queue<string>(array);
                Engine engine = new Engine();
                while (queue.Count > 0)
                {
                    engine.Model = queue.Dequeue();
                    engine.Power = int.Parse(queue.Dequeue());
                    if (queue.Count == 0)
                    {
                        break;
                    }
                    string data = queue.Dequeue();
                    int number;
                    bool success = int.TryParse(data, out number);

                    if (success)
                    {
                        engine.Displacement = int.Parse(data);
                    }
                    else
                    {
                        engine.Efficiency = data;
                    }
                    if (queue.Count == 0)
                    {
                        break;
                    }
                    engine.Efficiency = queue.Dequeue();
                }
                allEngines.Add(engine);
            }

            int linesAboutCars = int.Parse(Console.ReadLine());

            List<Car> allCars = new List<Car>();
            for (int i = 0; i < linesAboutCars; i++)
            {
                string[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Queue<string> queue = new Queue<string>(array);
                Car car = new Car();
                while (queue.Count > 0)
                {
                    car.Model = queue.Dequeue();
                    string engineModel = queue.Dequeue();
                    car.Engine = allEngines.FirstOrDefault(x => x.Model == engineModel);
                    if (queue.Count == 0)
                    {
                        break;
                    }
                    string data = queue.Dequeue();

                    int number;
                    bool success = int.TryParse(data, out number);
                    if (success)
                    {
                        car.Weight = int.Parse(data);
                    }
                    else
                    {
                        car.Color = data;
                    }

                    if (queue.Count == 0)
                    {
                        break;
                    }
                    car.Color = queue.Dequeue();
                }
                allCars.Add(car);
            }
            foreach (Car car in allCars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine(car.Engine);
                Console.WriteLine($"{car}");
                
            }
        }
    }
}
