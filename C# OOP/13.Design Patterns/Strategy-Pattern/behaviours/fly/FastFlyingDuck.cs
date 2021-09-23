using Strategy_Pattern.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern.behaviours.fly
{
    public class FastFlyingDuck : IFlyBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("I am flying very fast!");
        }
    }
}
