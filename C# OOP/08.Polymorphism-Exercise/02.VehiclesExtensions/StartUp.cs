using _01.Vehicles;
using _01.Vehicles.Core;
using System;

namespace _02.VehiclesExtension
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
