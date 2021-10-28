using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CustomRandomList
{
    public class RandomList<T> : List<T>
    {
        private Random random;
        public RandomList()
        {
            random = new Random();
        }

        public T RandomString()
        {
            var index = random.Next(0, Count);
            T element=  this[index];
            RemoveRandomElement();
            return element;
        }

        public void RemoveRandomElement()
        {
            var index = random.Next(0, Count);
            RemoveAt(index);
        }
    }
}
