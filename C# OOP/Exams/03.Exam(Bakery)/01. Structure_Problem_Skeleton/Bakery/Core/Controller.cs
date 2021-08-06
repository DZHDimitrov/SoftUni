using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private ICollection<IBakedFood> bakedFoods;
        private ICollection<IDrink> drinks;
        private ICollection<ITable> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }
            this.drinks.Add(drink);
            return $"{string.Format(OutputMessages.DrinkAdded, name, brand)}";
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }
            this.bakedFoods.Add(food);
            return $"{string.Format(OutputMessages.FoodAdded, name, type)}";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);
            return $"{string.Format(OutputMessages.TableAdded,tableNumber)}";
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = this.tables.Where(x => x.IsReserved == false).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();

        }

        public string GetTotalIncome()
        {
            return $"{string.Format(OutputMessages.TotalIncome,this.totalIncome)}";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var bill = table.GetBill();
            this.totalIncome += bill;
            table.Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}")
              .AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return $"{string.Format(OutputMessages.WrongTableNumber, tableNumber)}";
            }
            var drink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (drink == null)
            {
                return $"{string.Format(OutputMessages.NonExistentDrink,drinkName,drinkBrand)}";
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return $"{string.Format(OutputMessages.WrongTableNumber, tableNumber)}";
            }
            var food = this.bakedFoods.FirstOrDefault(x => x.Name == foodName);
            if (food == null)
            {
                return $"{string.Format(OutputMessages.NonExistentFood, foodName)}";
            }
            table.OrderFood(food);
            return $"{string.Format(OutputMessages.FoodOrderSuccessful,tableNumber,foodName)}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = this.tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);

            if (table == null)
            {
                return $"{string.Format(OutputMessages.ReservationNotPossible,numberOfPeople)}";
            }
            else
            {
                table.Reserve(numberOfPeople);
                return $"{string.Format(OutputMessages.TableReserved,table.TableNumber,numberOfPeople)}";
            }
        }
    }
}
