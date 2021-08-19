using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private ICollection<IComputer> computers;
        private ICollection<IPeripheral> peripherals;
        private ICollection<Models.Products.Components.IComponent> components;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<Models.Products.Components.IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            var computer = CheckIfComputerExists(computerId);
            Models.Products.Components.IComponent component = null;
            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id,manufacturer,model,price,overallPerformance,generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            computer.AddComponent(component);
            this.components.Add(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computer.Id}.";

        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(x=>x.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            if (computerType == "DesktopComputer")
            {
                this.computers.Add(new DesktopComputer(id, manufacturer, model, price));
            }
            else if (computerType == "Laptop")
            {
                this.computers.Add(new Laptop(id, manufacturer, model, price));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            return $"Computer with id {id} added successfully.";

        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            var computer = CheckIfComputerExists(computerId);
            if (this.peripherals.Any(x=>x.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }
            IPeripheral peripheral = null;
            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }
            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);
            return $"Peripheral {peripheralType} with id {peripheral.Id} added successfully in computer with id {computer.Id}.";
        }

        public string BuyBest(decimal budget)
        {
            var computer = this.computers.OrderByDescending(x => x.OverallPerformance).FirstOrDefault(x => x.Price <= budget);
            if (computer == null)
            {
                throw new ArgumentException($" Can't buy a computer with a budget of {budget}.");
            }
            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            var computer = CheckIfComputerExists(id);
            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            var computer = CheckIfComputerExists(id);
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var computer = CheckIfComputerExists(computerId);
            var component = computer.RemoveComponent(componentType);
            this.components.Remove(this.components.FirstOrDefault(x => x.GetType().Name == componentType));
            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var computer = CheckIfComputerExists(computerId);
            var currentPeripheral = computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType));
            return $"Successfully removed {peripheralType} with id { currentPeripheral.Id}.";
        }

        private IComputer CheckIfComputerExists(int computerId)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            return computer;
        }
    }
}
