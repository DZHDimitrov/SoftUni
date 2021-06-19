using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] matrix = FillMatrix(size);
            char[] commands = Console.ReadLine().ToCharArray().ToArray();
            //b goes right
            //d goes left
            for (int i = 0; i < commands.Length; i++)
            {
                var command = commands[i];
                MoveEnemies(matrix);
                if (CheckIfEnemySeesSam(matrix))
                {
                    var coordiantesOfSam = FindCoordinatesOfSam(matrix);
                    matrix[coordiantesOfSam[0]][coordiantesOfSam[1]] = 'X';
                    Console.WriteLine($"Sam died at {string.Join(", ", coordiantesOfSam)}");
                    break;
                }
                if (CheckIfSamReachesNikoladze(matrix))
                {
                    Console.WriteLine("Nikoladze killed!");
                    var coordinatesOfNikoladze = FindCoordinatesOfNikoladze(matrix);
                    matrix[coordinatesOfNikoladze[0]][coordinatesOfNikoladze[1]] = 'X';
                    break;
                }
                MoveSam(matrix, command);
                if (CheckIfEnemySeesSam(matrix))
                {
                    var coordiantesOfSam = FindCoordinatesOfSam(matrix);
                    matrix[coordiantesOfSam[0]][coordiantesOfSam[1]] = 'X';
                    Console.WriteLine($"Sam died at {string.Join(", ", coordiantesOfSam)}");
                    break;
                }
                if (CheckIfSamReachesNikoladze(matrix))
                {
                    Console.WriteLine("Nikoladze killed!");
                    var coordinatesOfNikoladze = FindCoordinatesOfNikoladze(matrix);
                    matrix[coordinatesOfNikoladze[0]][coordinatesOfNikoladze[1]] = 'X';
                    break;
                }
            }
            PrintMatrix(matrix);
        }

        static int[] FindCoordinatesOfNikoladze(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'N')
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }
        static bool CheckIfSamReachesNikoladze(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'S' && matrix[i].Any(x => x == 'N'))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static int[] FindCoordinatesOfSam(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'S')
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }
        static bool CheckIfEnemySeesSam(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'b' && matrix[i].Any(x => x == 'S'))
                    {
                        int index = -1;
                        var arrayToSearchIn = matrix[i];
                        for (int k = 0; k < arrayToSearchIn.Length; k++)
                        {
                            if (arrayToSearchIn[k] == 'S')
                            {
                                index = k;
                            }
                        }
                        if (index < j)
                        {
                            return false;
                        }
                        else if (index > j)
                        {
                            return true;
                        }
                    }
                    else if (matrix[i][j] == 'd' && matrix[i].Any(x => x == 'S'))
                    {
                        int index = -1;
                        var arrayToSearchIn = matrix[i];
                        for (int k = 0; k < arrayToSearchIn.Length; k++)
                        {
                            if (arrayToSearchIn[k] == 'S')
                            {
                                index = k;
                            }
                        }
                        if (index > j)
                        {
                            return false;
                        }
                        else if (index < j)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        static void MoveSam(char[][] matrix, char way)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'S')
                    {
                        if (way == 'U')
                        {
                            matrix[i - 1][j] = 'S';
                            matrix[i][j] = '.';
                        }
                        else if (way == 'D')
                        {
                            matrix[i + 1][j] = 'S';
                            matrix[i][j] = '.';
                        }
                        else if (way == 'L')
                        {
                            matrix[i][j - 1] = 'S';
                            matrix[i][j] = '.';
                        }
                        else if (way == 'R')
                        {
                            matrix[i][j + 1] = 'S';
                            matrix[i][j] = '.';
                        }
                        return;
                    }
                }
            }
        }
        static void MoveEnemies(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                var currentRow = matrix[i];
                if (currentRow.Contains('b'))
                {
                    var index = Array.IndexOf(currentRow, 'b');
                    if (index < currentRow.Length - 1)
                    {
                        matrix[i][index + 1] = 'b';
                        matrix[i][index] = '.';
                    }
                    if (index == currentRow.Length - 1)
                    {
                        matrix[i][index] = 'd';
                    }
                }
                else if (currentRow.Contains('d'))
                {
                    var index = Array.IndexOf(currentRow, 'd');
                    if (index >= 1)
                    {
                        matrix[i][index - 1] = 'd';
                        matrix[i][index] = '.';
                    }
                    if (index == 0)
                    {
                        matrix[i][index] = 'b';
                    }
                }
            }
        }
        static char[][] FillMatrix(int size)
        {
            char[][] matrix = new char[size][];

            for (int i = 0; i < matrix.Length; i++)
            {
                char[] line = Console.ReadLine().ToCharArray().ToArray();
                matrix[i] = new char[line.Length];
                for (int j = 0; j < line.Length; j++)
                {
                    matrix[i][j] = line[j];
                }
            }
            return matrix;
        }

        static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}