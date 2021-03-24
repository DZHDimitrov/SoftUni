using System;
using System.Linq;

namespace CSharpExercises

{
    class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] matrix = new long[rows][];
            int cols = 1;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new long[cols];
                matrix[i][0] = 1;
                matrix[i][matrix[i].Length - 1] = 1;
                cols++;

                for (int j = 1; j < matrix[i].Length - 1; j++)
                {
                    matrix[i][j] = matrix[i - 1][j] + matrix[i - 1][j - 1];
                }

            }
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}