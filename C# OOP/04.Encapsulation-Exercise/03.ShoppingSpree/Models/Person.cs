using _03.ShoppingSpree.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree.Models
{
    class Person
    {
        private const string NOT_ENOUGH_MONEY_EXC_MSG = "{0} can't afford {1}";
        private const string SUCCESSFULLY_BOUGHT_MSG = "{0} bought {1}";


        private string name;
        private decimal money;
        private readonly ICollection<Product> bagOfProducts;

        public Person()
        {
            bagOfProducts = new List<Product>();
        }

        public Person(string name,decimal money) : this()
        {
            Name = name;
            Money = money;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EmptyNameExcMessage);
                }
                name = value;
            }
        }
        public decimal Money 
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.NegativeMoneyExcMessage);
                }
                money = value;
            }
        }
        public IReadOnlyCollection<Product> Bag 
        { 
            get
            {
                return (IReadOnlyCollection<Product>)bagOfProducts;
            }
        }

        public string BuyProduct(Product product)
        {
            if (Money < product.Cost)
            {
                return String.Format(NOT_ENOUGH_MONEY_EXC_MSG, Name, product.Name);
            }

            Money -= product.Cost;
            bagOfProducts.Add(product);

            return String.Format(SUCCESSFULLY_BOUGHT_MSG, Name, product.Name);
        }
        public override string ToString()
        {
            string productsOutput = bagOfProducts.Count > 0 ? string.Join(", ", bagOfProducts) : "Nothing bought";

            return $"{Name} - {productsOutput}";
        }


    }
}
