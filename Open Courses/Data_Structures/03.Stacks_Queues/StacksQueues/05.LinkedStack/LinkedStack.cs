namespace _05.LinkedStack
{
    using System;

    public class LinkedStack<T>
    {
        private Node<T> firstNode;
        public int Count { get; set; }

        public void Push(T element)
        {
            this.firstNode = new Node<T>(element, this.firstNode);
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            var value = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;
            return value;
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];
            var currentNode = this.firstNode;
            var index = 0;
            while (currentNode != null)
            {
                result[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }
            return result;
        }

        private class Node<T>
        {
            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }

            public T Value { get; }
            public Node<T> NextNode { get; }
        }
    }
}