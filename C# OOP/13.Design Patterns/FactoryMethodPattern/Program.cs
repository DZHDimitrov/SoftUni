using FactoryMethodPattern.BaseClasses;
using System;

namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CardFactory factory = null;
            Console.Write("Enter the card type you would like to visit: ");
            string car = Console.ReadLine();
            switch (car.ToLower())
            {
                case "moneyback":
                    factory = new MoneyBackFactory(50000, 0);
                    break;
                case "titanium":
                    factory = new TitaniumFactory(100000, 500);
                    break;
                case "platinum":
                    factory = new PlatinumFactory(500000, 1000);
                    break;
                default:
                    break;
            }
            CreditCard creditCard = factory.GetCreditCard();
            Console.WriteLine("\nYour card details are below : \n");
            Console.WriteLine("Card Type: {0}\nCard Limit: {1}\nAnnual Charge: {2}",
                creditCard.CardType, creditCard.CardLimit, creditCard.AnnualCharge);
            Console.ReadKey();
        }
    }
}
