using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snake
{
    static class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            int prmaryDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i; j < i + 1; j++)
                {
                    prmaryDiagonal += matrix[i, j];
                }
                for (int j = matrix.GetLength(0) - i - 1; j >= matrix.GetLength(0) - i - 1; j--)
                {
                    secondaryDiagonal += matrix[i, j];
                }
            }
            int difference = Math.Abs(prmaryDiagonal - secondaryDiagonal);
            Console.WriteLine(difference);
        }
    }
}