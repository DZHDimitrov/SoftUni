using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> items;
        private int index;

        public MyStack()
        {
            items = new List<T>();
            index = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        public T Pop()
        {
            T element = items[items.Count - 1];         
            items.RemoveAt(items.Count - 1);
            return element;
        }
        public void Push(T element)
        {
            items.Add(element);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
