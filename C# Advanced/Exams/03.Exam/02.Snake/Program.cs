using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] matrix = FillMatix(size);
            int foodsEaten = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "S")
                    {
                        int snakeCoordinateRow = i;
                        int snakeCoordianteCol = j;

                        string command = Console.ReadLine();

                        var move = GetNextMove(matrix, snakeCoordinateRow, snakeCoordianteCol, command);
                        if (move != null)
                        {
                            int[] coordinates = { snakeCoordinateRow, snakeCoordianteCol };
                            coordinates = command switch
                            {
                                "up"   => new int[] { --snakeCoordinateRow,snakeCoordianteCol},
                                "down" => new int[] { ++snakeCoordinateRow,snakeCoordianteCol},
                                "left" => new int[] { snakeCoordinateRow,--snakeCoordianteCol},
                               "right" => new int[] { snakeCoordinateRow,++snakeCoordianteCol},
                                     _ => null,
                            };


                            matrix[i, j] = ".";
                            if (move == "-")
                            {
                                matrix[coordinates[0],coordinates[1]] = "S";
                            }
                            else if (move == "*")
                            {
                                matrix[coordinates[0],coordinates[1]] = "S";
                                foodsEaten++;
                                if (foodsEaten == 10)
                                {
                                    Console.WriteLine($"You won! You fed the snake.");
                                    Console.WriteLine($"Food eaten: {foodsEaten}");
                                    PrintMatrix(matrix);
                                    return;
                                }
                            }
                            else if (move == "B")
                            {
                                matrix[coordinates[0], coordinates[1]] = ".";
                                (snakeCoordinateRow, snakeCoordianteCol) = BurrowCoordinates(matrix, i, j);
                                matrix[snakeCoordinateRow, snakeCoordianteCol] = "S";
                            }
                        }
                        else
                        {
                            matrix[i, j] = ".";
                            Console.WriteLine("Game over!");
                            Console.WriteLine($"Food eaten: {foodsEaten}");
                            PrintMatrix(matrix);
                            return;
                        }
                        i = -1;
                        break;
                    }
                }
            }
        }

        public static (int, int) BurrowCoordinates(string[,] matrix, int row, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "B" && (i != row && col != j))
                    {
                        return (i, j);
                    }
                }
            }

            throw new ArgumentException();
        }
        public static string GetNextMove(string[,] matrix, int row, int col, string command)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (command == "up")
                    {
                        if (row - 1 < 0)
                        {
                            return null;
                        }

                        else if (matrix[row - 1, col] == "*")
                        {
                            return "*";
                        }

                        else if (matrix[row - 1, col] == "B")
                        {
                            return "B";
                        }

                        else if (matrix[row - 1, col] == "-")
                        {
                            return "-";
                        }
                    }
                    else if (command == "down")
                    {
                        if (row + 1 > matrix.GetLength(0) - 1)
                        {
                            return null;
                        }

                        else if (matrix[row + 1, col] == "*")
                        {
                            return "*";
                        }

                        else if (matrix[row + 1, col] == "B")
                        {
                            return "B";
                        }

                        else if (matrix[row + 1, col] == "-")
                        {
                            return "-";
                        }
                    }
                    else if (command == "left")
                    {
                        if (col - 1 < 0)
                        {
                            return null;
                        }

                        else if (matrix[row, col - 1] == "*")
                        {
                            return "*";
                        }

                        else if (matrix[row, col - 1] == "B")
                        {
                            return "B";
                        }

                        else if (matrix[row, col - 1] == "-")
                        {
                            return "-";
                        }
                    }
                    else if (command == "right")
                    {
                        if (col + 1 > matrix.GetLength(1) - 1)
                        {
                            return null;
                        }

                        else if (matrix[row, col + 1] == "*")
                        {
                            return "*";
                        }

                        else if (matrix[row, col + 1] == "B")
                        {
                            return "B";
                        }

                        else if (matrix[row, col + 1] == "-")
                        {
                            return "-";
                        }
                    }
                }
            }
            throw new ArgumentException();
        }
        public static void PrintMatrix(string[,] matrix)
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

        public static string[,] FillMatix(int size)
        {
            string[,] matrix = new string[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] line = Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            return matrix;
        }
    }
}
