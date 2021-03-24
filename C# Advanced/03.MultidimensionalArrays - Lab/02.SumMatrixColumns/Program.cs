using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Numerics;
using System.Text;

namespace CSharpExercises

{
    class Program
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[array[0], array[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }
            PrintMatrix(matrix);

        }

        static void PrintMatrix(int[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sum += matrix[j, i];
                }
                Console.WriteLine(sum);
            }
        }
    }
}