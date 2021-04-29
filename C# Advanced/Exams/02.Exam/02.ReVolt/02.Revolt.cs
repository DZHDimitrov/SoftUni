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
            int commands = int.Parse(Console.ReadLine());
            string[,] matrix = new string[size, size];
            int playerRow = 0;
            int playerCol = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] arr = Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

           

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (commands == 0)
                {
                    Console.WriteLine("Player lost!");
                    PrintMatrix(matrix);
                    return;
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "f")
                    {                     
                        playerRow = i;
                        playerCol = j;
                        string command = Console.ReadLine().ToLower();
                        if (command == "Up".ToLower())
                        {
                            if (i - 1 < 0)
                            {
                                playerRow = matrix.GetLength(0) - 1;
                            }
                            else
                            {
                                playerRow = i - 1;
                            }
                        }
                        else if (command == "Down".ToLower())
                        {
                            if (i + 1 > matrix.GetLength(0) - 1)
                            {
                                playerRow = 0;
                            }
                            else
                            {
                                playerRow = i + 1;
                            }
                        }
                        else if (command == "Left".ToLower())
                        {
                            if (j-1 < 0)
                            {
                                playerCol = matrix.GetLength(1) - 1;
                            }
                            else
                            {
                                playerCol = j - 1;
                            }
                        }
                        else if (command == "Right".ToLower())
                        {
                            if (j+1 > matrix.GetLength(1) -1)
                            {
                                playerCol = 0;
                            }
                            else
                            {
                                playerCol = j + 1;
                            }
                        }

                        if (matrix[playerRow,playerCol] == "T")
                        {
                            playerRow = i;
                            playerCol = j;
                        }

                        else if (matrix[playerRow,playerCol] == "F")
                        {
                            matrix[i, j] = "-";
                            matrix[playerRow, playerCol] = "f";
                            Console.WriteLine("Player won!");
                            PrintMatrix(matrix);
                            return;
                        }
                        
                        else if (matrix[playerRow,playerCol] == "B")
                        {
                            
                            if (command == "Up".ToLower())
                            {
                                if (playerRow - 1 < 0)
                                {
                                    playerRow = matrix.GetLength(0) - 1;
                                }
                                else
                                {
                                    playerRow--;
                                }
                            }
                            else if (command == "Down".ToLower())
                            {
                                if (playerRow + 1 > matrix.GetLength(0) - 1)
                                {
                                    playerRow = 0;
                                }
                                else
                                {
                                    playerRow++;
                                }
                            }
                            else if (command == "Left".ToLower())
                            {
                                if (playerCol - 1 < 0)
                                {
                                    playerCol = matrix.GetLength(1) - 1;
                                }
                                else
                                {
                                    playerCol--;
                                }
                            }
                            else if (command == "Right".ToLower())
                            {
                                if (j + 1 > matrix.GetLength(1) - 1)
                                {
                                    playerCol = 0;
                                }
                                else
                                {
                                    playerCol++;
                                }
                            }
                            matrix[i, j] = "-";
                            matrix[playerRow, playerCol] = "f";
                        }
                        else if (matrix[playerRow,playerCol] == "-")
                        {
                            matrix[i, j] = "-";
                            matrix[playerRow, playerCol] = "f";
                        }
                        commands--;                 
                        i = -1;
                        break;
                    }                  
                }
            }
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
    }
}
