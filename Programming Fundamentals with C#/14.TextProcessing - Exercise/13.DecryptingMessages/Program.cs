using System;
using System.Text;

namespace _13.DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lines; i++)
            {
                char currentLetter = char.Parse(Console.ReadLine());
                int currentLetterAsInt = (int)currentLetter + key;
                sb.Append((char)currentLetterAsInt);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
