using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Arrays
{
    class Sum_Arrays
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<string> myList = new List<string>();
            foreach (var item in text)
            {
                myList.Add(item.ToString());

            }

            string input = Console.ReadLine();

            while (input != "Decode")
            {
                string[] arr = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string command = arr[0];
                switch (command)
                {
                    case "Move":
                        for (int i = 0; i < int.Parse(arr[1]); i++)
                        {
                            string currentItem = myList[0];
                            myList.RemoveAt(0);
                            myList.Add(currentItem);
                        }
                        break;
                    case "Insert":
                        int index = int.Parse(arr[1]);
                        string value = arr[2];
                        if (value.Length > 1)
                        {

                            for (int i = value.Length - 1; i >= 0; i--)
                            {
                                myList.Insert(index, value[i].ToString());
                            }

                        }
                        else
                        {
                            myList.Insert(index, value);
                        }
                        break;
                    case "ChangeAll":

                        string list = string.Join("", myList);
                        list = list.Replace(arr[1], arr[2]);
                        myList.Clear();
                        foreach (var item in list)
                        {
                            myList.Add(item.ToString());
                        }
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {string.Join("", myList)}");
        }
    }
}