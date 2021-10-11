using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T>
        where T:IComparable
    {
        public Box()
        {
            this.Values = new List<T>();
        }
        public List<T> Values { get; set; }
        public int GreaterValuesThan(T targetItem)
        {
            int counter = 0;
            foreach (var values in this.Values)
            {
                if (values.CompareTo(targetItem) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
