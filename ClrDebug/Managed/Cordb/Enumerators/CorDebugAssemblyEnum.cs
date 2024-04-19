using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods and enumerates <see cref="ICorDebugAssembly"/> arrays.
    /// </summary>
    public class CorDebugAssemblyEnum : IEnumerable<CorDebugAssembly>, IEnumerator<CorDebugAssembly>
    {
        public ICorDebugAssemblyEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugAssemblyEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugAssemblyEnum(ICorDebugAssemblyEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugAssembly);
        }

        public CorDebugAssemblyEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

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
            if (Raw == null)
                return false;

            int fetched;
            ICorDebugAssembly result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new CorDebugAssembly(result);
            else
                Current = default(CorDebugAssembly);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
