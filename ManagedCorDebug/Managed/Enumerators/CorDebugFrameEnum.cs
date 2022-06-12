using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods, and enumerates <see cref="ICorDebugFrame"/> arrays.
    /// </summary>
    public class CorDebugFrameEnum : IEnumerable<CorDebugFrame>, IEnumerator<CorDebugFrame>
    {
        private ICorDebugFrameEnum rawEnumerator;

        public CorDebugFrameEnum(ICorDebugFrameEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorDebugFrame);
        }

        public CorDebugFrameEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugFrameEnum((ICorDebugFrameEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugFrame> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugFrame Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            int fetched;
            ICorDebugFrame result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = CorDebugFrame.New(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}