using _03.ShoppingSpree.Common;

using System;

namespace _03.ShoppingSpree
{
    class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
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
        public decimal Cost
        {
            get
            {
                return cost;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.NegativeMoneyExcMessage);
                }
                cost = value;
            }
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
