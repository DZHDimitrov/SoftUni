using _01.Vehicles.Core;
using System;

namespace _01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
