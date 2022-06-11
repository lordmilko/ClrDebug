using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    public class CorDebugHeapSegmentEnum : IEnumerable<COR_SEGMENT>, IEnumerator<COR_SEGMENT>
    {
        private ICorDebugHeapSegmentEnum rawEnumerator;

        public CorDebugHeapSegmentEnum(ICorDebugHeapSegmentEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(COR_SEGMENT);
        }

        public CorDebugHeapSegmentEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugHeapSegmentEnum((ICorDebugHeapSegmentEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<COR_SEGMENT> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public COR_SEGMENT Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            uint fetched;
            COR_SEGMENT result;
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