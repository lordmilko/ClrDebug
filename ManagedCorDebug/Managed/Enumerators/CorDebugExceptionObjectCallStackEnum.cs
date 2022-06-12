using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
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
        private ICorDebugExceptionObjectCallStackEnum rawEnumerator;

        public CorDebugExceptionObjectCallStackEnum(ICorDebugExceptionObjectCallStackEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorDebugExceptionObjectStackFrame);
        }

        public CorDebugExceptionObjectCallStackEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

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
            if (rawEnumerator == null)
                return false;

            uint fetched;
            CorDebugExceptionObjectStackFrame result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

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