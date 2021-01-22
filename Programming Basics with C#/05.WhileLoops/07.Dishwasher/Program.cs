using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBottles = int.Parse(Console.ReadLine());
            double quantityDetergent = numberOfBottles * 750;
            double plates = 0;
            double pots = 0;
            bool isEmpty = false;
            int i = 1;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                int dishes = int.Parse(input);
                if (i % 3 == 0 && i != 1)
                {
                    quantityDetergent -= dishes * 15;
                    pots += dishes;
                }

                else
                {
                    quantityDetergent -= dishes * 5;
                    plates += dishes;
                }
                if (quantityDetergent < 0)
                {
                    isEmpty = true;
                    break;
                }

                i++;
            }

            if (isEmpty)
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(quantityDetergent)} ml. more necessary!");
            }
            else
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{plates} dishes and {pots} pots were washed.");
                Console.WriteLine($"Leftover detergent {quantityDetergent} ml.");
            }



        }
    }
}
