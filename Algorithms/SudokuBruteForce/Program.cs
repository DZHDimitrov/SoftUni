using System;
using System.Collections.Generic;
using System.Linq;

namespace Solve
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = FillMatrix();
            Backtrack(matrix);
            Console.WriteLine(new string('-',20));
            PrintMatrix(matrix);

        }

        private static bool Backtrack(int[][] matrix)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (matrix[row][col] == 0)
                    {
                        for (int k = 1; k <= 9; k++)
                        {
                            if (ValidateSubgrid(matrix,row,col,k))
                            {
                                matrix[row][col] = k;
                                if (Backtrack(matrix))
                                {
                                    return true;
                                }
                                matrix[row][col] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool ValidateSubgrid(int[][] matrix, int currentRow, int currentCol, int currentValue)
        {
            if (Validate3x3Box(matrix,currentRow,currentCol,currentValue) && 
                ValidateRow(matrix,currentCol,currentValue) &&
                ValidateCol(matrix,currentRow,currentValue))
            {
                return true;
            }

            return false;
        }

        private static bool Validate3x3Box(int[][] matrix, int currentRow, int currentCol,int currentValue)
        {
            for (int i = (currentRow / 3) * 3; i < (currentRow / 3 + 1) * 3; i++)
            {
                for (int j = (currentCol / 3) * 3; j < (currentCol / 3 + 1) * 3; j++)
                {
                    if (matrix[i][j] == currentValue)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private static bool ValidateRow(int[][] matrix,int currentCol,int currentValue)
        {
            for (int i = 0; i < 9; i++)
            {
                if (matrix[i][currentCol] == currentValue)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool ValidateCol(int[][] matrix, int currentRow, int currentValue)
        {
            for (int i = 0; i < 9; i++)
            {
                if (matrix[currentRow][i] == currentValue)
                {
                    return false;
                }
            }

            return true;
        }

        private static int[][] FillMatrix()
        {
            int[][] matrix = new int[9][];

            for (int i = 0; i < matrix.Length; i++)
            {
                int[] currentLine = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
                matrix[i] = currentLine;
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = currentLine[j];
                }
            }
            return matrix;
        }

        private static void PrintMatrix(int[][] matrix)
        {
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
