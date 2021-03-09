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
            string[] arr = Console.ReadLine().Split();
            string first = arr[0];
            string second = arr[1];
            int sum = Result(first, second);
            Console.WriteLine(sum);
        }
        static int Result(string first, string second)
        {
            int result = 0;
            if (first.Length != second.Length)
            {
                for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
                {
                    result += first[i] * second[i];
                }
                for (int i = Math.Min(first.Length, second.Length); i < Math.Max(first.Length, second.Length); i++)
                {
                    if (first.Length > second.Length)
                    {
                        result += first[i];
                    }
                    else if (first.Length < second.Length)
                    {
                        result += second[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < second.Length; i++)
                {
                    result += first[i] * second[i];
                }
            }
            return result;

        }

    }
}