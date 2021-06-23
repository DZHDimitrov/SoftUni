using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CSharpAdvanced
{
    class Program
    {

        static void Main(string[] args)
        {
            int lifes = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            var matrix = FillMatrix(rows);

            while (lifes > 0)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var marioWay = cmdArgs[0];
                var enemyRow = int.Parse(cmdArgs[1]);
                var enemyCol = int.Parse(cmdArgs[2]);

                matrix[enemyRow][enemyCol] = "B";

                var marioCoordinates = FindCoordinatesOfMario(matrix);

                lifes = MoveMario(matrix, marioCoordinates, marioWay, lifes);
                if (!IsThereAPrincess(matrix))
                {
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lifes}");
                    break;
                }
                else if (isMarioDead(matrix))
                {
                    var coordinatesOfDeath = FindCoordinatesOfDeath(matrix);
                    var row = coordinatesOfDeath[0];
                    var col = coordinatesOfDeath[1];
                    Console.WriteLine($"Mario died at {row};{col}.");
                    break;
                }
                if (lifes <= 0)
                {
                    var coordinates = FindCoordinatesOfMario(matrix);
                    var row = coordinates[0];
                    var col = coordinates[1];

                    matrix[row][col] = "X";
                    Console.WriteLine($"Mario died at {row};{col}.");
                    break;
                }
            }

            PrintMatrix(matrix);

        }

        static int[] FindCoordinatesOfDeath(string[][] matrix)
        {

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == "X")
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }
        static bool isMarioDead(string[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == "M")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static bool IsThereAPrincess(string[][] matrix)
        {

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == "P")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static int MoveMario(string[][] matrix, int[] marioCoordinates, string way, int lives)
        {
            var row = marioCoordinates[0];
            var col = marioCoordinates[1];

            lives--;
            if (way == "W")
            {
                if (row - 1 < 0)
                {
                    return lives;
                }
                else
                {
                    row--;
                }
            }
            else if (way == "S")
            {
                if (row + 1 > matrix.Length - 1)
                {
                    return lives;
                }
                else
                {
                    row++;
                }
            }
            else if (way == "A")
            {
                if (col - 1 < 0)
                {
                    return lives;
                }
                else
                {
                    col--;
                }
            }
            else if (way == "D")
            {
                if (col + 1 > matrix[row].Length - 1)
                {
                    return lives;
                }
                else
                {
                    col++;
                }

            }
            if (matrix[row][col] == "B")
            {
                lives -= 2;
                matrix[marioCoordinates[0]][marioCoordinates[1]] = "-";
                matrix[row][col] = lives > 0 ? "M" : "X";
            }
            else if (matrix[row][col] == "P")
            {
                matrix[marioCoordinates[0]][marioCoordinates[1]] = "-";
                matrix[row][col] = "-";
            }
            else
            {
                matrix[row][col] = "M";
                matrix[marioCoordinates[0]][marioCoordinates[1]] = "-";
            }
            return lives;
        }
        static int[] FindCoordinatesOfMario(string[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == "M")
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