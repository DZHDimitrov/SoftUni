using System;


namespace FinalEx
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int previousSum = 0;
            int diff = 0;
            int maxDifference = 0;

            for (int i = 1; i <= n; i++)
            {
                sum += int.Parse(Console.ReadLine());
                sum += int.Parse(Console.ReadLine());

                if (i > 1)
                {

                    diff = Math.Abs(sum - previousSum);
                }

                if (diff > maxDifference)
                {
                    maxDifference = diff;
                }

                previousSum = sum;
                sum = 0;
            }

            if (maxDifference == 0)
            {
                Console.WriteLine("Yes, value={0}", previousSum);
            }
            else
            {
                Console.WriteLine("No, maxdiff={0}", maxDifference);
            }
        }
    }
}