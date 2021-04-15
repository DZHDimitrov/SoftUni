using _08.MilitaryElite_.Core;
using _08.MilitaryElite_.Core.Contracts;

namespace _08.MilitaryElite_
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
