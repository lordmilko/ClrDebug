using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    public class CorDebugTypeEnum : IEnumerable<CorDebugType>, IEnumerator<CorDebugType>
    {
        private ICorDebugTypeEnum rawEnumerator;

        public CorDebugTypeEnum(ICorDebugTypeEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorDebugType);
        }

        public CorDebugTypeEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugTypeEnum((ICorDebugTypeEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugType> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugType Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            uint fetched;
            ICorDebugType result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = new CorDebugType(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}