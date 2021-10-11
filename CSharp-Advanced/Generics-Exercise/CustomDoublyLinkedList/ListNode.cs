using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }
        public ListNode<T> Previous { get; set; }
        public ListNode<T> Next { get; set; }
        public T Value { get; set; }
    }
}
