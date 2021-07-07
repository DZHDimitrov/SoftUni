using MilitaryElite.Core;
using MilitaryElite.Interfaces;
using System;

namespace MilitaryElite
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
