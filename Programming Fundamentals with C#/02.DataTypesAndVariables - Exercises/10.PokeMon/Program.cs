using System;
using System.Linq;

namespace CSharpAdvanced___2
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            double originalValuePower = pokePower;
            int pokedTargets = 0;
            while (true)
            {
                if (pokePower >= distance)
                {
                    pokePower -= distance;
                    pokedTargets++;
                    if (pokePower == originalValuePower - (originalValuePower * 0.50))
                    {
                        if (pokePower >= exhaustionFactor && exhaustionFactor > 0)
                        {
                            pokePower /= exhaustionFactor;
                        }
                    }
                }
                else
                {
                    Console.WriteLine(pokePower);
                    Console.WriteLine(pokedTargets);
                    break;
                }
            }
        }
    }
}
