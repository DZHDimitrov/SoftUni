using LinkedList;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatckImplementation
{
    public class CustomQueue<T>
    {
        private LinkedList<T> _linkedList;

        public CustomQueue()
        {
            this._linkedList = new LinkedList<T>();
        }

        public void Enqueue(T element)
        {
            this._linkedList.AddLast(element);
        }

        public T Peek()
        {
            return this._linkedList.Last.Value;
        }

        public T Dequeue()
        {
            return this._linkedList.Remove().Value;
        }
    }
}
