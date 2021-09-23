using System;

namespace Decorator_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Coffee espresso = new Espresso();
            Console.WriteLine(new string('-',15) + "Clean Espresso");
            Console.WriteLine(espresso.cost());
            Console.WriteLine(espresso.GetDescription());

            Console.WriteLine();
            Console.WriteLine(new string('-', 15) + "Espresso with milk");

            espresso = new WithMilk(espresso);
            Console.WriteLine(espresso.cost());
            Console.WriteLine(espresso.GetDescription());

            Console.WriteLine();
            Console.WriteLine(new string('-', 15) + "Espresso with double milk");

            espresso = new WithMilk(espresso);
            Console.WriteLine(espresso.cost());
            Console.WriteLine(espresso.GetDescription());

            Console.WriteLine();
            Console.WriteLine(new string('-', 15) + "Espresso with double milk and sugar");

            espresso = new WithSugar(espresso);
            Console.WriteLine(espresso.cost());
            Console.WriteLine(espresso.GetDescription());
        }
    }
}
