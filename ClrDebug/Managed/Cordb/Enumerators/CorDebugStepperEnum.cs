using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods, and enumerates <see cref="ICorDebugStepper"/> arrays.
    /// </summary>
    public class CorDebugStepperEnum : IEnumerable<CorDebugStepper>, IEnumerator<CorDebugStepper>
    {
        public ICorDebugStepperEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugStepperEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugStepperEnum(ICorDebugStepperEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugStepper);
        }

        public CorDebugStepperEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugStepperEnum((ICorDebugStepperEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugStepper> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugStepper Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            ICorDebugStepper result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new CorDebugStepper(result);
            else
                Current = default(CorDebugStepper);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
