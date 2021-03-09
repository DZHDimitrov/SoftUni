using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Associative_Arrays_lab
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double currentResult = Calculation(array[i]);
                sum += currentResult;
            }
            Console.WriteLine($"{sum:F2}");

        }

        static double Calculation(string word)
        {
            double number = int.Parse(word.Substring(1, word.Length - 2));
            char firstLetter = word[0];
            char lastLetter = word[word.Length - 1];

            double firstLetPos = letterPosition(firstLetter);
            double lastLetPos = letterPosition(lastLetter);
            if (char.IsUpper(firstLetter))
            {
                number /= firstLetPos;
            }
            else if (char.IsLower(firstLetter))
            {
                number *= firstLetPos;
            }
            if (char.IsUpper(lastLetter))
            {
                number -= lastLetPos;
            }
            else if (char.IsLower(lastLetter))
            {
                number += lastLetPos;
            }
            return number;


            int letterPosition(char currentChar)
            {
                int position = 0;
                if (char.IsUpper(currentChar))
                {
                    position = currentChar - 64;
                }
                else if (char.IsLower(currentChar))
                {
                    position = currentChar - 96;
                }
                return position;
            }
        }
    }
}
