using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    public class SOSStackRefErrorEnum : IEnumerable<SOSStackRefError>, IEnumerator<SOSStackRefError>
    {
        public ISOSStackRefErrorEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SOSStackRefErrorEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SOSStackRefErrorEnum(ISOSStackRefErrorEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(SOSStackRefError);
        }

        #region IEnumerable

        public IEnumerator<SOSStackRefError> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public SOSStackRefError Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            SOSStackRefError result;
            var hr = Raw.Next(1, out result, out fetched);

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
