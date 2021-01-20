using System;

namespace InvalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowerQ = int.Parse(Console.ReadLine());
            double budget = int.Parse(Console.ReadLine());
            double rosesSum = 0;
            double dahliasSum = 0;
            double tulipsSum = 0;
            double narcissusSum = 0;
            double gladiolusSum = 0;


            if (flowerType == "Roses")
            {
                rosesSum = flowerQ * 5.00;
                if (flowerQ > 80)
                {
                    rosesSum -= rosesSum * 0.10;
                }
                budget -= rosesSum;
            }

            else if (flowerType == "Dahlias")
            {
                dahliasSum = flowerQ * 3.80;
                if (flowerQ > 90)
                {
                    dahliasSum -= dahliasSum * 0.15;
                }
                budget -= dahliasSum;
            }

            else if (flowerType == "Tulips")
            {
                tulipsSum = flowerQ * 2.80;
                if (flowerQ > 80)
                {
                    tulipsSum -= tulipsSum * 0.15;
                }
                budget -= tulipsSum;
            }

            else if (flowerType == "Narcissus")
            {
                narcissusSum = flowerQ * 3.00;
                if (flowerQ < 120)
                {
                    narcissusSum += narcissusSum * 0.15;
                }
                budget -= narcissusSum;
            }

            else if (flowerType == "Gladiolus")
            {
                gladiolusSum = flowerQ * 2.50;
                if (flowerQ < 80)
                {
                    gladiolusSum += gladiolusSum * 0.20;
                }
                budget -= gladiolusSum;
            }

            if (budget >= 0)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerQ} {flowerType} and {budget:F2} leva left.");
            }

            else if (budget < 0)
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(budget):F2} leva more.");
            }
        }
    }
}