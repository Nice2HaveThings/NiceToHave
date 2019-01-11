using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NiceToHave.Collection
{
    public class NonRepeatableEnumerable<TType> : IEnumerable<TType>
    {
        private readonly TType[] _collection;

        private int _enumerationCounter = 0;

        public NonRepeatableEnumerable(IEnumerable<TType> collection)
        {
            _collection = collection.ToArray();
        }

        public IEnumerator<TType> GetEnumerator()
        {
            int length = _collection.Length;
            while(_enumerationCounter < length)
            {
                yield return _collection[_enumerationCounter++];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
