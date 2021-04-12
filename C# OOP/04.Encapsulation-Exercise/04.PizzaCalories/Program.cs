using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            try
            {
                while (input != "END")
                {
                    string[] pizza = input.Split();
                    string name = pizza[1];

                    string[] dough = Console.ReadLine().Split();
                    string typeFlour = dough[1].ToLower();
                    string typeTechnique = dough[2].ToLower();
                    int doughWeight = int.Parse(dough[3]);
                    Dough newDough = new Dough(typeFlour, typeTechnique, doughWeight);

                    Pizza newPizza = new Pizza(name, newDough);

                    string secondInput = Console.ReadLine();
                    while (secondInput != "END")
                    {
                        string[] currentTopping = secondInput.Split();
                        string toppingName = currentTopping[1].ToLower();
                        int toppingWeight = int.Parse(currentTopping[2]);
                        Topping topping = new Topping(toppingName, toppingWeight);
                        newPizza.AddingTopping(topping);

                        secondInput = Console.ReadLine();
                    }
                    if (secondInput == "END")
                    {
                        Console.WriteLine(newPizza);
                        break;
                    }

                    input = Console.ReadLine();
                }
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
    }
}
