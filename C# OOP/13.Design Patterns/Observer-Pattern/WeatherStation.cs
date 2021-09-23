using Observer_Pattern.interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern
{
    public class WeatherStation : IObservable
    {
        private IList<IObserver> observers;
        private int temperature = 0;

        public WeatherStation()
        {
            this.observers = new List<IObserver>();
        }

        public int Temperature 
        {
            get
            {
                return this.temperature;
            }
            set
            {
                if (this.temperature != value)
                {
                    this.temperature = value;
                    notify();
                }
            }
        }

        public void notify()
        {
            foreach (var observer in this.observers)
            {
                observer.Update();
            }
        }

        public void Add(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public int GetTemperature()
        {
            return this.Temperature;
        }
    }
}
