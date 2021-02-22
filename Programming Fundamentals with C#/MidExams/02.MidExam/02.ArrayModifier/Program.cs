using System;
using System.Linq;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] cmdArgs = input.Split();
                string command = cmdArgs[0];
                if (command == "swap")
                {
                    array = SwapElements(array, int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]));
                }
                else if (command == "decrease")
                {
                    array = DecreaseAllElements(array);
                }
                else if (command == "multiply")
                {
                    array = MultiplyElements(array, int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]));
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", array));
        }
        static int[] SwapElements(int[] array, int indexOne, int indexTwo)
        {
            int firstElement = array[indexOne];
            array[indexOne] = array[indexTwo];
            array[indexTwo] = firstElement;
            return array;
        }
        static int[] DecreaseAllElements(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i]--;
            }
            return array;
        }

        static int[] MultiplyElements(int[] array, int indexOne, int indexTwo)
        {
            int firstNumber = array[indexOne];
            int secondNumber = array[indexTwo];
            array[indexOne] = firstNumber * secondNumber;
            return array;
        }
    }
}
