using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods, and enumerates <see cref="ICorDebugBreakpoint"/> arrays.
    /// </summary>
    public class CorDebugBreakpointEnum : IEnumerable<CorDebugBreakpoint>, IEnumerator<CorDebugBreakpoint>
    {
        public ICorDebugBreakpointEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugBreakpointEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugBreakpointEnum(ICorDebugBreakpointEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugBreakpoint);
        }

        public CorDebugBreakpointEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugBreakpointEnum((ICorDebugBreakpointEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugBreakpoint> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugBreakpoint Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            ICorDebugBreakpoint result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = CorDebugBreakpoint.New(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
