using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Provides the Next method, which returns a specified number of <see cref="ICorDebugAppDomainEnum"/> values starting at the next location in the enumeration.<para/>
    /// This interface is a subclass of "ICorDebugEnum".
    /// </summary>
    public class CorDebugAppDomainEnum : IEnumerable<CorDebugAppDomain>, IEnumerator<CorDebugAppDomain>
    {
        public ICorDebugAppDomainEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugAppDomainEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugAppDomainEnum(ICorDebugAppDomainEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugAppDomain);
        }

        public CorDebugAppDomainEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugAppDomainEnum((ICorDebugAppDomainEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugAppDomain> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugAppDomain Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            ICorDebugAppDomain result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new CorDebugAppDomain(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
