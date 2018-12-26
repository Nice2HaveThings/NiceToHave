using System.Collections;
using System.Collections.Generic;

namespace NiceToHave.Threading
{
    public class ConcurrentList<TType> : IList<TType>
    {
        private object _syncRoot = new object();

        private List<TType> _internalList;

        public TType this[int index]
        {
            get 
            {
                lock(_syncRoot)
                {
                    return _internalList[index];
                }
            }
            set
            {
                lock(_syncRoot)
                {
                    _internalList[index] = value;
                }
            }
        }

        public int Count
        {
            get
            {
                lock(_syncRoot)
                {
                    return _internalList.Count;
                }
            }
        }

        public bool IsReadOnly => false;

        public ConcurrentList()
        {
            _internalList = new List<TType>();
        }

        public ConcurrentList(int capacitiy)
        {
            _internalList = new List<TType>(capacitiy);
        }

        public ConcurrentList(IEnumerable<TType> oldList)
        {
            _internalList = new List<TType>(oldList);
        }

        public void Add(TType item)
        {
            lock(_syncRoot)
            {
                _internalList.Add(item);
            }
        }

        public void Clear()
        {
            lock(_syncRoot)
            {
                _internalList.Clear();
            }
        }

        public bool Contains(TType item)
        {
            lock(_syncRoot)
            {
                return _internalList.Contains(item);
            }
        }

        public void CopyTo(TType[] array, int arrayIndex)
        {
            lock(_syncRoot)
            {
                _internalList.CopyTo(array, arrayIndex);
            }
        }

        public IEnumerator<TType> GetEnumerator()
        {
            lock(_syncRoot)
            {
                foreach(TType element in _internalList)
                {
                    yield return element;
                }
            }
        }

        public int IndexOf(TType item)
        {
            lock(_syncRoot)
            {
                return _internalList.IndexOf(item);
            }
        }

        public void Insert(int index, TType item)
        {
            lock(_syncRoot)
            {
                _internalList.Insert(index, item);
            }
        }

        public bool Remove(TType item)
        {
            lock(_syncRoot)
            {
                return _internalList.Remove(item);
            }
        }

        public void RemoveAt(int index)
        {
            lock(_syncRoot)
            {
                _internalList.RemoveAt(index);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
