using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods, and enumerates <see cref="ICorDebugModule"/> arrays.
    /// </summary>
    public class CorDebugModuleEnum : IEnumerable<CorDebugModule>, IEnumerator<CorDebugModule>
    {
        public ICorDebugModuleEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugModuleEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugModuleEnum(ICorDebugModuleEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugModule);
        }

        public CorDebugModuleEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugModuleEnum((ICorDebugModuleEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugModule> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugModule Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            ICorDebugModule result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new CorDebugModule(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
