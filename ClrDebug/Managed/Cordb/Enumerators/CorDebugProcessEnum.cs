using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods and enumerates <see cref="ICorDebugProcess"/> arrays.
    /// </summary>
    public class CorDebugProcessEnum : IEnumerable<CorDebugProcess>, IEnumerator<CorDebugProcess>
    {
        public ICorDebugProcessEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugProcessEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugProcessEnum(ICorDebugProcessEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugProcess);
        }

        public CorDebugProcessEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugProcessEnum((ICorDebugProcessEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugProcess> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugProcess Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            ICorDebugProcess result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new CorDebugProcess(result);
            else
                Current = default(CorDebugProcess);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
