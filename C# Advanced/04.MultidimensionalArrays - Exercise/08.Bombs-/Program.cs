using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._SnowBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = array[j];
                }
            }


            string[] bombCoordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string[]> bombs = new Queue<string[]>();
            for (int i = 0; i < bombCoordinates.Length; i++)
            {
                string[] newArr = bombCoordinates[i].Split(",");
                bombs.Enqueue(newArr);
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (bombs.Count == 0)
                    {
                        break;
                    }
                    if (i == int.Parse(bombs.Peek()[0]) && j == int.Parse(bombs.Peek()[1]))
                    {
                        int currentNumber = matrix[i, j];
                        if (currentNumber <= 0)
                        {
                            bombs.Dequeue();
                            continue;
                        }
                        if (j + 1 <= matrix.GetLength(0) - 1)
                        {
                            if (matrix[i, j + 1] > 0)
                            {
                                matrix[i, j + 1] -= currentNumber;
                            }
                            if (i - 1 >= 0 && matrix[i - 1, j + 1] > 0)
                            {
                                matrix[i - 1, j + 1] -= currentNumber;
                            }
                        }
                        if (i - 1 >= 0)
                        {
                            if (matrix[i - 1, j] > 0)
                            {
                                matrix[i - 1, j] -= currentNumber;
                            }
                            if (j - 1 >= 0 && matrix[i - 1, j - 1] > 0)
                            {
                                matrix[i - 1, j - 1] -= currentNumber;
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            if (matrix[i, j - 1] > 0)
                            {
                                matrix[i, j - 1] -= currentNumber;
                            }
                            if (i + 1 <= matrix.GetLength(0) - 1)
                            {
                                if (matrix[i + 1, j - 1] > 0)
                                {
                                    matrix[i + 1, j - 1] -= currentNumber;
                                }
                            }
                        }
                        if (i + 1 <= matrix.GetLength(0) - 1)
                        {
                            if (matrix[i + 1, j] > 0)
                            {
                                matrix[i + 1, j] -= currentNumber;
                            }
                            if (j + 1 <= matrix.GetLength(1) - 1)
                            {
                                if (matrix[i + 1, j + 1] > 0)
                                {
                                    matrix[i + 1, j + 1] -= currentNumber;
                                }
                            }
                        }

                        matrix[i, j] -= currentNumber;
                        bombs.Dequeue();
                    }
                }

                if (i == matrix.GetLength(0) - 1 && bombs.Count > 0)
                {
                    i = -1;
                }
            }
            FindAliveCells(matrix);
            PrintMatrix(matrix);
        }
        static void FindAliveCells(int[,] matrix)
        {
            int aliveCells = 0;
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        aliveCells++;
                        sum += matrix[i, j];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

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
