using System;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            array = array.OrderByDescending(x => x).ToArray();

            int counter = 0;
            foreach (var item in array)
            {
                if (counter == 3)
                {
                    break;
                }
                Console.Write(item + " ");
                counter++;
            }
        }
    }
}
