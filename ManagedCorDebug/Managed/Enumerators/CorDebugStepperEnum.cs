using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    public class CorDebugStepperEnum : IEnumerable<CorDebugStepper>, IEnumerator<CorDebugStepper>
    {
        private ICorDebugStepperEnum rawEnumerator;

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

            uint fetched;
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