using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory.Contracts
{
    public abstract class Bag : IBag
    {
        private readonly ICollection<Item> items = new List<Item>();

        public Bag()
        {

        }

        public Bag(int capacity)
        {
            this.Capacity = capacity;
        }


        public int Load => this.items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items
        {
            get;
            private set;
        }

        public int Capacity { get; set; } = 100;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            var item = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(item);
            return item;
        }
    }
}
