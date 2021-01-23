using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());
            int combinationsCounter = 0;

            for (char i = start; i <= end; i++)
            {
                for (char j = start; j <= end; j++)
                {
                    for (char k = start; k <= end; k++)
                    {
                        if (k != third && j != third && i != third)
                        {
                            combinationsCounter++;
                            Console.Write($"{i}{j}{k} ");
                        }
                    }
                }
            }
            Console.Write(combinationsCounter);
        }
    }
}