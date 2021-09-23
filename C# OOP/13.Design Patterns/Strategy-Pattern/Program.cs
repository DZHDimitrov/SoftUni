using Strategy_Pattern.behaviours.fly;
using System;

namespace Strategy_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Duck duck1 = new MountainDuck(new FastFlyingDuck());
            Duck duck2 = new CloudDuck(new CloudsFlyingDuck());
            Duck duck3 = new GrassDuck(new NonFlyingDuck());
            duck1.Fly();
            duck2.Fly();
            duck3.Fly();
        }
    }
}
