using System;
using System.Linq;
using System.Text;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] first = new int[n];
            int[] second = new int[n];
            for (int i = 0; i < n; i++)
            {
                int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (i % 2 == 0)
                {
                    first[i] = array[0];
                    second[i] = array[1];
                }
                else if (i % 2 != 0)
                {
                    first[i] = array[1];
                    second[i] = array[0];
                }
            }
            Console.WriteLine(string.Join(" ", first));
            Console.WriteLine(string.Join(" ", second));
        }
    }
}
