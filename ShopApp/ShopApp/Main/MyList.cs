using System;
using System.Collections;

namespace ShopApp.Main
{
    public class MyList<T> : IEnumerable, IEnumerator
    {
        private int _position;
        private T[] _mass;
        private int _pos;

        public MyList()
        {
            _mass = new T[1];
            _position = -1;
            _pos = -1;
        }

        public int Count { get; set; } = 0;
        public T Current
        {
            get
            {
                try
                {
                    return _mass[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public T this[int index]
        {
            get { return _mass[index]; }
            set { _mass[index] = value; }
        }

        public void Add(T mass)
        {
            Count++;
            Array.Resize(ref _mass, Count);
            _pos++;
            _mass[_pos] = mass;
        }

        public void AddRange(T[] mass)
        {
            Count += mass.Length;
            Array.Resize(ref _mass, Count);
            _pos++;
            for (var i = 0; i < mass.Length; i++)
            {
                _mass[_pos] = mass[i];
                _pos++;
            }
        }

        public void Remove(T element)
        {
            var elementIndex = Array.IndexOf(_mass, element);
            RemoveAt(elementIndex);
        }

        public void RemoveAt(int index)
        {
            Count--;
            _pos--;

            T[] bufferArray = new T[_mass.Length - 1];
            for (var i = 0; i < index; i++)
            {
                bufferArray[i] = _mass[i];
            }

            for (var i = index + 1; i < _mass.Length; i++)
            {
                bufferArray[i - 1] = _mass[i];
            }

            _mass = bufferArray;
        }

        public void Sort()
        {
            Array.Sort(_mass);
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _mass.Length;
        }

        public void Reset()
        {
            _position = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return _mass.GetEnumerator();
        }
    }
}
