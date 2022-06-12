using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods, and enumerates arrays of objects by their relative virtual addresses (RVAs).
    /// </summary>
    public class CorDebugObjectEnum : IEnumerable<CORDB_ADDRESS>, IEnumerator<CORDB_ADDRESS>
    {
        private ICorDebugObjectEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugObjectEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public CorDebugObjectEnum(ICorDebugObjectEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CORDB_ADDRESS);
        }

        public CorDebugObjectEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugObjectEnum((ICorDebugObjectEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CORDB_ADDRESS> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CORDB_ADDRESS Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            int fetched;
            CORDB_ADDRESS result;
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