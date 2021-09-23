using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern.interfaces
{
    public interface IObserver
    {
        public void Update();

        public void Subscribe();

        public void Unsubscribe();
    }
}
