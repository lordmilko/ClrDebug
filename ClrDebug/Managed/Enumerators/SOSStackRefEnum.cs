using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    public class SOSStackRefEnum : IEnumerable<SOSStackRefData>, IEnumerator<SOSStackRefData>
    {
        private ISOSStackRefEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SOSStackRefEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public SOSStackRefEnum(ISOSStackRefEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(SOSStackRefData);
        }

        #region IEnumerable

        public IEnumerator<SOSStackRefData> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public SOSStackRefData Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            int fetched;
            SOSStackRefData result;
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
