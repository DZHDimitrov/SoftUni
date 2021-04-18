using _06.Raiding.Contracts;
using _06.Raiding.Core;
using System;

namespace _06.Raiding
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
