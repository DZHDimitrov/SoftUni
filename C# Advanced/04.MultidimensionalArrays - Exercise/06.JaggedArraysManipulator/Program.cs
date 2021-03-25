using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._SnowBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[rows][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaggedArray[i] = new double[data.Length];
                for (int j = 0; j < data.Length; j++)
                {
                    jaggedArray[i][j] = data[j];
                }
            }

            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
                {
                    for (int j = 0; j < Math.Max(jaggedArray[i].Length, jaggedArray[i + 1].Length); j++)
                    {
                        if (jaggedArray[i].Length - 1 >= j)
                        {
                            jaggedArray[i][j] *= 2;
                        }
                        if (jaggedArray[i + 1].Length - 1 >= j)
                        {
                            jaggedArray[i + 1][j] *= 2;
                        }
                    }
                }
                else if (jaggedArray[i].Length != jaggedArray[i + 1].Length)
                {
                    for (int j = 0; j < Math.Max(jaggedArray[i].Length, jaggedArray[i + 1].Length); j++)
                    {
                        if (jaggedArray[i].Length - 1 >= j)
                        {
                            jaggedArray[i][j] /= 2;
                        }
                        if (jaggedArray[i + 1].Length - 1 >= j)
                        {
                            jaggedArray[i + 1][j] /= 2;
                        }
                    }
                }
            }
            string input = Console.ReadLine();

            while (true)
            {
                if (input == "End")
                {
                    PrintMatrix(jaggedArray);
                    return;
                }
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                bool isInvalid = false;
                int rowIndex = int.Parse(data[1]);
                int colIndex = int.Parse(data[2]);
                int value = int.Parse(data[3]);

                if (rowIndex > jaggedArray.Length - 1 || rowIndex < 0)
                {
                    isInvalid = true;
                }
                else if (colIndex > jaggedArray[rowIndex].Length - 1 || colIndex < 0)
                {
                    isInvalid = true;
                }

                if (!isInvalid && data[0] == "Add")
                {
                    jaggedArray[rowIndex][colIndex] += value;
                }
                else if (!isInvalid && data[0] == "Subtract")
                {
                    jaggedArray[rowIndex][colIndex] -= value;
                }

                input = Console.ReadLine();
            }
        }
        static void PrintMatrix(double[][] matrix)
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