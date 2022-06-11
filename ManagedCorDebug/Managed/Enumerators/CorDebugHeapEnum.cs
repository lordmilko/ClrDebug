using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    public class CorDebugHeapEnum : IEnumerable<COR_HEAPOBJECT>, IEnumerator<COR_HEAPOBJECT>
    {
        private ICorDebugHeapEnum rawEnumerator;

        public CorDebugHeapEnum(ICorDebugHeapEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(COR_HEAPOBJECT);
        }

        public CorDebugHeapEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugHeapEnum((ICorDebugHeapEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<COR_HEAPOBJECT> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public COR_HEAPOBJECT Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            uint fetched;
            COR_HEAPOBJECT result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result;

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}