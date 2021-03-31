using System;
using System.Linq;

namespace FunctionalProgramming
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Func<int[], int[]> func = EvenNumbers;
            int[] evenArray = func(array);
            Array.Sort(evenArray);
            func = oddNumbers;
            int[] oddArray = func(array);
            Array.Sort(oddArray);
            int[] newestArray = new int[evenArray.Length + oddArray.Length];

            int finalIndex = 0;
            for (int i = 0; i < evenArray.Length; i++)
            {
                newestArray[i] = evenArray[i];
                if (i == evenArray.Length - 1)
                {
                    finalIndex = i + 1;
                }
            }
            if (finalIndex < newestArray.Length)
            {
                for (int i = finalIndex; i < newestArray.Length; i++)
                {
                    newestArray[i] = oddArray[i - finalIndex];
                }
            }

            Console.WriteLine(string.Join(" ", newestArray));

        }

        static int[] EvenNumbers(int[] array)
        {
            return array.Where(x => x % 2 == 0).ToArray();
        }
        static int[] oddNumbers(int[] array)
        {
            return array.Where(x => x % 2 != 0).ToArray();
        }
    }
}
