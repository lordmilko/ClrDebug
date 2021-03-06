using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods, and enumerates <see cref="ICorDebugBreakpoint"/> arrays.
    /// </summary>
    public class CorDebugBreakpointEnum : IEnumerable<CorDebugBreakpoint>, IEnumerator<CorDebugBreakpoint>
    {
        private ICorDebugBreakpointEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugBreakpointEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public CorDebugBreakpointEnum(ICorDebugBreakpointEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorDebugBreakpoint);
        }

        public CorDebugBreakpointEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

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
            if (rawEnumerator == null)
                return false;

            int fetched;
            ICorDebugBreakpoint result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

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