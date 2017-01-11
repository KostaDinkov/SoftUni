namespace _07.LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private QueueNode<T> head;
        private QueueNode<T> tail;

        public LinkedQueue()
        {
            this.head = null;
            this.tail = null;
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.head == null)
            {
                this.head = new QueueNode<T>(element);
                this.head.PrevNode = null;
                this.head.NextNode = null;
                this.tail = this.head;
            }
            else
            {
                this.tail.NextNode = new QueueNode<T>(element, this.tail);
                this.tail.NextNode.PrevNode = this.tail;
                this.tail = this.tail.NextNode;
                this.tail.NextNode = null;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            //TODO : Try to make it simpler
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            var returnValue = this.head.Value;

            if (this.head.NextNode != null)
            {
                this.head = this.head.NextNode;
            }

            if (this.head.PrevNode != null)
            {
                this.head.PrevNode = null;
            }
            this.Count--;
            return returnValue;
        }

        public T[] ToArray()
        {
            var resultArray = new T[this.Count];
            var currentElement = this.head;
            var index = 0;
            while (currentElement != null)
            {
                resultArray[index] = currentElement.Value;
                currentElement = currentElement.NextNode;
                index++;
            }
            return resultArray;
        }

        private class QueueNode<T>
        {
            public QueueNode(T element, QueueNode<T> next = null, QueueNode<T> prev = null)
            {
                this.Value = element;
            }

            public T Value { get; }
            public QueueNode<T> NextNode { get; set; }
            public QueueNode<T> PrevNode { get; set; }
        }
    }
}