using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ObjectsAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] dataPeople = Console.ReadLine().Split(new char[] { '=', ';' }).ToArray();

            for (int i = 0; i < dataPeople.Length; i += 2)
            {
                string currentName = dataPeople[i];
                double money = double.Parse(dataPeople[i + 1]);
                Person person = new Person(currentName, money);

                people.Add(person);
            }

            string[] dataProducts = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < dataProducts.Length; i += 2)
            {
                string currentProduct = dataProducts[i];
                double cost = double.Parse(dataProducts[i + 1]);
                Product prodcut = new Product(currentProduct, cost);

                products.Add(prodcut);
            }



            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] command = input.Split();
                string name = command[0];
                string product = command[1];

                Person buyer = people.FirstOrDefault(x => x.Name == name);
                Product wantedProduct = products.FirstOrDefault(x => x.Name == product);

                buyer.BuyProduct(wantedProduct);

                input = Console.ReadLine();
            }

            foreach (Person item in people)
            {
                Console.WriteLine(item);
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public double Money { get; set; }
        public List<string> BagOfProducts { get; set; }

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<string>();
        }

        public void BuyProduct(Product product)
        {
            StringBuilder sb = new StringBuilder();
            if (product.Cost > Money)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} bought {product.Name}");
                BagOfProducts.Add(product.Name);
                Money -= product.Cost;
            }
        }
        public override string ToString()
        {
            string person = $"{Name} - ";

            if (BagOfProducts.Count == 0)
            {
                person += "Nothing bought";
            }
            else
            {
                person += string.Join(", ", BagOfProducts);
            }
            return person;
        }
    }
    class Product
    {
        public string Name { get; set; }
        public double Cost { get; set; }

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}

