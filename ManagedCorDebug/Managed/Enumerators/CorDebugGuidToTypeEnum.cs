using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    public class CorDebugGuidToTypeEnum : IEnumerable<CorDebugGuidToTypeMapping>, IEnumerator<CorDebugGuidToTypeMapping>
    {
        private ICorDebugGuidToTypeEnum rawEnumerator;

        public CorDebugGuidToTypeEnum(ICorDebugGuidToTypeEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorDebugGuidToTypeMapping);
        }

        public CorDebugGuidToTypeEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugGuidToTypeEnum((ICorDebugGuidToTypeEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugGuidToTypeMapping> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugGuidToTypeMapping Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            uint fetched;
            CorDebugGuidToTypeMapping result;
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