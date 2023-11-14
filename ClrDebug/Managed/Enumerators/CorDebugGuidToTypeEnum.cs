using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Provides an enumerator that defines the mapping between a set of GUIDs and their corresponding types, which are represented by <see cref="ICorDebugType"/> instances.<para/>
    /// This interface inherits the methods from the <see cref="ICorDebugEnum"/> interface.
    /// </summary>
    /// <remarks>
    /// An <see cref="ICorDebugGuidToTypeEnum"/> interface object can be retrieved by calling the <see cref="CorDebugAppDomain.CachedWinRTTypes"/>
    /// property. A debugger can call this interface's <see cref="MoveNext"/> method to retrieve <see cref="CorDebugGuidToTypeMapping"/>
    /// objects that represent mappings of managed representations of Windows Runtime types loaded in the application domain
    /// used for the call to the <see cref="CorDebugAppDomain.CachedWinRTTypes"/> property.
    /// </remarks>
    public class CorDebugGuidToTypeEnum : IEnumerable<CorDebugGuidToTypeMapping>, IEnumerator<CorDebugGuidToTypeMapping>
    {
        public ICorDebugGuidToTypeEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugGuidToTypeEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugGuidToTypeEnum(ICorDebugGuidToTypeEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugGuidToTypeMapping);
        }

        public CorDebugGuidToTypeEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugGuidToTypeEnum((ICorDebugGuidToTypeEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugGuidToTypeMapping> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugGuidToTypeMapping Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            CorDebugGuidToTypeMapping result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result;

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
