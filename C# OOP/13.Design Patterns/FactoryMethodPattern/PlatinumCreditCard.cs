using FactoryMethodPattern.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class PlatinumCreditCard : CreditCard
    {
        public PlatinumCreditCard(int cardLimit,int annualCharge)
        {
            this.CardType = "PlatinumCard";
            this.CardLimit = cardLimit;
            this.AnnualCharge = annualCharge;
        }

        public override string CardType { get; set; }
        public override int CardLimit { get; set; }
        public override int AnnualCharge { get; set; }
    }
}
