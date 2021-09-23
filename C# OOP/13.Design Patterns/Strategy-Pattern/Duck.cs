using Strategy_Pattern.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern
{
    public abstract class Duck : IFlyBehaviour
    {
        private readonly IFlyBehaviour fb;

        public Duck(IFlyBehaviour fb)
        {
            this.fb = fb;
        }

        public void Fly()
        {
            this.fb.Fly();
        }

        public abstract void Quack();

    }
}
