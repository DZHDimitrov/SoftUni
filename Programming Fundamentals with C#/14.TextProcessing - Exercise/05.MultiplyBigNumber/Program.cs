using System;
using System.Numerics;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            if (secondNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (bigNumber[0] == '0')
            {
                bigNumber = bigNumber.TrimStart('0');
            }

            StringBuilder sb = new StringBuilder();
            int remainder = 0;

            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int currResult = int.Parse(bigNumber[i].ToString()) * secondNumber + remainder;
                remainder = 0;
                if (currResult > 9)
                {
                    remainder = currResult / 10;
                    currResult = currResult % 10;
                }

                sb.Append(currResult);

            }

            if (remainder != 0)
            {
                sb.Append(remainder);
            }

            StringBuilder sbResult = new StringBuilder();

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                sbResult.Append(sb[i]);
            }

            Console.WriteLine(sbResult);
        }
    }
}