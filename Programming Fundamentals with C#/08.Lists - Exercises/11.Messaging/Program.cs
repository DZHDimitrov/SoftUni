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
            string[] numbers = Console.ReadLine().Split();
            string text = Console.ReadLine();
            List<string> firstList = new List<string>(50);
            List<string> result = new List<string>(10);

            for (int i = 0; i < text.Length; i++)
            {
                firstList.Add(text[i].ToString());
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                string currentNumber = numbers[i];
                int sum = 0;
                for (int j = 0; j < currentNumber.Length; j++)
                {
                    int currentDigit = int.Parse(currentNumber[j].ToString());
                    sum += currentDigit;
                }
                for (int j = 0; j < firstList.Count; j++)
                {
                    if (sum == 0)
                    {
                        string listSymbol = firstList[j];
                        firstList.RemoveAt(j);
                        result.Add(listSymbol);
                    }
                    if (sum > 0 && j == firstList.Count - 1)
                    {
                        j = -1;
                    }
                    sum--;
                }
            }
            Console.WriteLine(string.Join("", result));

        }

    }
}
