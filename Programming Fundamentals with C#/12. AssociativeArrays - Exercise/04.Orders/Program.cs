using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> allProducts = new List<Product>();

            string input = Console.ReadLine();

            while (input != "buy")
            {
                string[] cmdArg = input.Split();
                string productName = cmdArg[0];
                double productPrice = double.Parse(cmdArg[1]);
                int productQuantity = int.Parse(cmdArg[2]);

                Product product = new Product(productName, productPrice, productQuantity);
                if (allProducts.Any(x=>x.Name == productName))
                {
                    allProducts = ModifyCollection(allProducts, product);
                }
                else
                {
                    allProducts.Add(product);
                }
                input = Console.ReadLine();
            }
            foreach (var item in allProducts)
            {
                Console.WriteLine(item);
            }

        }
        static List<Product> ModifyCollection(List<Product> list,Product product)
        {
            foreach (var item in list)
            {
                if (item.Name == product.Name)
                {
                    item.Quantity += product.Quantity;
                    if (item.Price != product.Price)
                    {
                        item.Price = product.Price;
                    }
                }
            }
            return list;
        }
    }
    class Product
    {
        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Name} -> {Price * Quantity:F2}";
        }
    }
}
