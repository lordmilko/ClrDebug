using System.Collections;
using System.Collections.Generic;

namespace ClrDebug.DIA
{
    public class EnumSTATPROPSTG : IEnumerable<STATPROPSTG>, IEnumerator<STATPROPSTG>
    {
        public IEnumSTATPROPSTG Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumSTATPROPSTG"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public EnumSTATPROPSTG(IEnumSTATPROPSTG raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(STATPROPSTG);
        }

        public EnumSTATPROPSTG Clone()
        {
            if (Raw == null)
                return this;

            IEnumSTATPROPSTG clone;
            Raw.Clone(out clone);

            return new EnumSTATPROPSTG(clone);
        }

        #region IEnumerable

        public IEnumerator<STATPROPSTG> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public STATPROPSTG Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            STATPROPSTG result;
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
