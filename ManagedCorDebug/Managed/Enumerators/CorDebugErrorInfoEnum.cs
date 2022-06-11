using System;
using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    public class CorDebugErrorInfoEnum : IEnumerable<CorDebugEditAndContinueErrorInfo>, IEnumerator<CorDebugEditAndContinueErrorInfo>
    {
        private ICorDebugErrorInfoEnum rawEnumerator;

        public CorDebugErrorInfoEnum(ICorDebugErrorInfoEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorDebugEditAndContinueErrorInfo);
        }

        public CorDebugErrorInfoEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugErrorInfoEnum((ICorDebugErrorInfoEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugEditAndContinueErrorInfo> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugEditAndContinueErrorInfo Current { get; private set; }

        object IEnumerator.Current => Current;

        [Obsolete]
        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            uint fetched;
            ICorDebugEditAndContinueErrorInfo result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = new CorDebugEditAndContinueErrorInfo(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}