using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            string line = Console.ReadLine().ToLower();

            while (true)
            
            {
                if (line.Contains(word))
                {
                    int index = line.IndexOf(word);
                    line = line.Remove(index, word.Length);
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(line);

        }
    }
}
