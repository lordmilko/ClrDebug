using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods, and enumerates <see cref="ICorDebugStepper"/> arrays.
    /// </summary>
    public class CorDebugStepperEnum : IEnumerable<CorDebugStepper>, IEnumerator<CorDebugStepper>
    {
        private ICorDebugStepperEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugStepperEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public CorDebugStepperEnum(ICorDebugStepperEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorDebugStepper);
        }

        public CorDebugStepperEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

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
            if (rawEnumerator == null)
                return false;

            int fetched;
            ICorDebugStepper result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = new CorDebugStepper(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
