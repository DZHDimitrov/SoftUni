using System;
using System.Text;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] array = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = array[0];
                switch (command)
                {
                    case "TakeOdd":
                        text = TakeOdd(text);
                        Console.WriteLine(text);
                        break;
                    case "Cut":
                        int index = int.Parse(array[1]);
                        int length = int.Parse(array[2]);
                        text = text.Remove(index, length);
                        Console.WriteLine(text);
                        break;
                    case "Substitute":
                        string substring = array[1];
                        string substitute = array[2];
                        if (text.Contains(substring))
                        {
                            text = text.Replace(substring, substitute);
                            Console.WriteLine(text);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {text}");
        }
        public static string TakeOdd(string text)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (i % 2 != 0)
                {
                    sb.Append(text[i]);
                }
            }
            string newText = sb.ToString();
            return newText;
        }
    }
}