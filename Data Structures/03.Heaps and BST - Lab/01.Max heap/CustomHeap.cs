namespace Heap
{
    public class CustomHeap<T> where T : IComparable<T>
    {
        private List<T> heap;

        public CustomHeap()
        {
            this.heap = new List<T>();
        }

        public int Size => heap.Count;

        public T Peek()
        {
            return heap[0];
        }

        public void Add(T value)
        {
            heap.Add(value);
            Heapify(heap.Count - 1);
        }

        private void Swap()
        {
            var temp = this.heap[this.heap.Count - 1];
            this.heap[this.heap.Count - 1] = this.heap[0];
            this.heap[0] = temp;
        }

        private void Heapify(int index)
        {
            int parentIndex = (index - 1) / 2;

            if (this.heap[parentIndex].CompareTo(this.heap[index]) < 0)
            {
                var temp = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[index];
                this.heap[index] = temp;
                Heapify(parentIndex);
            }
        }

        public string InOrderDfs(int index, int indent = 0)
        {
            string result = "";
            int leftChild = index * 2 + 1;
            int rightChild = index * 2 + 2;

            if (leftChild < this.heap.Count)
            {
                result += InOrderDfs(leftChild, indent + 3);
            }

            result += $"{new string(' ', indent)}{this.heap[index]}\r\n";

            if (rightChild < this.heap.Count)
            {
                result += InOrderDfs(rightChild, indent + 3);
            }

            return result;
        }
    }
}
