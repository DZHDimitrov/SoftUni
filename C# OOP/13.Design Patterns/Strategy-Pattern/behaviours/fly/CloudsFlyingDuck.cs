using Strategy_Pattern.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern.behaviours.fly
{
    public class CloudsFlyingDuck : IFlyBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("I am flying in clouds");
        }
    }
}
