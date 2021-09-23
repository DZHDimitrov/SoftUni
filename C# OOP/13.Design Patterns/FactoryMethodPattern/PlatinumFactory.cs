using FactoryMethodPattern.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class PlatinumFactory : CardFactory
    {
        private int _cardLimit;
        private int _annualCharge;

        public PlatinumFactory(int cardLimit,int annualCharge)
        {
            this._cardLimit = cardLimit;
            this._annualCharge = annualCharge;
        }
        public override CreditCard GetCreditCard()
        {
            return new PlatinumCreditCard(this._cardLimit, this._annualCharge);
        }
    }
}
