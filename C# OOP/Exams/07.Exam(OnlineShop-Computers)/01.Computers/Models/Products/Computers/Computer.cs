using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<Components.IComponent> components;
        private ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<Components.IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
        {
            get
            {
                if (components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + this.components.Average(x => x.OverallPerformance);
                }
            }
        }
        public override decimal Price
        {
            get
            {
                return base.Price + this.components.Sum(x => x.Price) + this.Peripherals.Sum(x => x.Price);
            }
        }

        public IReadOnlyCollection<Components.IComponent> Components => (IReadOnlyCollection<Components.IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)this.peripherals;

        public void AddComponent(Components.IComponent component)
        {
            if (this.components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }
            this.peripherals.Add(peripheral);
        }

        public Components.IComponent RemoveComponent(string componentType)
        {
            var component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (component == null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (peripheral == null)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }
            this.peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var averagePeripherals = this.peripherals.Count > 0 ? this.peripherals.Average(x => x.OverallPerformance) : 0.00;
            sb.AppendLine(base.ToString())
              .AppendLine($" Components ({this.components.Count}):")
              .AppendLine(string.Join(Environment.NewLine, this.components.Select(x => $"  {x}")))
              .AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({averagePeripherals:F2}):")
              .AppendLine(string.Join(Environment.NewLine, this.peripherals.Select(x => $"  {x}")));

            return sb.ToString().TrimEnd();

        }
    }
}
