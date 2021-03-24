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
            int sum = 0;
            int[] array = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[array[0], array[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                    sum += matrix[i, j];
                }
            }
            Console.WriteLine(array[0]);
            Console.WriteLine(array[1]);
            Console.WriteLine(sum);

        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}