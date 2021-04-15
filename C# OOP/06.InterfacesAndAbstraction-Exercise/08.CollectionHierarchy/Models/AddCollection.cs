using _09.CollectionHierachy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierachy.Models
{
    public class AddCollection : IAdd,ICollection
    {
        public AddCollection()
        {
            AnAddCollection = new List<string>();
        }
        public List<string> AnAddCollection { get; }

        public int Add(string item)
        {
            AnAddCollection.Add(item);

            return AnAddCollection.Count - 1;
        }
    }
}
