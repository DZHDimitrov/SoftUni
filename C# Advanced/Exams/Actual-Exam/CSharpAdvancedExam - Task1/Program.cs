using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvancedExam___Task1
{
    class Program
    {
        class Dish
        {
            public Dish(string name,int value)
            {
                this.Name = name;
                this.Value = value;
                this.Count = 0;
            }

            public string Name { get; set; }

            public int Value { get; set; }

            public int Count { get; set; }
        }

        static void Main(string[] args)
        {
            int[] numberOfIngredients = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] freshnessLevel = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queueIngredients = new Queue<int>(numberOfIngredients);
            Stack<int> stackFreshnessLevel = new Stack<int>(freshnessLevel);
            List<Dish> dishes = new List<Dish>()
            {
                new Dish("Dipping sauce",150),
                new Dish("Green salad",250),
                new Dish("Chocolate cake",300),
                new Dish("Lobster",400)
            };

            while (queueIngredients.Count > 0 && stackFreshnessLevel.Count > 0)
            {
                if (queueIngredients.Peek() == 0)
                {
                    queueIngredients.Dequeue();
                    continue;
                }
                var currentValue = queueIngredients.Peek() * stackFreshnessLevel.Peek();

                if (dishes.Any(x=> x.Value == currentValue))
                {
                    var dish = dishes.FirstOrDefault(x => x.Value == currentValue);
                    dish.Count++;
                    queueIngredients.Dequeue();
                    stackFreshnessLevel.Pop();
                }
                else
                {
                    stackFreshnessLevel.Pop();
                    var ingredientValue = queueIngredients.Dequeue();
                    ingredientValue += 5;
                    queueIngredients.Enqueue(ingredientValue);
                }
            }
            if (!dishes.Any(x=>x.Count == 0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (queueIngredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {queueIngredients.Sum()}");
            }
            foreach (var dish in dishes.Where(x=>x.Count > 0).OrderBy(x=>x.Name))
            {
                Console.WriteLine($" # {dish.Name} --> {dish.Count}");
            }
        }
    }
}
