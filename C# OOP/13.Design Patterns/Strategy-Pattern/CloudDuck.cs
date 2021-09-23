using Strategy_Pattern.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern
{
    public class CloudDuck : Duck
    {
        public CloudDuck(IFlyBehaviour fb) : base(fb) {}

        public override void Quack()
        {
            throw new NotImplementedException();
        }
    }
}
