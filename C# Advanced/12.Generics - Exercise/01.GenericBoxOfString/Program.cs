using System;

namespace GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int boxes = int.Parse(Console.ReadLine());

            for (int i = 0; i < boxes; i++)
            {
                string input = Console.ReadLine();
                Box<string> box = new Box<string>(input);
                Console.WriteLine(box);
            }
        }
    }
}
