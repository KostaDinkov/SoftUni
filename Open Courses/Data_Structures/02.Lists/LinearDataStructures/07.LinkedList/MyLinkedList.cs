namespace _07.LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class MyLinkedList<T> : IEnumerable<T>
    {
        private Node head;
        private Node tail;

        public MyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public int Count { get; private set; }

        private Node this[int index]
        {
            get
            {
                var node = this.head;
                for (var i = 0; i < index; i++)
                {
                    node = node.Next;
                }
                return node;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
            while (node != null)
            {
                yield return node.Data;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T item)
        {
            if (this.head == null)
            {
                this.head = new Node(item);
                this.tail = this.head;
                this.Count ++;
            }
            else
            {
                this.tail.Next = new Node(item);
                this.tail = this.tail.Next;
                this.Count++;
            }
        }

        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                this.head = this.head.Next;
                this.Count --;
                return;
            }
            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            var node = this[index - 1];
            node.Next = node.Next.Next;
            this.Count --;
        }

        public int FirstIndexOf(T item)
        {
            var index = 0;
            foreach (var node in this)
            {
                if (node.Equals(item))
                {
                    return index;
                }
                index ++;
            }
            return -1;
        }

        public int LastIndexOf(T item)
        {
            var index = 0;
            var lastIndex = -1;
            foreach (var node in this)
            {
                if (node.Equals(item))
                {
                    lastIndex = index;
                }
                index++;
            }
            return lastIndex;
        }

        private class Node
        {
            public Node Next;

            public Node(T data)
            {
                this.Data = data;
            }

            public T Data { get; }
        }
    }
}