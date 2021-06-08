using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharp_advanced_StreamsAndFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = File.ReadAllLines("../../../Files/text.txt");
            string[] notAllowedChars = { "-", ",", ".", "!", "?" };

            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    string currentLine = arr[i].ToString();

                    string replacedLine = Replace(currentLine, notAllowedChars);

                    Console.WriteLine(Reverse(replacedLine));
                }
            }
        }

        public static string Replace(string currentLine,string[] notAllowedChars)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < currentLine.Length; j++)
            {
                string symbol = "";
                if (notAllowedChars.Contains(currentLine[j].ToString()))
                {
                    symbol = "@";
                }
                else
                {
                    symbol = currentLine[j].ToString();
                }
                sb.Append(symbol);
            }

            return sb.ToString();
        }
        public static string Reverse(string currentLine)
        {
            string[] resultArr = currentLine.Split(" ");
            StringBuilder sb = new StringBuilder();
            for (int j = resultArr.Length - 1; j >= 0; j--)
            {
                sb.Append(resultArr[j] + " ");
            };
            return sb.ToString();
        }
    }
}
