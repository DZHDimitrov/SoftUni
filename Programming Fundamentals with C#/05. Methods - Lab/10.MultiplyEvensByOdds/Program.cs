using System;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            int evens = GetEvenNumSum(number);
            int odds = GetOddNumSum(number);
            int result = evens * odds;
            Console.WriteLine(result);

        }
        static int GetEvenNumSum(int number)
        {
            string numberText = number.ToString();
            int evenSum = 0;
            for (int i = 0; i < numberText.Length; i++)
            {
                if (int.Parse(numberText[i].ToString()) % 2 == 0)
                {
                    evenSum += int.Parse(numberText[i].ToString());
                }
            }
            return evenSum;
        }
        static int GetOddNumSum(int number)
        {
            string numberText = number.ToString();
            int oddSum = 0;
            for (int i = 0; i < numberText.Length; i++)
            {
                if (int.Parse(numberText[i].ToString()) % 2 != 0)
                {
                    oddSum += int.Parse(numberText[i].ToString());
                }
            }
            return oddSum;
        }

    }
}
