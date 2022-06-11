using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
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