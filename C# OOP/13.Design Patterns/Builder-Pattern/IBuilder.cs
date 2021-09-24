using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
   public interface IBuilder
    {
        IBuilder BuildPartA(object obj);

        IBuilder BuildPartB(object obj);

        IBuilder BuildPartC(object obj);
    }
}
