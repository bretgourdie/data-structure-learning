using System;
using System.Collections;

namespace Data_Structures
{
    public class Vector<T> : IEnumerable
    {
        private T[] _array;
        private int _size;
        private int _capacity;

        public int Length
        {
            get
            {
                return _size;
            }
        }

        public Vector(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException(
                    "Can't have a negative capacity.",
                    "capacity");
            }

            this._capacity = capacity;
            _array = new T[capacity];
        }

        public IEnumerator GetEnumerator()
        {
            return new VectorEnumerator(this);
        }

        private class VectorEnumerator : IEnumerator
        {
            private int _position;
            private Vector<T> _vector;

            public VectorEnumerator(Vector<T> vector)
            {
                this._vector = vector;
                this.Reset();
            }

            public object Current
            {
                get
                {
                    return this._vector.Get(this._position);
                }
            }

            public bool MoveNext()
            {
                this._position++;
                return (_position < this._vector.Length);
            }

            public void Reset()
            {
                _position = -1;
            }

        }

        public T Get(int index)
        {
            if (index < 0 || index >= this.Length)
            {
                throw new IndexOutOfRangeException();
            }

            return _array[index];
        }

        public bool Add(T item)
        {
            if(this.Length < this._capacity)
            {
                _array = resizeArray(this._capacity * 2);
            }

            _array[this.Length] = item;

            this._size++;

            return true;
        }

        public bool Insert(int index, T item)
        {
            if(index >= this.Length)
            {
                throw new IndexOutOfRangeException();
            }

            if(index >= this._capacity)
            {
                _array = resizeArray(this._capacity * 2);
            }

            _array[index] = item;

            this._size++;

            return true;
        }

        public T Delete(int index, T item)
        {
            T itemToReturn = default(T);

            if(index >= this.Length)
            {
                throw new IndexOutOfRangeException();
            }

            itemToReturn = _array[index];

            for(int ii = index; ii < this.Length; ii++)
            {
                if(ii+1 < this.Length)
                {
                    _array[ii] = _array[ii+1];
                }
            }

            _array[this.Length] = default(T);

            this._size--;

            return itemToReturn;
        }

        private T[] resizeArray(int newSize)
        {
            var newArray = new T[newSize];

            for(int ii = 0; ii < _array.Length; ii++)
            {
                newArray[ii] = _array[ii];
            }

            this._capacity = newSize;

            return newArray;
        }
    }
}
