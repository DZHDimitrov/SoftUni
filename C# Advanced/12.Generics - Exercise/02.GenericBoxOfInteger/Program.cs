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
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
                Console.WriteLine(box);
            }
        }
    }
}
