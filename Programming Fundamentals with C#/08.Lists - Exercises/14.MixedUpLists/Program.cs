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
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> mixedList = new List<int>(firstList.Count + secondList.Count);

            for (int i = 0; i < Math.Min(firstList.Count, secondList.Count); i++)
            {
                mixedList.Add(firstList[i]);
                mixedList.Add(secondList[secondList.Count - 1]);
                firstList.RemoveAt(i--);
                secondList.RemoveAt(secondList.Count - 1);

            }

            List<int> rangeList = new List<int>(2);
            for (int i = Math.Min(firstList.Count, secondList.Count); i < Math.Max(firstList.Count, secondList.Count); i++)
            {
                if (firstList.Count > secondList.Count)
                {
                    rangeList.Add(firstList[i]);
                }
                else if (secondList.Count > firstList.Count)
                {
                    rangeList.Add(secondList[i]);
                }
            }
            int lowerRange = 0;
            int higherRange = 0;
            if (rangeList[0] < rangeList[1])
            {
                lowerRange = rangeList[0];
                higherRange = rangeList[1];
            }
            else if (rangeList[0] > rangeList[1])
            {
                lowerRange = rangeList[1];
                higherRange = rangeList[0];
            }
            int includedNumbers = 0;
            for (int i = 0; i < mixedList.Count; i++)
            {
                if (mixedList[i] > lowerRange && mixedList[i] < higherRange)
                {
                    includedNumbers++;
                }
            }

            int[] resultArray = new int[includedNumbers];
            int howManyNumbers = 0;

            for (int i = 0; i < mixedList.Count; i++)
            {
                if (mixedList[i] > lowerRange && mixedList[i] < higherRange)
                {
                    resultArray[i - i + howManyNumbers] = mixedList[i];
                    howManyNumbers++;
                }

            }
            Array.Sort(resultArray);
            Console.WriteLine(string.Join(" ", resultArray));

        }

    }
}
