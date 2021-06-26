using System;
using System.Linq;

namespace CSharpAdvancedExam___Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = FillMatrix(size);
            int collectedTokens = 0;
            int opponentTokens = 0;
            string line = Console.ReadLine();

            while (line != "Gong")
            {
                var cmdArgs = line.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                var command = cmdArgs[0];
                var row = int.Parse(cmdArgs[1]);
                var col = int.Parse(cmdArgs[2]);

                if (ValidateIndexes(matrix, row, col))
                {
                    if (command == "Find" && matrix[row][col] == "T")
                    {
                        matrix[row][col] = "-";
                        collectedTokens++;
                    }
                    else if (command == "Opponent")
                    {
                        var wayOfOpponent = cmdArgs[3];
                        MoveOpponent(matrix, row, col, wayOfOpponent, ref opponentTokens);
                    }
                }

                line = Console.ReadLine();
            }
            PrintMatrix(matrix);
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
        static void MoveOpponent(string[][] matrix, int row, int col, string way, ref int opponentTokens)
        {
            int moves = 0;
            if (matrix[row][col] == "T")
            {
                matrix[row][col] = "-";
                opponentTokens++;
            }
            if (way == "up")
            {
                for (int i = row; i > 0; i--)
                {
                    if (col <= matrix[i - 1].Length - 1)
                    {
                        if (matrix[i - 1][col] == "T")
                        {
                            opponentTokens++;
                            matrix[i - 1][col] = "-";
                        }
                    }
                    else
                    {
                        if (matrix[i - 1][matrix[i - 1].Length - 1] == "T")
                        {
                            matrix[i - 1][matrix[i - 1].Length - 1] = "-";
                            opponentTokens++;
                        }
                    }
                    moves++;
                    if (moves == 3)
                    {
                        break;
                    }
                }
            }
            else if (way == "down")
            {
                for (int i = row; i < matrix.Length - 1; i++)
                {
                    if (col <= matrix[i + 1].Length - 1)
                    {
                        if (matrix[i + 1][col] == "T")
                        {
                            opponentTokens++;
                            matrix[i + 1][col] = "-";
                        }
                    }
                    else
                    {
                        if (matrix[i+1][matrix[i+1].Length-1] == "T")
                        {
                            opponentTokens++;
                            matrix[i + 1][matrix[i + 1].Length - 1] = "-";
                        }
                    }
                    moves++;
                    if (moves == 3)
                    {
                        break;
                    }
                }
            }
            else if (way == "left")
            {
                for (int i = col; i > 0; i--)
                {
                    if (matrix[row][i - 1] == "T")
                    {
                        matrix[row][i - 1] = "-";
                        opponentTokens++;
                    }
                    moves++;
                    if (moves == 3)
                    {
                        break;
                    }
                }
            }
            else if (way == "right")
            {
                for (int i = col; i < matrix[row].Length - 1; i++)
                {
                    if (matrix[row][i + 1] == "T")
                    {
                        matrix[row][i + 1] = "-";
                        opponentTokens++;
                    }
                    moves++;
                    if (moves == 3)
                    {
                        break;
                    }
                }
            }
        }
        static bool ValidateIndexes(string[][] matrix, int row, int col)
        {
            if (row < 0 || row > matrix.Length - 1 || col < 0 || col > matrix[row].Length - 1)
            {
                return false;
            }
            return true;
        }
        static string[][] FillMatrix(int size)
        {
            string[][] matrix = new string[size][];

            for (int i = 0; i < matrix.Length; i++)
            {
                string[] line = Console.ReadLine().Split(' ').Select(x => x.ToString()).ToArray();
                matrix[i] = new string[line.Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = line[j];
                }
            }

            return matrix;
        }

        static void PrintMatrix(string[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }
    }
}
