using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    public class CorDebugGCReferenceEnum : IEnumerable<COR_GC_REFERENCE>, IEnumerator<COR_GC_REFERENCE>
    {
        private ICorDebugGCReferenceEnum rawEnumerator;

        public CorDebugGCReferenceEnum(ICorDebugGCReferenceEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(COR_GC_REFERENCE);
        }

        public CorDebugGCReferenceEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugGCReferenceEnum((ICorDebugGCReferenceEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<COR_GC_REFERENCE> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public COR_GC_REFERENCE Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            uint fetched;
            COR_GC_REFERENCE result;
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