using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = matrixData[0];
            int col = matrixData[1];

            int[,] matrix = new int[row, col];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }

            string input = Console.ReadLine();

            List<int[]> allIndexPlaces = new List<int[]>();
            while (input != "Bloom Bloom Plow")
            {
                int[] indexes = input.Split().Select(int.Parse).ToArray();
                int currentRow = indexes[0];
                int currentCol = indexes[1];

                if (AreValidCoordinates(matrix, currentRow, currentCol))
                {
                    allIndexPlaces.Add(indexes);
                    matrix[indexes[0], indexes[1]] = 1;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < allIndexPlaces.Count; i++)
            {
                int[] currentIndexes = allIndexPlaces[i];
                int currentRow = currentIndexes[0];
                int currentCol = currentIndexes[1];

                matrix = ModifyMatrixAfterBloom(matrix, currentRow, currentCol);


            }
            PrintMatrix(matrix);
        }

        public static bool AreValidCoordinates(int[,] matrix, int row, int col)
        {
            if (row < 0 || row > matrix.GetLength(0) - 1)
            {
                return false;
            }
            if (col < 0 || col > matrix.GetLength(1) - 1)
            {
                return false;
            }
            return true;

        }
        public static int[,] ModifyMatrixAfterBloom(int[,] matrix, int row, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == row && j == col)
                    {
                        for (int k = j + 1; k < matrix.GetLength(1); k++)
                        {
                            matrix[row, k] += 1;
                        }
                        for (int k = j - 1; k >= 0; k--)
                        {
                            matrix[row, k] += 1;
                        }
                        for (int k = i + 1; k < matrix.GetLength(0); k++)
                        {
                            matrix[k, col] += 1;
                        }
                        for (int k = i - 1; k >= 0; k--)
                        {
                            matrix[k, col] += 1;
                        }
                    }
                }
            }
            return matrix;
        }
        public static void PrintMatrix(int[,] matrix)
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
