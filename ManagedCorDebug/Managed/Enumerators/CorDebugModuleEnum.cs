using System.Collections;
using System.Collections.Generic;

namespace ManagedCorDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods, and enumerates <see cref="ICorDebugModule"/> arrays.
    /// </summary>
    public class CorDebugModuleEnum : IEnumerable<CorDebugModule>, IEnumerator<CorDebugModule>
    {
        private ICorDebugModuleEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugModuleEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public CorDebugModuleEnum(ICorDebugModuleEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(CorDebugModule);
        }

        public CorDebugModuleEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

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
            if (rawEnumerator == null)
                return false;

            int fetched;
            ICorDebugModule result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = new CorDebugModule(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}