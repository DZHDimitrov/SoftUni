using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string data = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = data[j].ToString();
                }
            }

            int goal = 50;
            int money = 0;
            bool isOut = false;
            bool goalReached = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "S")
                    {
                        string command = Console.ReadLine();
                        switch (command)
                        {
                            case "up":
                                if (i - 1 < 0)
                                {
                                    isOut = true;
                                    matrix[i, j] = "-";
                                    break;
                                }
                                else if (matrix[i - 1, j] == "-")
                                {
                                    matrix[i, j] = "-";
                                    matrix[i - 1, j] = "S";
                                }
                                else if (matrix[i - 1, j] == "O")
                                {
                                    int[] coordinates = GetCoordinates(matrix, i - 1, j);
                                    int row = coordinates[0];
                                    int col = coordinates[1];

                                    matrix[i, j] = "-";
                                    matrix[i - 1, j] = "-";
                                    matrix[row, col] = "S";
                                }
                                else if (Char.IsDigit(char.Parse(matrix[i - 1, j])))
                                {
                                    int currentMoney = int.Parse(matrix[i - 1, j]);
                                    matrix[i, j] = "-";
                                    matrix[i - 1, j] = "S";
                                    money += currentMoney;
                                }
                                break;
                            case "right":
                                if (j + 1 > matrix.GetLength(1) - 1)
                                {
                                    isOut = true;
                                    matrix[i, j] = "-";
                                    break;
                                }
                                else if (matrix[i, j + 1] == "-")
                                {
                                    matrix[i, j] = "-";
                                    matrix[i, j + 1] = "S";
                                }
                                else if (matrix[i, j + 1] == "O")
                                {
                                    int[] coordinates = GetCoordinates(matrix, i, j + 1);
                                    int row = coordinates[0];
                                    int col = coordinates[1];

                                    matrix[i, j] = "-";
                                    matrix[i, j + 1] = "-";
                                    matrix[row, col] = "S";
                                }
                                else if (Char.IsDigit(char.Parse(matrix[i, j + 1])))
                                {
                                    int currentMoney = int.Parse(matrix[i, j + 1]);
                                    matrix[i, j] = "-";
                                    matrix[i, j + 1] = "S";
                                    money += currentMoney;
                                }
                                break;
                            case "left":
                                if (j - 1 < 0)
                                {
                                    isOut = true;
                                    matrix[i, j] = "-";
                                    break;
                                }
                                else if (matrix[i, j - 1] == "-")
                                {
                                    matrix[i, j] = "-";
                                    matrix[i, j - 1] = "S";
                                }
                                else if (matrix[i, j - 1] == "O")
                                {
                                    int[] coordinates = GetCoordinates(matrix, i, j - 1);
                                    int row = coordinates[0];
                                    int col = coordinates[1];

                                    matrix[i, j] = "-";
                                    matrix[i, j - 1] = "-";
                                    matrix[row, col] = "S";
                                }
                                else if (Char.IsDigit(char.Parse(matrix[i, j - 1])))
                                {
                                    int currentMoney = int.Parse(matrix[i, j - 1]);
                                    matrix[i, j] = "-";
                                    matrix[i, j - 1] = "S";
                                    money += currentMoney;
                                }
                                break;
                            case "down":
                                if (i + 1 > matrix.GetLength(0) - 1)
                                {
                                    isOut = true;
                                    matrix[i, j] = "-";
                                    break;
                                }
                                else if (matrix[i + 1, j] == "-")
                                {
                                    matrix[i, j] = "-";
                                    matrix[i + 1, j] = "S";
                                }
                                else if (matrix[i + 1, j] == "O")
                                {
                                    int[] coordinates = GetCoordinates(matrix, i + 1, j);
                                    int row = coordinates[0];
                                    int col = coordinates[1];

                                    matrix[i, j] = "-";
                                    matrix[i + 1, j] = "-";
                                    matrix[row, col] = "S";
                                }
                                else if (Char.IsDigit(char.Parse(matrix[i + 1, j])))
                                {
                                    int currentMoney = int.Parse(matrix[i + 1, j]);
                                    matrix[i, j] = "-";
                                    matrix[i + 1, j] = "S";
                                    money += currentMoney;
                                }
                                break;
                        }
                        if (money >= goal)
                        {
                            goalReached = true;
                        }
                        i = -1;
                        break;
                    }
                }
                if (isOut || goalReached)
                {
                    break;
                }
            }
            if (isOut)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else if (goalReached)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {money}");

            PrintMatrix(matrix);

        }

        static int[] GetCoordinates(string[,] matrix, int row, int col)
        {
            int[] coordinates = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "O" && i != row && j != col)
                    {
                        coordinates[0] = i;
                        coordinates[1] = j;
                        return coordinates;
                    }
                }
            }
            throw new ArgumentException();
        }

        static void PrintMatrix(string[,] matrix)
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
