using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    public class CorDebugObjectEnum : IEnumerable<CORDB_ADDRESS>, IEnumerator<CORDB_ADDRESS>
    {
        private ICorDebugObjectEnum rawEnumerator;

        public CorDebugObjectEnum(ICorDebugObjectEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CORDB_ADDRESS);
        }

        public CorDebugObjectEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugObjectEnum((ICorDebugObjectEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CORDB_ADDRESS> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CORDB_ADDRESS Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            uint fetched;
            CORDB_ADDRESS result;
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