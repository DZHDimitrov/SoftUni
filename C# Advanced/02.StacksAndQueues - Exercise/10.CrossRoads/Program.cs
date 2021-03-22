using System;
using System.Collections.Generic;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int green = int.Parse(Console.ReadLine());
            int window = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            string input = Console.ReadLine();
            bool isCrash = false;
            int carsCrossed = 0;
            while (input != "END")
            {
                string command = input;
                if (command != "green")
                {
                    queue.Enqueue(command);
                }
                else
                {
                    int greenLimit = green;
                    int windowLimit = window;
                    int crashIndex = 0;
                    while (queue.Count > 0 && greenLimit > 0)
                    {
                        string currentCar = queue.Dequeue();

                        for (int i = 0; i < currentCar.Length; i++)
                        {
                            if (greenLimit > 0)
                            {
                                greenLimit--;
                            }
                            else
                            {
                                windowLimit--;
                            }
                            if (windowLimit < 0)
                            {
                                isCrash = true;
                                crashIndex = i;
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {currentCar[crashIndex]}.");
                                break;
                            }
                        }
                        if (isCrash)
                        {
                            break;
                        }
                        carsCrossed++;
                    }
                }
                input = Console.ReadLine();
            }
            if (!isCrash)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carsCrossed} total cars passed the crossroads.");
            }

        }
    }
}