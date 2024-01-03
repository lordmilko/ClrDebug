using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Provides an enumerator for call stack information that is embedded in an exception object. This interface is a subclass of the <see cref="ICorDebugEnum"/> interface.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugExceptionObjectCallStackEnum"/> interface implements the <see cref="ICorDebugEnum"/> interface. An <see cref="ICorDebugExceptionObjectCallStackEnum"/>
    /// instance is populated with <see cref="CorDebugExceptionObjectStackFrame"/> objects by calling the <see cref="CorDebugExceptionObjectValue.EnumerateExceptionCallStack"/>
    /// method. The call stack items in the collection can be enumerated by calling the <see cref="MoveNext"/> method
    /// </remarks>
    public class CorDebugExceptionObjectCallStackEnum : IEnumerable<CorDebugExceptionObjectStackFrame>, IEnumerator<CorDebugExceptionObjectStackFrame>
    {
        public ICorDebugExceptionObjectCallStackEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugExceptionObjectCallStackEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugExceptionObjectCallStackEnum(ICorDebugExceptionObjectCallStackEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugExceptionObjectStackFrame);
        }

        public CorDebugExceptionObjectCallStackEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugExceptionObjectCallStackEnum((ICorDebugExceptionObjectCallStackEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugExceptionObjectStackFrame> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugExceptionObjectStackFrame Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            CorDebugExceptionObjectStackFrame result;
            var hr = Raw.Next(1, out result, out fetched);

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
