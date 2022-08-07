using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    public class CorDebugMemoryRangeEnum : IEnumerable<COR_MEMORY_RANGE>, IEnumerator<COR_MEMORY_RANGE>
    {
        private ICorDebugMemoryRangeEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugMemoryRangeEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public CorDebugMemoryRangeEnum(ICorDebugMemoryRangeEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(COR_MEMORY_RANGE);
        }

        public CorDebugMemoryRangeEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugMemoryRangeEnum((ICorDebugMemoryRangeEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<COR_MEMORY_RANGE> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public COR_MEMORY_RANGE Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            int fetched;
            COR_MEMORY_RANGE result;
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
