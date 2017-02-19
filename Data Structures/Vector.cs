using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    public class Vector<T> : IEnumerable
    {
        private T[] _array;
        private int _size;

        public Vector(int capacity)
        {
            _array = new T[capacity];
        }

        public IEnumerator GetEnumerator()
        {
            return new VectorEnumerator(this)
        }

        private class VectorEnumerator
        {
            private int position;
            private Vector<T> vector;

            public VectorEnumerator(Vector<T> vector)
            {
                this.vector = vector;
                this.Reset();
            }

            public bool MoveNext()
            {
                if(position < vector._array.Length)
                {
                    position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                position = -1;
            }

            public T Current()
            {
                return this.vector[position];
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
            if(_size < _capacity)
            {
                _array = resizeArray(_capacity * 2);
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

            if(index >= _capacity)
            {
                _array = resizeArray(_capacity * 2);
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
                newArray[ii] = _array[ii]
            }

            return newArray;
        }
    }
}
