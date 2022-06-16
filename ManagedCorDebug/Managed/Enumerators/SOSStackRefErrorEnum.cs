using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    public class SOSStackRefErrorEnum : IEnumerable<SOSStackRefError>, IEnumerator<SOSStackRefError>
    {
        private ISOSStackRefErrorEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SOSStackRefErrorEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public SOSStackRefErrorEnum(ISOSStackRefErrorEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
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
            if (rawEnumerator == null)
                return false;

            int fetched;
            SOSStackRefError result;
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