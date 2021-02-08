using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
            string player = "left";
            string player1 = "right";
            double sumFirst = 0;
            double sumSecond = 0;

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                if (numbers[i] == 0)
                {
                    sumFirst -= sumFirst * 0.20;
                }
                sumFirst += numbers[i];
            }
            for (int i = numbers.Count - 1; i > numbers.Count / 2; i--)
            {
                if (numbers[i] == 0)
                {
                    sumSecond -= sumSecond * 0.20;
                }
                sumSecond += numbers[i];
            }

            if (sumFirst < sumSecond)
            {
                Console.WriteLine($"The winner is {player} with total time: {sumFirst}");
            }
            else if (sumSecond < sumFirst)
            {
                Console.WriteLine($"The winner is {player1} with total time: {sumSecond}");
            }
        }

    }
}
