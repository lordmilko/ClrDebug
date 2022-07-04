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
        private ICorPublishAppDomainEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorPublishAppDomainEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public CorPublishAppDomainEnum(ICorPublishAppDomainEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorPublishAppDomain);
        }

        public CorPublishAppDomainEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorPublishEnum clone;
            rawEnumerator.Clone(out clone);

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
            if (rawEnumerator == null)
                return false;

            int fetched;
            ICorPublishAppDomain result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = new CorPublishAppDomain(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
