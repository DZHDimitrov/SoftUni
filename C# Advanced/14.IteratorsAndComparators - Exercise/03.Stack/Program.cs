using System;

namespace CustomStack
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            MyStack<string> mystack = new MyStack<string>();
            string[] arr = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < arr.Length; i++)
            {
                mystack.Push(arr[i]);
            }

            string secondInput = Console.ReadLine();

            while (secondInput != "END")
            {
                string[] command = secondInput.Split(' ');
                try
                {
                    if (command[0] == "Pop")
                    {
                        mystack.Pop();
                    }

                    else if (command[0] == "Push")
                    {
                        mystack.Push(command[1]);
                    }
                }
                catch (Exception n)
                {
                    Console.WriteLine("No elements");
                }
                secondInput = Console.ReadLine();
            }

            foreach (var item in mystack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in mystack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
