using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods and enumerates <see cref="ICorDebugThread"/> arrays.
    /// </summary>
    public class CorDebugThreadEnum : IEnumerable<CorDebugThread>, IEnumerator<CorDebugThread>
    {
        public ICorDebugThreadEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugThreadEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugThreadEnum(ICorDebugThreadEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugThread);
        }

        public CorDebugThreadEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugThreadEnum((ICorDebugThreadEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugThread> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugThread Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            ICorDebugThread result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = new CorDebugThread(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
