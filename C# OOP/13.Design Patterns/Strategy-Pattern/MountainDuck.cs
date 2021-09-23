using Strategy_Pattern.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern
{
    public class MountainDuck : Duck
    {
        public MountainDuck(IFlyBehaviour fb) : base(fb){}

        public override void Quack()
        {
            throw new NotImplementedException();
        }
    }
}
