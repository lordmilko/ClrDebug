using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    public class CorProfilerMethodEnum : IEnumerable<COR_PRF_METHOD>, IEnumerator<COR_PRF_METHOD>
    {
        private ICorProfilerMethodEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorProfilerMethodEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public CorProfilerMethodEnum(ICorProfilerMethodEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(COR_PRF_METHOD);
        }

        public CorProfilerMethodEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorProfilerMethodEnum clone;
            rawEnumerator.Clone(out clone);

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
            if (rawEnumerator == null)
                return false;

            int fetched;
            COR_PRF_METHOD result;
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
