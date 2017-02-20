using System;
using System.Collections;

namespace Data_Structures
{
    public class Vector<T> : IEnumerable
    {
        private T[] _array;
        private int _size;
        private int _capacity;

        public Vector(int capacity)
        {
            this._capacity = capacity;
            _array = new T[capacity];
        }

        public IEnumerator GetEnumerator()
        {
            return new VectorEnumerator(this);
        }

        private class VectorEnumerator
        {
            private int _position;
            private Vector<T> _vector;

            public VectorEnumerator(Vector<T> vector)
            {
                this._vector = vector;
                this.Reset();
            }

            public bool MoveNext()
            {
                if(_position < _vector._array.Length)
                {
                    _position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                _position = -1;
            }

            public T Current()
            {
                return this._vector[this._position];
            }
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException();
            }

            return _array[index];
        }

        public bool Add(T item)
        {
            if(_size < this._capacity)
            {
                _array = resizeArray(this._capacity * 2);
            }

            _array[_size] = item;

            return true;
        }

        public bool Insert(int index, T item)
        {
            if(index >= _size)
            {
                throw new IndexOutOfRangeException();
            }

            if(index >= this._capacity)
            {
                _array = resizeArray(this._capacity * 2);
            }

            _array[index] = item;

            return true;
        }

        public T Delete(int index, T item)
        {
            T itemToReturn = null;

            if(index >= _size)
            {
                throw new IndexOutOfRangeException();
            }

            itemToReturn = _array[index];

            for(int ii = index; ii < _size; ii++)
            {
                if(ii+1 < _size)
                {
                    _array[ii] = _array[ii+1];
                }
            }

            _array[_size] = null;

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
