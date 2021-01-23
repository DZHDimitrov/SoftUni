using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {

            int sumPrimeNumbers = 0;
            int sumNonPrimeNumber = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "stop")
                {
                    break;
                }
                int currentNumber = int.Parse(input);
                if (currentNumber < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }
                int counterDivision = 0;
                for (int i = 1; i <= currentNumber; i++)
                {
                    if (currentNumber % i == 0)
                    {
                        counterDivision++;
                    }
                }
                if (counterDivision == 2)
                {
                    sumPrimeNumbers += currentNumber;
                }
                else
                {
                    sumNonPrimeNumber += currentNumber;
                }
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrimeNumbers}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrimeNumber}");
        }
    }
}
