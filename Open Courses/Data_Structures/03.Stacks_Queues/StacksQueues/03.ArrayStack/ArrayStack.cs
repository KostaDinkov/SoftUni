namespace _03.ArrayStack
{
    using System;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private T[] elements;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }
            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            this.Count--;
            return this.elements[this.Count];
        }

        public T[] ToArray()
        {
            // So by the specification of the test
            // ToArray should return the stack in reversed order
            // i.e. in the order of popping the elements

            var resultArray = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                resultArray[i] = this.elements[this.Count-1-i];
            }
            return resultArray;
        }

        private void Grow()
        {
            var resized = new T[this.elements.Length*2];
            Array.Copy(this.elements, resized, this.Count);
            this.elements = resized;
        }
    }
}