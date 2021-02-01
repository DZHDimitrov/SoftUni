using System;
using System.Linq;
using System.Text;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayOne = Console.ReadLine().Split(' ');
            string[] arrayTwo = Console.ReadLine().Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arrayTwo.Length; i++)
            {
                string currentElement = arrayTwo[i];
                for (int j = 0; j < arrayOne.Length; j++)
                {
                    if (currentElement == arrayOne[j])
                    {
                        sb.Append($"{currentElement} ");
                    }
                }
            }
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
