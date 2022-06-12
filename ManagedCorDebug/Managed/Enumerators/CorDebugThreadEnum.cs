using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods and enumerates <see cref="ICorDebugThread"/> arrays.
    /// </summary>
    public class CorDebugThreadEnum : IEnumerable<CorDebugThread>, IEnumerator<CorDebugThread>
    {
        private ICorDebugThreadEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugThreadEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public CorDebugThreadEnum(ICorDebugThreadEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorDebugThread);
        }

        public CorDebugThreadEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugThreadEnum((ICorDebugThreadEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugThread> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugThread Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            int fetched;
            ICorDebugThread result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = new CorDebugThread(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}