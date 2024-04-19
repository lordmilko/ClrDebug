using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    public class EnumSTATSTG : IEnumerable<STATSTG>, IEnumerator<STATSTG>
    {
        public IEnumSTATSTG Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumSTATSTG"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public EnumSTATSTG(IEnumSTATSTG raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(STATSTG);
        }

        public EnumSTATSTG Clone()
        {
            if (Raw == null)
                return this;

            IEnumSTATSTG clone;
            Raw.Clone(out clone);

            return new EnumSTATSTG(clone);
        }

        #region IEnumerable

        public IEnumerator<STATSTG> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public STATSTG Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            STATSTG result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result;
            else
                Current = default(STATSTG);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
