using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        private List<T> values = new List<T>();

        public Box(List<T> Values)
        {
            this.values = Values;
        }

        public List<T> SwapElements(int first,int second)
        {
            T firstElement = values[first];
            values[first] = values[second];
            values[second] = firstElement;

            return values;
        }

        public int CountMethod<T>(List<T> list, T element)
            where T : IComparable
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in values)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString();
        }
    }
}
