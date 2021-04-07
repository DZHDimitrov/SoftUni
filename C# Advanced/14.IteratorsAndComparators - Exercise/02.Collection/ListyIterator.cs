using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> items = new List<T>();
        private int index = 0;

        public ListyIterator(List<T> collectionToIterate)
        {
            items = collectionToIterate;
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (index == items.Count-1)
            {
                return false;
            }
            return true;
        }
        public void Print()
        {
            if (index >= items.Count)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(items[index]);
        }
        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", items));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
