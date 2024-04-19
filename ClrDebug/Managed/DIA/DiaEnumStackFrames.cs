using System.Collections;
using System.Collections.Generic;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various stack frames available.
    /// </summary>
    /// <remarks>
    /// Obtain this interface by calling the IDiaStackWalker or IDiaStackWalker methods.
    /// </remarks>
    public class DiaEnumStackFrames : IEnumerable<DiaStackFrame>, IEnumerator<DiaStackFrame>
    {
        public IDiaEnumStackFrames Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiaEnumStackFrames"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaEnumStackFrames(IDiaEnumStackFrames raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(DiaStackFrame);
        }

        #region IEnumerable

        public IEnumerator<DiaStackFrame> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public DiaStackFrame Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            IDiaStackFrame result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new DiaStackFrame(result);
            else
                Current = default(DiaStackFrame);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
