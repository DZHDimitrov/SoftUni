using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Method<T>
    {
        public static List<T> SwapElements(List<T> list,int first, int second)
        {
            T currentItem = list[first];
            list[first] = list[second];
            list[second] = currentItem;

            return list;
        }
    }
}
