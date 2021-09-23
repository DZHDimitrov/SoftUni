using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.BaseClasses
{
    public abstract class CardFactory
    {
        public abstract CreditCard GetCreditCard();
    }
}
