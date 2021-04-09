using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings myStack = new StackOfStrings();
            myStack.Push("Papa");
            myStack.Push("Caca");
            myStack.Push("Kaka");
            myStack.Push("Lala");
            myStack.Push("Soso");
            Stack<string> stack = new Stack<string>();
            stack.Push("are");
            stack.Push("Peyo");
            stack.Push("Canko");
            stack.Push("Gergi");
            stack.Push("Totio");

            myStack.AddRange(stack);
            Console.WriteLine(string.Join(" ", myStack));
        }
    }
}
