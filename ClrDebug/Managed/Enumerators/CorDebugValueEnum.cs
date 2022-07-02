using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Implements "ICorDebugEnum" methods and enumerates "ICorDebugValue" arrays.
    /// </summary>
    public class CorDebugValueEnum : IEnumerable<CorDebugValue>, IEnumerator<CorDebugValue>
    {
        private ICorDebugValueEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugValueEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public CorDebugValueEnum(ICorDebugValueEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorDebugValue);
        }

        public CorDebugValueEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugValueEnum((ICorDebugValueEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugValue> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugValue Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            int fetched;
            ICorDebugValue result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = CorDebugValue.New(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}