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

            string[] ways = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string>(ways);

            char[,] matrix = new char[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = array[j];
                }
            }

            int allCoals = FindAllCoals(matrix);
            int lastRow = 0;
            int lastCol = 0;
            int coalsCollected = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 's')
                    {
                        while (queue.Count > 0)
                        {
                            string command = queue.Dequeue();
                            bool isAvailable = SpotIsAvailable(matrix, command, i, j);

                            if (command == "up" && isAvailable)
                            {
                                char currentChar = FindElementOnSpot(matrix, command, i, j);
                                switch (currentChar)
                                {
                                    case '*':
                                        matrix[i - 1, j] = 's';
                                        matrix[i, j] = '*';
                                        i--;
                                        break;
                                    case 'e':
                                        i--;
                                        Console.WriteLine($"Game over! ({i}, {j})");
                                        return;
                                    case 'c':
                                        coalsCollected++;
                                        allCoals--;
                                        matrix[i - 1, j] = 's';
                                        matrix[i, j] = '*';
                                        i--;
                                        if (allCoals == 0)
                                        {
                                            Console.WriteLine($"You collected all coals! ({i}, {j})");
                                            return;
                                        }
                                        break;
                                }
                                lastRow = i;
                                lastCol = j;
                            }
                            else if (command == "right" && isAvailable)
                            {
                                char currentChar = FindElementOnSpot(matrix, command, i, j);
                                switch (currentChar)
                                {
                                    case '*':
                                        matrix[i, j + 1] = 's';
                                        matrix[i, j] = '*';
                                        j++;
                                        break;
                                    case 'e':
                                        j++;
                                        Console.WriteLine($"Game over! ({i}, {j})");
                                        return;
                                    case 'c':
                                        coalsCollected++;
                                        allCoals--;
                                        matrix[i, j + 1] = 's';
                                        matrix[i, j] = '*';
                                        j++;
                                        if (allCoals == 0)
                                        {
                                            Console.WriteLine($"You collected all coals! ({i}, {j})");
                                            return;
                                        }
                                        break;
                                }
                                lastRow = i;
                                lastCol = j;
                            }
                            else if (command == "left" && isAvailable)
                            {
                                char currentChar = FindElementOnSpot(matrix, command, i, j);
                                switch (currentChar)
                                {
                                    case '*':
                                        matrix[i, j - 1] = 's';
                                        matrix[i, j] = '*';
                                        j--;
                                        break;
                                    case 'e':
                                        j--;
                                        Console.WriteLine($"Game over! ({i}, {j})");
                                        return;
                                    case 'c':
                                        coalsCollected++;
                                        allCoals--;
                                        matrix[i, j - 1] = 's';
                                        matrix[i, j] = '*';
                                        j--;
                                        if (allCoals == 0)
                                        {
                                            Console.WriteLine($"You collected all coals! ({i}, {j})");
                                            return;
                                        }
                                        break;
                                }
                                lastRow = i;
                                lastCol = j;
                            }
                            else if (command == "down" && isAvailable)
                            {
                                char currentChar = FindElementOnSpot(matrix, command, i, j);
                                switch (currentChar)
                                {
                                    case '*':
                                        matrix[i + 1, j] = 's';
                                        matrix[i, j] = '*';
                                        i++;
                                        break;
                                    case 'e':
                                        i++;
                                        Console.WriteLine($"Game over! ({i}, {j})");
                                        return;
                                    case 'c':
                                        coalsCollected++;
                                        allCoals--;
                                        matrix[i + 1, j] = 's';
                                        matrix[i, j] = '*';
                                        i++;
                                        if (allCoals == 0)
                                        {
                                            Console.WriteLine($"You collected all coals! ({i}, {j})");
                                            return;
                                        }
                                        break;
                                }
                                lastRow = i;
                                lastCol = j;
                            }
                        }
                        if (allCoals > 0)
                        {
                            Console.WriteLine($"{allCoals} coals left. ({lastRow}, {lastCol})");
                            return;
                        }
                    }
                }
            }
        }

        static int FindAllCoals(char[,] matrix)
        {
            int allCoals = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'c')
                    {
                        allCoals++;
                    }
                }
            }
            return allCoals;
        }

        static char FindElementOnSpot(char[,] matrix, string command, int row, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    switch (command)
                    {
                        case "up":
                            return matrix[row - 1, col];
                        case "right":
                            return matrix[row, col + 1];
                        case "left":
                            return matrix[row, col - 1];
                        case "down":
                            return matrix[row + 1, col];
                    }
                }
            }
            throw new ArgumentException();
        }
        static bool SpotIsAvailable(char[,] matrix, string command, int row, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    switch (command)
                    {
                        case "up":
                            if (row - 1 >= 0)
                            {
                                return true;
                            }
                            break;
                        case "right":
                            if (col + 1 <= matrix.GetLength(1) - 1)
                            {
                                return true;
                            }
                            break;
                        case "left":
                            if (col - 1 >= 0)
                            {
                                return true;
                            }
                            break;
                        case "down":
                            if (row + 1 <= matrix.GetLength(0) - 1)
                            {
                                return true;
                            }
                            break;
                    }
                }
            }
            return false;
        }
        static void PrintMatrix(char[,] matrix)
        {
            Console.WriteLine("--------------");
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
