using System;
using System.Linq;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[][] matrix = FillMatrix(size);
            int foodEaten = 0;
            string command = Console.ReadLine();

            while (true)
            {
                var currentCoordinatesOfSnake = FindCoordinatesOfSnake(matrix);
                var row = currentCoordinatesOfSnake[0];
                var col = currentCoordinatesOfSnake[1];
                bool isOut = false;
                matrix[row][col] = ".";
                if (command == "up")
                {
                    if (row - 1 < 0)
                    {
                        isOut = true;
                    }
                    else if (row - 1 >= 0)
                    {
                        if (matrix[row - 1][col] == "*")
                        {
                            foodEaten++;
                            matrix[row - 1][col] = "S";
                        }
                        else if (matrix[row - 1][col] == "B")
                        {
                            var coordinatesOfOtherBurrow = FindCoordinatesOfOtherBurrow(matrix, new int[] { row - 1, col });
                            var currentRow = coordinatesOfOtherBurrow[0];
                            var currentCol = coordinatesOfOtherBurrow[1];

                            matrix[row - 1][col] = ".";
                            matrix[currentRow][currentCol] = "S";
                        }
                        else
                        {
                            matrix[row - 1][col] = "S";
                        }
                    }
                }
                else if (command == "down")
                {
                    if (row + 1 > matrix.Length - 1)
                    {
                        isOut = true;
                    }
                    else if (row + 1 <= matrix.Length - 1)
                    {
                        if (matrix[row + 1][col] == "*")
                        {
                            foodEaten++;
                            matrix[row + 1][col] = "S";
                        }
                        else if (matrix[row + 1][col] == "B")
                        {
                            var coordinatesOfOtherBurrow = FindCoordinatesOfOtherBurrow(matrix, new int[] { row + 1, col });
                            var currentRow = coordinatesOfOtherBurrow[0];
                            var currentCol = coordinatesOfOtherBurrow[1];

                            matrix[row + 1][col] = ".";
                            matrix[currentRow][currentCol] = "S";
                        }
                        else
                        {
                            matrix[row + 1][col] = "S";
                        }
                    }
                }
                else if (command == "left")
                {
                    if (col - 1 < 0)
                    {
                        isOut = true;
                    }
                    else if (col - 1 >= 0)
                    {
                        if (matrix[row][col - 1] == "*")
                        {
                            foodEaten++;
                            matrix[row][col - 1] = "S";
                        }
                        else if (matrix[row][col - 1] == "B")
                        {
                            var coordinatesOfOtherBurrow = FindCoordinatesOfOtherBurrow(matrix, new int[] { row, col - 1 });
                            var currentRow = coordinatesOfOtherBurrow[0];
                            var currentCol = coordinatesOfOtherBurrow[1];

                            matrix[row][col - 1] = ".";
                            matrix[currentRow][currentCol] = "S";
                        }
                        else
                        {
                            matrix[row][col - 1] = "S";
                        }
                    }
                }
                else if (command == "right")
                {
                    if (col + 1 > matrix[row].Length - 1)
                    {
                        isOut = true;
                    }
                    else if (col + 1 >= 0)
                    {
                        if (matrix[row][col + 1] == "*")
                        {
                            foodEaten++;
                            matrix[row][col + 1] = "S";
                        }
                        else if (matrix[row][col + 1] == "B")
                        {
                            var coordinatesOfOtherBurrow = FindCoordinatesOfOtherBurrow(matrix, new int[] { row, col + 1 });
                            var currentRow = coordinatesOfOtherBurrow[0];
                            var currentCol = coordinatesOfOtherBurrow[1];

                            matrix[row][col + 1] = ".";
                            matrix[currentRow][currentCol] = "S";
                        }
                        else
                        {
                            matrix[row][col + 1] = "S";
                        }
                    }
                }
                if (isOut)
                {
                    Console.WriteLine("Game over!");
                    break;
                }
                else if (foodEaten >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Food eaten: {foodEaten}");
            PrintMatrix(matrix);
        }
        static int[] FindCoordinatesOfOtherBurrow(string[][] matrix, int[] currentBurrowCoordinates)
        {
            int row = currentBurrowCoordinates[0];
            int col = currentBurrowCoordinates[1];

            int newRow = -1;
            int newCol = -1;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Any(x => x == "B"))
                {
                    var index = Array.IndexOf(matrix[i], "B");
                    if (i != row || index != col)
                    {
                        newRow = i;
                        newCol = index;
                    }
                }
            }
            return new int[] { newRow, newCol };
        }
        static int[] FindCoordinatesOfSnake(string[][] matrix)
        {
            bool isFound = false;
            int row = -1;
            int col = -1;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == "S")
                    {
                        isFound = true;
                        row = i;
                        col = j;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }
            return new int[] { row, col };
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
