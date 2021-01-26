using System;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                string currentNumber = i.ToString();
                int sum = 0;
                for (int j = 0; j < currentNumber.Length; j++)
                {
                    int currentDigit = int.Parse(currentNumber[j].ToString());
                    sum += currentDigit;
                }
                if (sum == 5 | sum == 7 | sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}