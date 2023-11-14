using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods, and enumerates <see cref="ICorDebugFrame"/> arrays.
    /// </summary>
    public class CorDebugFrameEnum : IEnumerable<CorDebugFrame>, IEnumerator<CorDebugFrame>
    {
        public ICorDebugFrameEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugFrameEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugFrameEnum(ICorDebugFrameEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugFrame);
        }

        public CorDebugFrameEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugFrameEnum((ICorDebugFrameEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugFrame> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugFrame Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            ICorDebugFrame result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = CorDebugFrame.New(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
