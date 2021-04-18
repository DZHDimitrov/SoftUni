using _04.WildFarm.Contracts;
using System;

namespace _04.WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
