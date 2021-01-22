using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int metLetterC = 0;
            int metLetterO = 0;
            int metLetterN = 0;
            string word = "";


            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                switch (input)
                {
                    case "c":
                        metLetterC++;
                        if (metLetterC >= 2)
                        {
                            word += input;
                        }
                        break;
                    case "o":
                        metLetterO++;
                        if (metLetterO >= 2)
                        {
                            word += input;
                        }
                        break;
                    case "n":
                        metLetterN++;
                        if (metLetterN >= 2)
                        {
                            word += input;
                        }
                        break;
                }
                int charNum = input[0];

                if ((input != "c" && input != "o" && input != "n") && ((charNum >= 65 && charNum <= 90) || (charNum >= 97 && charNum <= 122)))
                {
                    word += input;
                }
                if (metLetterC >= 1 && metLetterO >= 1 && metLetterN >= 1)
                {
                    Console.Write(word + " ");
                    word = "";
                    metLetterC = 0;
                    metLetterO = 0;
                    metLetterN = 0;
                }
            }
        }
    }
}