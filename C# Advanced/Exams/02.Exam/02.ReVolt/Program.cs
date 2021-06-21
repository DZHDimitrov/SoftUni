using System;
using System.Linq;

namespace _02.ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            int numberOfCommands = int.Parse(Console.ReadLine());
            string[][] matrix = FillMatrix(sizeOfMatrix);

            string previousCommand = "";
            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();
                var coordinatesOfPlayer = FindCoordinatesOfPlayer(matrix);
                MovePlayer(matrix, coordinatesOfPlayer, command, previousCommand);
                if (CheckIfPlayerWins(matrix))
                {
                    Console.WriteLine("Player won!");
                    PrintMatrix(matrix);
                    return;
                }

                var newRow = coordinatesOfPlayer[0];
                var newCol = coordinatesOfPlayer[1];

                previousCommand = command;
            }
            Console.WriteLine("Player lost!");
            PrintMatrix(matrix);
        }
        static bool CheckIfPlayerWins(string[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == "F")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static void MovePlayer(string[][] matrix, int[] playerCoordinates, string command, string previousCommand)
        {

            var row = playerCoordinates[0];
            var col = playerCoordinates[1];

            var newRow = -1;
            var newCol = -1;
            if (command == "up")
            {
                if (row - 1 < 0)
                {
                    newRow = matrix.Length - 1;
                    newCol = col;
                }
                else if (row - 1 >= 0)
                {
                    newRow = row - 1;
                    newCol = col;
                }
                if (matrix[newRow][newCol] == "T")
                {
                    newRow = row;
                    newCol = col;
                }
                if (matrix[newRow][newCol] == "B")
                {
                    if (newRow - 1 < 0)
                    {
                        newRow = matrix[row].Length - 1;
                        newCol = col;
                    }
                    else if (row - 1 >= 0)
                    {
                        newRow -= 1;
                        newCol = col;
                    }
                }
            }
            else if (command == "down")
            {
                if (row + 1 > matrix.Length - 1)
                {
                    newRow = 0;
                    newCol = col;
                }
                else if (row + 1 <= matrix.Length - 1)
                {
                    newRow = row + 1;
                    newCol = col;
                }
                if (matrix[newRow][newCol] == "T")
                {
                    newRow = row;
                    newCol = col;
                }
                if (matrix[newRow][newCol] == "B")
                {
                    if (newRow + 1 > matrix.Length - 1)
                    {
                        newRow = 0;
                        newCol = col;
                    }
                    else if (row + 1 <= matrix.Length - 1)
                    {
                        newRow += 1;
                        newCol = col;
                    }
                }
            }
            else if (command == "left")
            {
                if (col - 1 < 0)
                {
                    newRow = row;
                    newCol = matrix[row].Length - 1;
                }
                else if (col - 1 >= 0)
                {
                    newRow = row;
                    newCol = col - 1;
                }
                if (matrix[newRow][newCol] == "T")
                {
                    newRow = row;
                    newCol = col;
                }
                if (matrix[newRow][newCol] == "B")
                {
                    if (newCol - 1 < 0)
                    {
                        newRow = row;
                        newCol = matrix[row].Length - 1;
                    }
                    else if (col - 1 >= 0)
                    {
                        newRow = row;
                        newCol -= 1;
                    }
                }
            }
            else if (command == "right")
            {
                if (col + 1 > matrix[row].Length - 1)
                {
                    newRow = row;
                    newCol = 0;
                }
                else if (col + 1 <= matrix[row].Length - 1)
                {
                    newRow = row;
                    newCol = col + 1;
                }
                if (matrix[newRow][newCol] == "T")
                {
                    newRow = row;
                    newCol = col;
                }
                if (matrix[newRow][newCol] == "B")
                {
                    if (newCol + 1 > matrix[row].Length - 1)
                    {
                        newRow = row;
                        newCol = 0;
                    }
                    else if (col + 1 <= matrix[row].Length - 1)
                    {
                        newRow = row;
                        newCol += 1;
                    }
                }
            }
            matrix[row][col] = "-";
            matrix[newRow][newCol] = "f";

            return;
        }

        static int[] FindCoordinatesOfPlayer(string[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == "f")
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }
        static string[][] FillMatrix(int size)
        {
            string[][] matrix = new string[size][];

            for (int i = 0; i < matrix.Length; i++)
            {
                string[] line = Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToArray();
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
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }
    }
}
