using System;
using System.Linq;
using System.Text;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int firstElement = arr[0];
                int lastElement = arr[arr.Length - 1];
                int[] newArr = new int[arr.Length];
                newArr[0] = arr[1];
                newArr[newArr.Length - 1] = firstElement;
                newArr[newArr.Length - 2] = lastElement;
                for (int j = 2; j < arr.Length - 1; j++)
                {
                    newArr[j - 1] = arr[j];
                }
                arr = newArr;
            }
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
