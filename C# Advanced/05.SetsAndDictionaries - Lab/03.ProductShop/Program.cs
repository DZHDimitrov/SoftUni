using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11._SnowBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input != "Revision")
            {
                string[] array = input.Split(", ");
                string shop = array[0];
                string product = array[1];
                double price = double.Parse(array[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                shops[shop].Add(product, price);

                input = Console.ReadLine();
            }


            foreach (var item in shops.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}->");
                foreach (var product in item.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }



        }
    }
}
