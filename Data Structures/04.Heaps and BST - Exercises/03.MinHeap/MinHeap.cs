namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _elements;

        public MinHeap()
        {
            this._elements = new List<T>();
        }

        public int Size => this._elements.Count;

        public T Dequeue()
        {
            var element = this._elements[0];
            Swap();
            this._elements.RemoveAt(this._elements.Count - 1);
            HeapifyDown(0);
            return element;
        }

        private void Swap()
        {
            var temp = this._elements[0];
            this._elements[0] = this._elements[this._elements.Count - 1];
            this._elements[this._elements.Count - 1] = temp;
        }

        private void HeapifyDown(int index)
        {
            var leftChildIndex = index * 2 + 1;
            var rightChildIndex = index * 2 + 2;
            var minChildIndex = leftChildIndex;

            if (leftChildIndex > this._elements.Count -1)
            {
                return;
            }

            if ((rightChildIndex < this._elements.Count) && this._elements[leftChildIndex].CompareTo(this._elements[rightChildIndex]) > 0)
            {
                minChildIndex = rightChildIndex;
            }

            if (this._elements[minChildIndex].CompareTo(this._elements[index]) < 0)
            {
                var temp = this._elements[index];
                this._elements[index] = this._elements[minChildIndex];
                this._elements[minChildIndex] = temp;
                HeapifyDown(minChildIndex);
            }
            
        }


        public void Add(T element)
        {
            this._elements.Add(element);
            HeapifyUp(this._elements.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = (index - 1) / 2;

            if (this._elements[parentIndex].CompareTo(this._elements[index]) > 0)
            {
                var temp = this._elements[parentIndex];
                this._elements[parentIndex] = this._elements[index];
                this._elements[index] = temp;
                HeapifyUp(parentIndex);
            }
        }

        public T Peek()
        {
            return this._elements[0];
        }
    }
}
