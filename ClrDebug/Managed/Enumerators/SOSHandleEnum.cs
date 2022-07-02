using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    public class SOSHandleEnum : IEnumerable<SOSHandleData>, IEnumerator<SOSHandleData>
    {
        private ISOSHandleEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SOSHandleEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public SOSHandleEnum(ISOSHandleEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(SOSHandleData);
        }

        #region IEnumerable

        public IEnumerator<SOSHandleData> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public SOSHandleData Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            int fetched;
            SOSHandleData result;
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