using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Implements "ICorDebugEnum" methods, and enumerates "ICorDebugCode" arrays.
    /// </summary>
    public class CorDebugCodeEnum : IEnumerable<CorDebugCode>, IEnumerator<CorDebugCode>
    {
        public ICorDebugCodeEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugCodeEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugCodeEnum(ICorDebugCodeEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugCode);
        }

        public CorDebugCodeEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugCodeEnum((ICorDebugCodeEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugCode> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugCode Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            ICorDebugCode result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = new CorDebugCode(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
