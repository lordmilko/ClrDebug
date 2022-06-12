using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods and enumerates <see cref="ICorDebugProcess"/> arrays.
    /// </summary>
    public class CorDebugProcessEnum : IEnumerable<CorDebugProcess>, IEnumerator<CorDebugProcess>
    {
        private ICorDebugProcessEnum rawEnumerator;

        public CorDebugProcessEnum(ICorDebugProcessEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorDebugProcess);
        }

        public CorDebugProcessEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugProcessEnum((ICorDebugProcessEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugProcess> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugProcess Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            int fetched;
            ICorDebugProcess result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = new CorDebugProcess(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}