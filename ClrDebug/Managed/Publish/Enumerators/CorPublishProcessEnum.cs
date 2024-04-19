using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// A subclass of the <see cref="ICorPublishEnum"/> interface that provides methods to traverse a collection of <see cref="ICorPublishProcess"/> objects.
    /// </summary>
    /// <remarks>
    /// The ICorPublishProcessEnum interface implements the methods of the abstract interface, <see cref="ICorPublishEnum"/>.
    /// An ICorPublishProcessEnum instance is created by the <see cref="CorPublish.EnumProcesses"/> method. The traversal
    /// of the collection of ICorPublishProcess objects is based on the filter criteria given at the time the ICorPublishProcessEnum
    /// instance was created.
    /// </remarks>
    public class CorPublishProcessEnum : IEnumerable<CorPublishProcess>, IEnumerator<CorPublishProcess>
    {
        public ICorPublishProcessEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorPublishProcessEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorPublishProcessEnum(ICorPublishProcessEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorPublishProcess);
        }

        public CorPublishProcessEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorPublishEnum clone;
            Raw.Clone(out clone);

            return new CorPublishProcessEnum((ICorPublishProcessEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorPublishProcess> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorPublishProcess Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            ICorPublishProcess result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new CorPublishProcess(result);
            else
                Current = default(CorPublishProcess);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
