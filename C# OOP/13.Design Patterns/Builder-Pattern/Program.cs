using System;

namespace Builder_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            Console.WriteLine("Standard basic product:");
            director.BuildMinimalViableProduct();
            builder.GetProduct().Show();

            Console.WriteLine("Standard full featured product:");
            director.BuildFullFeaturedProduct();
            builder.GetProduct().Show();
        }
    }
}
