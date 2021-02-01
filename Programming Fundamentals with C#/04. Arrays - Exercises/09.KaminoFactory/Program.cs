using System;
using System.Linq;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayLength = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int bestSubsequence = 0;
            int bestRow = 0;
            int bestSum = 0;
            int bestStartingIndex = 0;
            int[] bestArray = new int[arrayLength];

            int currentRow = 1;
            while (input != "Clone them!")
            {

                int[] array = input.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int currentBestSubOfOnes = FindLongestSubOfOnes(array);
                int currentBestStartingIndex = FindLeftMostIndex(array);
                int currentSum = array.Sum();
                if ((currentBestSubOfOnes > bestSubsequence) ||
                    (currentBestSubOfOnes == bestSubsequence && currentBestStartingIndex < bestStartingIndex) ||
                    (currentBestSubOfOnes == bestSubsequence && currentBestStartingIndex == bestStartingIndex && currentSum > bestSum))
                {
                    bestSubsequence = currentBestSubOfOnes;
                    bestRow = currentRow;
                    bestSum = array.Sum();
                    bestStartingIndex = currentBestStartingIndex;
                    bestArray = array;
                }

                currentRow++;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestRow} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestArray));
        }

        static int FindLeftMostIndex(int[] array)
        {
            int bestSubOfOnes = 0;
            int bestStartingIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int currentSub = 1;
                if (array[i] == 1)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[j] != 1)
                        {
                            break;
                        }
                        currentSub++;
                    }
                }
                if (currentSub > bestSubOfOnes)
                {
                    bestSubOfOnes = currentSub;
                    bestStartingIndex = i;
                }
            }
            return bestStartingIndex;
        }
        static int FindLongestSubOfOnes(int[] array)
        {
            int bestSubOfOnes = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int currentSub = 1;
                if (array[i] == 1)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[j] != 1)
                        {
                            break;
                        }
                        currentSub++;
                    }
                }
                if (currentSub > bestSubOfOnes)
                {
                    bestSubOfOnes = currentSub;
                }
            }
            return bestSubOfOnes;
        }
    }
}
