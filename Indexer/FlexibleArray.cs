using System;
using System.Collections;
using System.Collections.Generic;

namespace Indexer
{
    public class FlexibleArray<T> : IEnumerable<T>
    {
        private bool _isInit = false;
        private T[] member;

        public int Length => member.Length;

        public FlexibleArray(int size = 0)
        {
            Resize(size);
        }

        public void Resize(int size)
        {
            if (!_isInit)
            {
                member = new T[size];
                _isInit = true;
                return;
            }
            else
            {
                T[] clone = new T[Length];
                Array.Copy(member, clone, Length);

                member = new T[size];
                for (int idx = 0; idx < clone.Length; idx++)
                {
                    member[idx] = clone[idx];
                }
            }
        }

        public T this[int index]
        {
            get
            {
                return member[index];
            }
            set
            {
                if (index >= member.Length)
                    Resize(index--);

                member[index] = value;
            }
        }

        #region [ IEnumerable Helper ]
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)member).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)member).GetEnumerator();
        }
        #endregion
    }
}
