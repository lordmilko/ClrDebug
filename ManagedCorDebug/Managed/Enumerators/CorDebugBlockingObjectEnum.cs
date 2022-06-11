using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    public class CorDebugBlockingObjectEnum : IEnumerable<CorDebugBlockingObject>, IEnumerator<CorDebugBlockingObject>
    {
        private ICorDebugBlockingObjectEnum rawEnumerator;

        public CorDebugBlockingObjectEnum(ICorDebugBlockingObjectEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorDebugBlockingObject);
        }

        public CorDebugBlockingObjectEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugBlockingObjectEnum((ICorDebugBlockingObjectEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugBlockingObject> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugBlockingObject Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            uint fetched;
            CorDebugBlockingObject result;
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