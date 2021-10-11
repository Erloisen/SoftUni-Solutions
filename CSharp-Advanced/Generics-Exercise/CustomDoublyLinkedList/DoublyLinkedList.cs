using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private ListNode<T> first = null;
        private ListNode<T> last = null;
        public int Count 
        {
            get
            {
                var count = 0;
                var current = first;
                while (current != null)
                {
                    count++;
                    current = current.Next;   
                }
                return count;
            }
        }
        public void AddFirst(T element)
        {
            var newItem = new ListNode<T>(element);
            if (first == null)
            {
                this.first = newItem;
                this.last = newItem;
            }
            else
            {
                newItem.Next = first;
                this.first.Previous = newItem;
                this.first = newItem;
            }
        }
        public void AddLast(T element)
        {
            var newItem = new ListNode<T>(element);
            if (first == null)
            {
                this.first = newItem;
                this.last = newItem;
            }
            else
            {
                last.Next = newItem;
                newItem.Previous = last;
                last = newItem;
            }
        }
        public T RemoveFirst()
        {
            if (first == null)
            {
                throw new InvalidOperationException("This list is empty!");
            }
            var currentFirstValue = first.Value;
            if (first == last)
            {
                this.first = null;
                this.last = null;
            }
            else
            {
                ListNode<T> newFirst = first.Next;
                newFirst.Previous = null;
                this.first = newFirst;
            }

            return currentFirstValue;
        }
        public T RemoveLast()
        {
            if (last == null)
            {
                throw new InvalidOperationException("This list is empty!");
            }
            var currentLastValue = last.Value;
            if (last == first)
            {
                this.first = null;
                this.last = null;
            }
            else
            {
                ListNode<T> newLast = last.Previous;
                newLast.Next = null;
                this.last = newLast;
            }

            return currentLastValue;
        }
        public void ForEach(Action<T> action)
        {
            /*
            var elements = ToArray();
            foreach (var element in elements)
            {
                action(element);
            }
            */
            
            ListNode<T> current = first;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }
        public T[] ToArray()
        {
            var array = new T[Count];
            var current = first;
            var index = 0;
            while (current != null)
            {
                array[index] = current.Value;
                index++;
                current = current.Next;
            }
            return array;
        }
    }
}
