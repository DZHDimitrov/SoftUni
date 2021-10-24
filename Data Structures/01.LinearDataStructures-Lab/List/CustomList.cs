using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class CustomList<T> : IEnumerable
    {
        private T[] _list;
        private int _countOfElements;

        public CustomList()
        {
            this._list = new T[4];
        }

        public int Count
        {
            get
            {
                return this._countOfElements;
            }
            set
            {
                this._countOfElements += value;
            }
        }

        public T this[int index]
        {
            get
            {
                return this._list[index];
            }
            set
            {
                this._list[index] = value;
            }
        }

        public void Add(T item)
        {
            GrowIfNecessary();
            this._list[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this._list.Length; i++)
            {
                if (this._list[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public int indexOf(T item)
        {
            for (int i = 0; i < this._list.Length; i++)
            {
                if (this._list[i].Equals(item))
                {
                    return i;
                } 
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.GrowIfNecessary();

            for (int i = this.Count; i > index; i--)
            {
                this._list[i] = this._list[i - 1];
                this._list[index] = item;
                this.Count++;
            }
        }

        public bool Remove(T item)
        {
            var index = indexOf(item);
            if (index == -1)
            {
                return false;
            }
            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            for (int i = index; i < this.Count-1; i++)
            {
                this._list[i] = this._list[i + 1];
            }

            this._list[this.Count - 1] = default;
            this.Count--;
        }

        private void GrowIfNecessary()
        {
            if (this.Count == this._list.Length)
            {
                this._list = this.Grow();
            }
        }

        private T[] Grow()
        {
            var newList = new T[this._list.Length * 2];
            Array.Copy(this._list, newList, this._list.Length);
            return newList;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this._list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
