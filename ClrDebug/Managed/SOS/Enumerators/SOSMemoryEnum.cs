using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    public class SOSMemoryEnum : IEnumerable<SOSMemoryRegion>, IEnumerator<SOSMemoryRegion>
    {
        public ISOSMemoryEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SOSMemoryEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SOSMemoryEnum(ISOSMemoryEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(SOSMemoryRegion);
        }

        #region IEnumerable

        public IEnumerator<SOSMemoryRegion> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public SOSMemoryRegion Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            SOSMemoryRegion result;
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
