using System;
using System.Linq;
using System.Numerics;

namespace _11._SnowBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string[,] matrix = new string[array[0], array[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = data[j];
                }
            }

            string input = Console.ReadLine();
            bool isInvalid = false;
            while (input != "END")
            {
                string[] currentArray = input.Split();

                if (!currentArray.Contains("swap") || currentArray.Length != 5)
                {
                    isInvalid = true;
                }

                else if (int.Parse(currentArray[1]) > matrix.GetLength(0) - 1 || int.Parse(currentArray[1]) < 0)
                {
                    isInvalid = true;
                }
                else if (int.Parse(currentArray[2]) > matrix.GetLength(1) - 1 || int.Parse(currentArray[2]) < 0)
                {
                    isInvalid = true;
                }
                else if (int.Parse(currentArray[3]) > matrix.GetLength(0) - 1 || int.Parse(currentArray[3]) < 0)
                {
                    isInvalid = true;
                }
                else if (int.Parse(currentArray[4]) > matrix.GetLength(1) - 1 || int.Parse(currentArray[4]) < 0)
                {
                    isInvalid = true;
                }
                if (isInvalid)
                {
                    Console.WriteLine("Invalid input!");
                    isInvalid = false;
                }
                else
                {
                    string elementToSwap = matrix[int.Parse(currentArray[1]), int.Parse(currentArray[2])];
                    matrix[int.Parse(currentArray[1]), int.Parse(currentArray[2])] = matrix[int.Parse(currentArray[3]), int.Parse(currentArray[4])];
                    matrix[int.Parse(currentArray[3]), int.Parse(currentArray[4])] = elementToSwap;
                    PrintMatrix(matrix);
                }
                input = Console.ReadLine();
            }

        }
        static void PrintMatrix(string[,] matrix)
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