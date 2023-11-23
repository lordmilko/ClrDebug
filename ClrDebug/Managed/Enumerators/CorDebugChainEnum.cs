using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods, and enumerates <see cref="ICorDebugChain"/> arrays.
    /// </summary>
    public class CorDebugChainEnum : IEnumerable<CorDebugChain>, IEnumerator<CorDebugChain>
    {
        public ICorDebugChainEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugChainEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugChainEnum(ICorDebugChainEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugChain);
        }

        public CorDebugChainEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugChainEnum((ICorDebugChainEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugChain> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugChain Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            ICorDebugChain result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new CorDebugChain(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
