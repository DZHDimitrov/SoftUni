
using _03.ShoppingSpree.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree.Core
{
    public class Engine
    {
        private readonly ICollection<Person> people;

        private readonly ICollection<Product> products;
        public Engine()
        {
            people = new List<Person>();

            products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                ParsePeopleInput();

                ParseProductInput();

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string personName = cmdArgs[0];
                    string productName = cmdArgs[1];

                    Person person = people.FirstOrDefault(x => x.Name == personName);
                    Product product = products.FirstOrDefault(x => x.Name == productName);

                    if (person != null && product != null)
                    {
                        string result = person.BuyProduct(product);

                        Console.WriteLine(result);
                    }

                }

                foreach (Person person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
        private void ParsePeopleInput()
        {
            string[] peopleArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (string currentPerson in peopleArgs)
            {
                string[] personArgs = currentPerson.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string personName = personArgs[0];
                decimal personMoney = decimal.Parse(personArgs[1]);

                Person person = new Person(personName, personMoney);

                people.Add(person);
            }
        }

        private void ParseProductInput()
        {
            string[] productArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);


            foreach (string currentProduct in productArgs)
            {
                string[] productArg = currentProduct.Split('=');
                string productName = productArg[0];
                decimal productCost = decimal.Parse(productArg[1]);

                Product product = new Product(productName, productCost);

                products.Add(product);
            }
        }

    }
}
