using Strategy_Pattern.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern.behaviours.fly
{
    public class NonFlyingDuck : IFlyBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("I am a duck but I cannot fly!");
        }
    }
}
