using System;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            int wonBattles = 0;
            int lineCounter = 1;
            string input = Console.ReadLine();

            while (input != "End of battle")
            {
                int currentDistance = int.Parse(input);
                if (currentDistance > initialEnergy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {initialEnergy} energy");
                    return;
                }
                wonBattles++;
                if (lineCounter % 3 == 0)
                {
                    initialEnergy += wonBattles;
                }
                initialEnergy -= currentDistance;
                lineCounter++;

                input = Console.ReadLine();
            }
            Console.WriteLine($"Won battles: {wonBattles}. Energy left: {initialEnergy}");
        }
    }
}
