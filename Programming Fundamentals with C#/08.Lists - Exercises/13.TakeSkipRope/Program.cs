using System;
using System.Collections.Generic;
using System.Text;

namespace _13.TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = new List<int>();
            List<char> nonNumbersList = new List<char>();

            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                {
                    numbersList.Add(int.Parse(text[i].ToString()));
                }
                else
                {
                    nonNumbersList.Add(text[i]);
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < numbersList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbersList[i]);
                }
                else if (i % 2 != 0)
                {
                    skipList.Add(numbersList[i]);
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < takeList.Count; i++)
            {
                int currentTake = takeList[i];
                int currentSkip = skipList[i];
                for (int j = 0; j < currentTake; j++)
                {
                    if (nonNumbersList.Count == 0)
                    {
                        break;
                    }
                    sb.Append(nonNumbersList[0]);
                    nonNumbersList.RemoveAt(0);                   
                }
                for (int j = 0; j < currentSkip; j++)
                {
                    if (nonNumbersList.Count == 0)
                    {
                        break;
                    }
                    nonNumbersList.RemoveAt(0);
                }
            }

            Console.WriteLine(sb.ToString());

        }
    }
}
