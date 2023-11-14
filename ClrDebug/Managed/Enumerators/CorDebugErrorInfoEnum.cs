using System;
using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// <see cref="ICorDebugErrorInfoEnum"/> is obsolete. Do not use this interface.
    /// </summary>
    public class CorDebugErrorInfoEnum : IEnumerable<CorDebugEditAndContinueErrorInfo>, IEnumerator<CorDebugEditAndContinueErrorInfo>
    {
        public ICorDebugErrorInfoEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugErrorInfoEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugErrorInfoEnum(ICorDebugErrorInfoEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugEditAndContinueErrorInfo);
        }

        public CorDebugErrorInfoEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

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
            if (Raw == null)
                return false;

            int fetched;
            ICorDebugEditAndContinueErrorInfo result;
            var hr = Raw.Next(1, out result, out fetched);

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
