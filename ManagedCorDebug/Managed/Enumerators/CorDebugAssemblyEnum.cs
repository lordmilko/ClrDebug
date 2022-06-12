using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods and enumerates <see cref="ICorDebugAssembly"/> arrays.
    /// </summary>
    public class CorDebugAssemblyEnum : IEnumerable<CorDebugAssembly>, IEnumerator<CorDebugAssembly>
    {
        private ICorDebugAssemblyEnum rawEnumerator;

        public CorDebugAssemblyEnum(ICorDebugAssemblyEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorDebugAssembly);
        }

        public CorDebugAssemblyEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugAssemblyEnum((ICorDebugAssemblyEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugAssembly> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugAssembly Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            int fetched;
            ICorDebugAssembly result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = new CorDebugAssembly(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}