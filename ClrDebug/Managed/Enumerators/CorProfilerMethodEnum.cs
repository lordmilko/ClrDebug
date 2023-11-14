using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    public class CorProfilerMethodEnum : IEnumerable<COR_PRF_METHOD>, IEnumerator<COR_PRF_METHOD>
    {
        public ICorProfilerMethodEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorProfilerMethodEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorProfilerMethodEnum(ICorProfilerMethodEnum raw)
        {
            Raw = raw;
        }

        #region Count

        public int Count
        {
            get
            {
                int pcelt;
                TryGetCount(out pcelt).ThrowOnNotOK();

                return pcelt;
            }
        }

        public HRESULT TryGetCount(out int pcelt)
        {
            /*HRESULT GetCount(
            [Out] out int pcelt);*/
            return Raw.GetCount(out pcelt);
        }

        #endregion

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(COR_PRF_METHOD);
        }

        public CorProfilerMethodEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorProfilerMethodEnum clone;
            Raw.Clone(out clone);

            return new CorProfilerMethodEnum(clone);
        }

        #region IEnumerable

        public IEnumerator<COR_PRF_METHOD> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public COR_PRF_METHOD Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            COR_PRF_METHOD result;
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
