using LinkedList;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatckImplementation
{
    public class CustomStack<T>
    {
        private LinkedList<T> _linkedList;

        public CustomStack()
        {
            this._linkedList = new LinkedList<T>();
        }

        void Push(T item)
        {
            this._linkedList.Add(item);
        }

        public T Pop(T item)
        {
          return  this._linkedList.Remove().Value;
        }
        public T Peek()
        {
            return this._linkedList.Head.Value;
        }
    }
}
