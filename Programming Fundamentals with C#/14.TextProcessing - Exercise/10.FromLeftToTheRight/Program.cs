using System;
using System.Linq;
using System.Numerics;

namespace CSharpAdvanced___2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                string[] array = Console.ReadLine().Split(" ");

                long firstNumber = long.Parse(array[0]);
                long secondNumber = long.Parse(array[1]);

                if (firstNumber >= secondNumber)
                {
                    firstNumber = Math.Abs(firstNumber);
                    string text = firstNumber.ToString();
                    for (int j = 0; j < text.Length; j++)
                    {
                        sum += int.Parse(text[j].ToString());
                    }
                }
                else if (firstNumber < secondNumber)
                {
                    secondNumber = Math.Abs(secondNumber);
                    string text = secondNumber.ToString();
                    for (int j = 0; j < text.Length; j++)
                    {
                        sum += int.Parse(text[j].ToString());
                    }
                }
                Console.WriteLine(sum);
            }
        }
    }
}
