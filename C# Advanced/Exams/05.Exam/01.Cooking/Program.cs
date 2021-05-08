using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._SnowBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquids = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] ingredients = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(ingredients);
            Queue<int> queue = new Queue<int>(liquids);

            Dictionary<string, int> products = new Dictionary<string, int>();
            products.Add("Bread", 0);
            products.Add("Cake", 0);
            products.Add("Fruit Pie", 0);
            products.Add("Pastry", 0);

            int bread = 25;
            int cake = 50;
            int pastry = 75;
            int fruitPie = 100;

            while (stack.Count > 0 && queue.Count > 0)
            {
                int liquid = queue.Dequeue();
                bool isBeingUsed = false;
                if (liquid + stack.Peek() == bread)
                {
                    products["Bread"]++;
                    isBeingUsed = true;
                }
                if (liquid + stack.Peek() == cake)
                {
                    products["Cake"]++;
                    isBeingUsed = true;
                }
                if (liquid + stack.Peek() == fruitPie)
                {
                    products["Fruit Pie"]++;
                    isBeingUsed = true;
                }
                if (liquid + stack.Peek() == pastry)
                {
                    products["Pastry"]++;
                    isBeingUsed = true;
                }

                if (isBeingUsed)
                {
                    stack.Pop();
                }
                else
                {
                    int numberToAdd = stack.Peek() + 3;
                    stack.Pop();
                    stack.Push(numberToAdd);
                }
            }


            if (!products.ContainsValue(0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else if (queue.Count > 0)
            {

                Console.WriteLine($"Liquids left: {string.Join(", ", queue)}");
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else if (stack.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", stack)}");
            }

            foreach (var item in products.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
