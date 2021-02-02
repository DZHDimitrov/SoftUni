using System;
using System.Text;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            string updatedText = UpdateText(text, number);
            Console.WriteLine(updatedText);
        }
        static string UpdateText(string text, int timesOfMultiplication)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < timesOfMultiplication; i++)
            {
                sb.Append(text);
            }
            return sb.ToString();
        }
    }
}
