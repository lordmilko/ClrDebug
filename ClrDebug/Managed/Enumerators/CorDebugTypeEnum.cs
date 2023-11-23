using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Implements "ICorDebugEnum" methods and enumerates "ICorDebugType" arrays.
    /// </summary>
    public class CorDebugTypeEnum : IEnumerable<CorDebugType>, IEnumerator<CorDebugType>
    {
        public ICorDebugTypeEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugTypeEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugTypeEnum(ICorDebugTypeEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugType);
        }

        public CorDebugTypeEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugTypeEnum((ICorDebugTypeEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugType> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugType Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            ICorDebugType result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new CorDebugType(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
