using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// A subclass of the <see cref="ICorPublishEnum"/> interface that provides methods to traverse a collection of <see cref="ICorPublishAppDomain"/> objects that currently exist within a process.
    /// </summary>
    /// <remarks>
    /// The ICorPublishAppDomainEnum interface implements the methods of the abstract interface, <see cref="ICorPublishEnum"/>.
    /// </remarks>
    public class CorPublishAppDomainEnum : IEnumerable<CorPublishAppDomain>, IEnumerator<CorPublishAppDomain>
    {
        public ICorPublishAppDomainEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorPublishAppDomainEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorPublishAppDomainEnum(ICorPublishAppDomainEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorPublishAppDomain);
        }

        public CorPublishAppDomainEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorPublishEnum clone;
            Raw.Clone(out clone);

            return new CorPublishAppDomainEnum((ICorPublishAppDomainEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorPublishAppDomain> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorPublishAppDomain Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            ICorPublishAppDomain result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new CorPublishAppDomain(result);
            else
                Current = default(CorPublishAppDomain);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
