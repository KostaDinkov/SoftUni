namespace _06.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 4;
        private T[] items;
        private int size;

        public ReversedList()
        {
            this.items = new T[0];
        }

        public int Count { get { return this.size; } }

        public T this[int index] => this.items[this.size-1 - index];

        public int Capacity
        {
            get { return this.items.Length; }
            set
            {
                if (value < this.size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (value != this.items.Length)
                {
                    if (value > 0)
                    {
                        var newItems = new T[value];
                        if (this.size > 0)
                        {
                            Array.Copy(this.items, 0, newItems, 0, this.size);
                        }
                        this.items = newItems;
                    }
                    else
                    {
                        this.items = new T[0];
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = this.size-1; i >= 0; i--)
            {
                if (this.items[i] == null)
                {
                    break;
                }
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T item)
        {
            if (this.size == this.items.Length) this.EnsureCapacity(this.size + 1);
            this.items[this.size++] = item;
        }

        public void RemoveAt(int index)
        {
            index = this.size - 1 - index;
            if (index >= this.size)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.size--;
            if (index < this.size)
            {
                Array.Copy(this.items, index + 1, this.items, index, this.size - index);
            }
            this.items[this.size] = default(T);
            
        }

        private void EnsureCapacity(int min)
        {
            if (this.items.Length < min)
            {
                var newCapacity = this.items.Length == 0 ? DefaultCapacity : this.items.Length*2;

                if (newCapacity < min)
                {
                    newCapacity = min;
                }

                this.Capacity = newCapacity;
            }
        }


    }
}