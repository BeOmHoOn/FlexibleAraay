using System;
using System.Collections;
using System.Collections.Generic;

namespace Indexer
{
    public class FlexibleArray<T> : IEnumerable<T>
    {
        private const int _maxArraySize = Int32.MaxValue;
        private const int _defaultArraySize = 8;

        private T[] _items;

        public T[] Items
        {
            get
            {
                var returnArray = new T[_size];
                Array.Copy(_items, returnArray, _size);

                return returnArray;
            }
        }

        private int _size;
        public int Length => _size;
        public int TrueLength
        {
            get => _items.Length;
            private set
            {
                if (value > 0 && value != TrueLength)
                {
                    var replaceItem = new T[value];

                    if (_size > 0)
                        Array.Copy(_items, 0, replaceItem, 0, _size);

                    _items = replaceItem;
                }
            }
        }

        public FlexibleArray(int size = 0)
        {
            if (size < 0)
                throw new ArgumentException();

            _items = new T[size];
        }

        private void Resize(int size)
        {
            if (TrueLength >= size)
                return;

            if (size > _maxArraySize)
                size = _maxArraySize;

            _items = new T[TrueLength == 0 ? _defaultArraySize : TrueLength * 2];
        }

        public T this[int index]
        {
            get
            {
                if (index >= _size)
                    throw new ArgumentException();

                return _items[index];
            }
            set
            {
                if (index >= _items.Length)
                    Resize(index + 1);

                _size = Math.Max(_size, index + 1);

                _items[index] = value;
            }
        }

        #region [ IEnumerable Helper ]
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)Items).GetEnumerator();
        }
        #endregion
    }
}
