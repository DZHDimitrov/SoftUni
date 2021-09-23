using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.BaseClasses
{
    public abstract class CreditCard
    {
        public abstract string CardType { get; set; }

        public abstract int CardLimit { get; set; }

        public abstract int AnnualCharge { get; set; }
    }
}
