using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            for (int i = number1; i <= number2; i++)
            {
                string currentNumber = i.ToString();
                int sumEven = 0;
                int sumOdd = 0;
                for (int j = 0; j < currentNumber.Length; j++)
                {
                    int currentDigit = int.Parse(currentNumber[j].ToString());
                    if (j % 2 == 0)
                    {
                        sumEven += currentDigit;
                    }
                    else if (j % 2 != 0)
                    {
                        sumOdd += currentDigit;
                    }
                }
                if (sumEven == sumOdd)
                {
                    Console.Write(currentNumber + " ");
                }
            }
        }
    }
}
