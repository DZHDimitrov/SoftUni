using _03.MinHeap;
using System;
using System.Linq;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            var minHeap = new MinHeap<int>();
            cookies.ToList().ForEach(minHeap.Add);

            int smallestElement = minHeap.Peek();
            var steps = 0;
            while (smallestElement < k && minHeap.Size > 1)
            {
                var smallestCookie = minHeap.Dequeue();
                var secondSmallestCookie = minHeap.Dequeue();

                steps++;
                minHeap.Add(smallestCookie + 2 * secondSmallestCookie);
                smallestElement = minHeap.Peek();
            }

            return smallestElement >= k ? steps : -1;    
        }

        private void FillHeap(MinHeap<int> minHeap,int[] elements)
        {
            foreach (var element in elements)
            {
                minHeap.Add(element);
            }
        }
    }
}
