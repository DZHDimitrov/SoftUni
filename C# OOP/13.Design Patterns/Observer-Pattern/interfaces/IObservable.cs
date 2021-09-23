using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern.interfaces
{
    public interface IObservable
    {
        public void Add(IObserver observer);

        public void Remove(IObserver observer);

        public void notify();
    }
}
