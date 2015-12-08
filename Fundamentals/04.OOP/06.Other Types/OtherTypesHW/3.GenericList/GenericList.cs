namespace _3.GenericList
{
    using System;
    using System.Collections.Generic;

    [Version(1.1)]
    internal class GenericList<T>

    {
        private const int InitialCapacity = 4;
        private static readonly T[] emptyArray = new T[0];
        private T[] items;
        private int size;
        //empty constructor
        public GenericList()
        {
            this.items = emptyArray;
        }

        // Get / Set element at specified position
        public T this[int index]
        {
            get
            {
                if ((uint) index >= (uint) this.size)
                    throw new ArgumentOutOfRangeException();
                return this.items[index];
            }

            set
            {
                if ((uint) index >= (uint) this.size)
                    throw new ArgumentOutOfRangeException();
                this.items[index] = value;
            }
        }

        public int Capacity
        {
            get { return this.items.Length; }

            set
            {
                if (value < this.size)
                    throw new ArgumentOutOfRangeException();
                if (value == this.items.Length)
                    return;
                if (value > 0)
                {
                    var objArray = new T[value];
                    if (this.size > 0)
                        Array.Copy(this.items, 0, objArray, 0, this.size);
                    this.items = objArray;
                }
                else
                    this.items = emptyArray;
            }
        }

        public override string ToString()
        {
            var tmp = new T[this.size];
            Array.Copy(this.items, tmp, this.size);
            return "[" + string.Join(", ", tmp) + "]";
        }

        // Return the number of elements in the list
        public int Count()
        {
            return this.size;
        }

        // Add element
        public void Add(T item)
        {
            if (this.size == this.items.Length)
                this.EnsureCapacity(this.size + 1);
            var objArray = this.items;
            var num = this.size;
            this.size = num + 1;
            var index = num;
            var obj = item;
            objArray[index] = obj;
        }

        // Clear all elements
        public void Clear()
        {
            if (this.size > 0)
            {
                Array.Clear(this.items, 0, this.size);
                this.size = 0;
            }
        }

        // Check if the list contains an element
        public bool Contains(T item)
        {
            if (item == null)
            {
                for (var index = 0; index < this.size; ++index)
                {
                    if (this.items[index] == null)
                        return true;
                }
                return false;
            }
            var @default = EqualityComparer<T>.Default;
            for (var index = 0; index < this.size; ++index)
            {
                if (@default.Equals(this.items[index], item))
                    return true;
            }
            return false;
        }

        // Return the index of a given item
        public int IndexOf(T item)
        {
            return Array.IndexOf(this.items, item, 0, this.size);
        }

        // Insert element at a given index
        public void Insert(int index, T item)
        {
            if ((uint) index > (uint) this.size)
                throw new ArgumentOutOfRangeException();
            if (this.size == this.items.Length)
                this.EnsureCapacity(this.size + 1);
            if (index < this.size)
                Array.Copy(this.items, index, this.items, index + 1, this.size - index);
            this.items[index] = item;
            this.size = this.size + 1;
        }

        // Remove element at position
        public void RemoveAt(int index)
        {
            if ((uint) index >= (uint) this.size)
                throw new ArgumentOutOfRangeException();
            this.size = this.size - 1;
            if (index < this.size)
                Array.Copy(this.items, index + 1, this.items, index, this.size - index);
            this.items[this.size] = default(T);
        }

        private void EnsureCapacity(int min)
        {
            if (this.items.Length >= min)
                return;
            var num = this.items.Length == 0 ? 4 : this.items.Length*2;
            if ((uint) num > 2146435071U)
                num = 2146435071;
            if (num < min)
                num = min;
            this.Capacity = num;
        }
    }
}