using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods, and enumerates <see cref="ICorDebugChain"/> arrays.
    /// </summary>
    public class CorDebugChainEnum : IEnumerable<CorDebugChain>, IEnumerator<CorDebugChain>
    {
        private ICorDebugChainEnum rawEnumerator;

        public CorDebugChainEnum(ICorDebugChainEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorDebugChain);
        }

        public CorDebugChainEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugChainEnum((ICorDebugChainEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugChain> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugChain Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            int fetched;
            ICorDebugChain result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = new CorDebugChain(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}