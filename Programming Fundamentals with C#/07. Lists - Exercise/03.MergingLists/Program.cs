using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> numbersTwo = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> overallList = new List<int>();

            for (int i = 0; i < Math.Min(numbersOne.Count, numbersTwo.Count); i++)
            {
                overallList.Add(numbersOne[i]);
                overallList.Add(numbersTwo[i]);
                numbersOne.RemoveAt(i);
                numbersTwo.RemoveAt(i--);

                if (numbersOne.Count == 0 || numbersTwo.Count == 0)
                {
                    break;
                }
            }

            if (numbersOne.Count != numbersTwo.Count)
            {
                for (int i = 0; i < Math.Max(numbersOne.Count, numbersTwo.Count); i++)
                {
                    if (numbersOne.Count > 0)
                    {
                        overallList.Add(numbersOne[i]);
                    }
                    else if (numbersTwo.Count > 0)
                    {
                        overallList.Add(numbersTwo[i]);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", overallList));
        }
    }
}
