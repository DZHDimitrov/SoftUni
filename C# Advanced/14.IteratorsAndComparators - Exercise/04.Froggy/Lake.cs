using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> Positions = new List<int>();
        private int index;

        public Lake()
        {

        }
        public Lake(List<int> positions)
        {
            Positions = positions;
            index = Count;
        }

        public int Count => Positions.Count;

        public void Add(int number)
        {
            Positions.Add(number);
            index++;
        }
        public void MyReverse()
        {
            Positions.Reverse();
        }

        public void RemoveAt(int index)
        {
            Positions.RemoveAt(index);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Positions.Count; i++)
            {
                yield return Positions[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
