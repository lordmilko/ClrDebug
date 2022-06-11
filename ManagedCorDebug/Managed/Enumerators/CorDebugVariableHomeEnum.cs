using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    public class CorDebugVariableHomeEnum : IEnumerable<CorDebugVariableHome>, IEnumerator<CorDebugVariableHome>
    {
        private ICorDebugVariableHomeEnum rawEnumerator;

        public CorDebugVariableHomeEnum(ICorDebugVariableHomeEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorDebugVariableHome);
        }

        public CorDebugVariableHomeEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugVariableHomeEnum((ICorDebugVariableHomeEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugVariableHome> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugVariableHome Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            uint fetched;
            ICorDebugVariableHome result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = new CorDebugVariableHome(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}