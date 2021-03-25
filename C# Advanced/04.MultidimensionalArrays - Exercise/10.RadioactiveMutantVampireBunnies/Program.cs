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

            char[,] matrix = new char[size[0], size[1]];


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string text = Console.ReadLine();
                int pCounter = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (text[j] == '.' || text[j] == 'P' || text[j] == 'B')
                    {
                        if (text[j] == 'P' && pCounter == 0)
                        {
                            matrix[i, j] = text[j];
                            pCounter++;
                            continue;
                        }
                        matrix[i, j] = text[j];
                    }
                }
            }
            string ways = Console.ReadLine();
            Queue<char> queue = new Queue<char>();
            for (int i = 0; i < ways.Length; i++)
            {
                queue.Enqueue(ways[i]);
            }

            int lastRow = 0;
            int lastCol = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'P')
                    {
                        while (queue.Count > 0)
                        {
                            char command = queue.Dequeue();

                            switch (command)
                            {
                                case 'U':
                                    if (i - 1 >= 0)
                                    {
                                        if (matrix[i - 1, j] == 'B')
                                        {
                                            matrix = BunnyMultiplication(matrix);
                                            PrintMatrix(matrix);
                                            Console.WriteLine($"dead: {i - 1} {j}");
                                            return;
                                        }
                                        matrix[i - 1, j] = 'P';
                                        matrix[i, j] = '.';
                                        i--;
                                    }
                                    else if (i - 1 < 0)
                                    {
                                        matrix[i, j] = '.';
                                        matrix = BunnyMultiplication(matrix);
                                        PrintMatrix(matrix);
                                        Console.WriteLine($"won: {i} {j}");
                                        return;
                                    }
                                    break;
                                case 'L':
                                    if (j - 1 >= 0)
                                    {
                                        if (matrix[i, j - 1] == 'B')
                                        {
                                            matrix = BunnyMultiplication(matrix);
                                            PrintMatrix(matrix);
                                            Console.WriteLine($"dead: {i} {j - 1}");
                                            return;
                                        }
                                        matrix[i, j - 1] = 'P';
                                        matrix[i, j] = '.';
                                        j--;
                                    }
                                    else if (j - 1 < 0)
                                    {
                                        matrix[i, j] = '.';
                                        matrix = BunnyMultiplication(matrix);
                                        PrintMatrix(matrix);
                                        Console.WriteLine($"won: {i} {j}");
                                        return;
                                    }
                                    break;
                                case 'R':
                                    if (j + 1 <= matrix.GetLength(1) - 1)
                                    {
                                        if (matrix[i, j + 1] == 'B')
                                        {
                                            matrix = BunnyMultiplication(matrix);
                                            PrintMatrix(matrix);
                                            Console.WriteLine($"dead: {i} {j + 1}");
                                            return;
                                        }
                                        matrix[i, j + 1] = 'P';
                                        matrix[i, j] = '.';
                                        j++;
                                    }
                                    else if (j + 1 > matrix.GetLength(1) - 1)
                                    {
                                        matrix[i, j] = '.';
                                        matrix = BunnyMultiplication(matrix);
                                        PrintMatrix(matrix);
                                        Console.WriteLine($"won: {i} {j}");
                                        return;
                                    }
                                    break;
                                case 'D':
                                    if (i + 1 <= matrix.GetLength(0) - 1)
                                    {
                                        if (matrix[i + 1, j] == 'B')
                                        {
                                            matrix = BunnyMultiplication(matrix);
                                            PrintMatrix(matrix);
                                            Console.WriteLine($"dead: {i + 1} {j}");
                                            return;
                                        }
                                        matrix[i + 1, j] = 'P';
                                        matrix[i, j] = '.';
                                        i++;
                                    }
                                    else if (i + 1 > matrix.GetLength(0) - 1)
                                    {
                                        matrix[i, j] = '.';
                                        matrix = BunnyMultiplication(matrix);
                                        PrintMatrix(matrix);
                                        Console.WriteLine($"won: {i} {j}");
                                        return;
                                    }
                                    break;
                            }
                            lastRow = i;
                            lastCol = j;

                            bool checkIfBunnyFindsPlayer = BunnyFindsPlayer(matrix);
                            if (!checkIfBunnyFindsPlayer)
                            {
                                matrix = BunnyMultiplication(matrix);
                            }
                            else
                            {
                                matrix = BunnyMultiplication(matrix);
                                PrintMatrix(matrix);
                                Console.WriteLine($"won: {lastRow} {lastCol}");
                                return;
                            }
                        }
                        if (queue.Count == 0)
                        {
                            matrix[lastRow, lastCol] = '.';
                            PrintMatrix(matrix);
                            Console.WriteLine($"won: {lastRow} {lastCol}");
                            return;
                        }
                    }
                }
            }

        }
        static char[,] BunnyMultiplication(char[,] matrix)
        {
            Stack<char> commands = new Stack<char>();
            Queue<int[]> coordinates = new Queue<int[]>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        int[] arr = { i, j };
                        coordinates.Enqueue(arr);
                    }
                }
            }
            bool queueIsEmpty = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == coordinates.Peek()[0] && j == coordinates.Peek()[1])
                    {
                        commands.Push('U');
                        commands.Push('R');
                        commands.Push('L');
                        commands.Push('D');
                        while (commands.Count > 0)
                        {
                            char currentCommand = commands.Pop();

                            switch (currentCommand)
                            {

                                case 'U':
                                    if (i - 1 >= 0 && matrix[i - 1, j] != 'B')
                                    {
                                        matrix[i - 1, j] = 'B';
                                    }
                                    break;
                                case 'R':
                                    if (j + 1 <= matrix.GetLength(1) - 1 && matrix[i, j + 1] != 'B')
                                    {
                                        matrix[i, j + 1] = 'B';
                                    }
                                    break;
                                case 'L':
                                    if (j - 1 >= 0 && matrix[i, j - 1] != 'B')
                                    {
                                        matrix[i, j - 1] = 'B';
                                    }
                                    break;
                                case 'D':
                                    if (i + 1 <= matrix.GetLength(0) - 1 && matrix[i + 1, j] != 'B')
                                    {
                                        matrix[i + 1, j] = 'B';

                                    }
                                    break;
                            }

                        }
                        coordinates.Dequeue();

                        if (coordinates.Count == 0)
                        {
                            queueIsEmpty = true;
                            break;
                        }
                    }

                }
                if (queueIsEmpty)
                {
                    break;
                }
            }
            return matrix;
        }
        static bool BunnyFindsPlayer(char[,] matrix)
        {
            Stack<char> commands = new Stack<char>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        commands.Push('U');
                        commands.Push('R');
                        commands.Push('L');
                        commands.Push('D');
                        while (commands.Count > 0)
                        {
                            char currentCommand = commands.Pop();

                            switch (currentCommand)
                            {
                                case 'U':

                                    if (i - 1 >= 0)
                                    {
                                        if (matrix[i - 1, j] == 'P')
                                        {
                                            return true;
                                        }
                                    }
                                    break;
                                case 'R':
                                    if (j + 1 <= matrix.GetLength(1) - 1)
                                    {
                                        if (matrix[i, j + 1] == 'P')
                                        {
                                            return true;
                                        }
                                    }
                                    break;
                                case 'L':
                                    if (j - 1 >= 0)
                                    {
                                        if (matrix[i, j - 1] == 'P')
                                        {
                                            return true;
                                        }
                                    }
                                    break;
                                case 'D':
                                    if (i + 1 <= matrix.GetLength(0) - 1)
                                    {
                                        if (matrix[i + 1, j] == 'P')
                                        {
                                            return true;
                                        }
                                    }
                                    break;
                            }

                        }

                    }
                }
            }
            return false;
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
