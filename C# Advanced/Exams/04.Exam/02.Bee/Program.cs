using System;
using System.Linq;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] matrix = new string[size, size];
            matrix = FillMatrix(matrix);
            int pollinated = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    (int beeRow, int beeCol) positions = FindBeesPosition(matrix);
                    int beeRowPos = positions.beeRow;
                    int beeColPos = positions.beeCol;
                    string way = Console.ReadLine();

                    if (way == "End")
                    {
                        i = matrix.GetLength(0);
                        break;
                    }
                    if (CanMove(matrix, way,beeRowPos,beeColPos))
                    {
                        int[] newCoordinates = GetNewCoordinates(beeRowPos, beeColPos, way);

                        if (matrix[newCoordinates[0],newCoordinates[1]] == "f")
                        {
                            pollinated++;
                        }
                        else if (matrix[newCoordinates[0], newCoordinates[1]] == "O")
                        {
                            matrix[newCoordinates[0], newCoordinates[1]] = ".";
                            newCoordinates = GetNewCoordinates(newCoordinates[0], newCoordinates[1], way);
                            if (matrix[newCoordinates[0],newCoordinates[1]] == "f")
                            {
                                pollinated++;
                            }
                        }
                        matrix[beeRowPos, beeColPos] = ".";
                        matrix[newCoordinates[0], newCoordinates[1]] = "B";
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        matrix[beeRowPos, beeColPos] = ".";
                        i = matrix.GetLength(0);
                        break;
                    }

                }
            }
            if (pollinated < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-pollinated} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinated} flowers!");
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static int[] GetNewCoordinates(int row, int col,string way)
        {
            int[] newCoordinates = new int[2];
            newCoordinates = way switch
            {
                "up" => newCoordinates = new int[2] { row - 1, col },
                "down" => newCoordinates = new int[2] { row + 1, col },
                "left" => newCoordinates = new int[2] { row, col - 1 },
                "right" => newCoordinates = new int[2] { row, col + 1 },
                _ => null,
            };
            return newCoordinates;
        }
        private static bool CanMove(string[,] matrix, string way,int beeRowPos,int beeColPos)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (way == "up")
                    {
                        if (beeRowPos - 1 >= 0)
                        {
                            return true;
                        }
                    }
                    else if (way == "down")
                    {
                        if (beeRowPos + 1 <= matrix.GetLength(0) - 1)
                        {
                            return true;
                        }
                    }
                    else if (way == "left")
                    {
                        if (beeColPos - 1 >= 0)
                        {
                            return true;
                        }
                    }
                    else if (way == "right")
                    {
                        if (beeColPos + 1 <= matrix.GetLength(1) - 1)
                        {
                            return true;
                        }
                    }

                }
            }
            return false;
        }
        private static (int Row, int Col) FindBeesPosition(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "B")
                    {
                        return (i, j);
                    }
                }
            }
            throw new ArgumentException();
        }
        private static string[,] FillMatrix(string[,] matrix)
        {
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
