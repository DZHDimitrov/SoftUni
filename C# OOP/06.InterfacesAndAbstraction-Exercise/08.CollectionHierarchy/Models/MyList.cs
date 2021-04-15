using _09.CollectionHierachy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierachy.Models
{
    public class MyList : ICollection, IAdd, IRemove
    {
        public MyList()
        {
            AnAddCollection = new List<string>();
        }
        public int Used => AnAddCollection.Count;

        public List<string> AnAddCollection { get; }

        public int Add(string item)
        {
            AnAddCollection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string item = AnAddCollection[0];
            AnAddCollection.RemoveAt(0);
            return item;
        }
        public override string ToString()
        {
            return string.Join(" ", AnAddCollection);
        }
    }
}
