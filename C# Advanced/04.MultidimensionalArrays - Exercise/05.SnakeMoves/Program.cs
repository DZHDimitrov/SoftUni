using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._SnowBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[size[0], size[1]];
            string text = Console.ReadLine();
            Queue<string> queue = new Queue<string>();

            int counter = 0;

            int capacity = size[0] * size[1];

            for (int i = 0; i < text.Length; i++)
            {
                queue.Enqueue(text[i].ToString());
                counter++;

                if (counter == capacity)
                {
                    break;
                }
                if (i == text.Length - 1)
                {
                    i = -1;
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i += 2)
            {
                for (int j = 0; j < text.Length; j++)
                {

                    queue.Enqueue(text[j].ToString());


                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = queue.Dequeue();
                }


                for (int j = 0; j < text.Length; j++)
                {
                    if (text[j] != ' ')
                    {
                        queue.Enqueue(text[j].ToString());
                    }
                }

                if (i < matrix.GetLength(0) - 1)
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[i + 1, j] = queue.Dequeue();
                    }
                }
            }
            PrintMatrix(matrix);

        }
        static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(string.Join("", matrix[i, j]));
                }
                Console.WriteLine();
            }
        }
    }
}