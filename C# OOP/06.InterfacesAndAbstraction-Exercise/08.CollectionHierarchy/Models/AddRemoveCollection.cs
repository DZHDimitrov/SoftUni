using _09.CollectionHierachy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierachy.Models
{
    public class AddRemoveCollection : IAdd, IRemove, ICollection
    {
        public AddRemoveCollection()
        {
            AnAddCollection = new List<string>();
        }
        public List<string> AnAddCollection { get; }

        public int Add(string item)
        {
            AnAddCollection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string item = AnAddCollection[AnAddCollection.Count - 1];
            AnAddCollection.RemoveAt(AnAddCollection.Count - 1);
            return item;
        }
        public override string ToString()
        {
            return string.Join(" ", AnAddCollection);
        }
    }
}
