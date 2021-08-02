﻿using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops.Contracts
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (!egg.IsDone())
            {
                if (bunny.Energy == 0)
                {
                    break;
                }

                if (bunny.Dyes.All(x => x.IsFinished()))
                {
                    break;
                }

                egg.GetColored();
                bunny.Work();
            }

        }
    }
}
