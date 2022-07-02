using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Provides an enumerator for the memory regions of the managed heap. This interface is a subclass of the <see cref="ICorDebugEnum"/> interface.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugHeapSegmentEnum"/> interface implements the <see cref="ICorDebugEnum"/> interface. An <see cref="ICorDebugHeapSegmentEnum"/> instance
    /// is populated with <see cref="COR_SEGMENT"/> instances by calling the <see cref="CorDebugProcess.EnumerateHeapRegions"/>
    /// method. The <see cref="COR_SEGMENT"/> objects in the collection can be enumerated by calling the <see cref="MoveNext"/>
    /// method. An <see cref="ICorDebugHeapSegmentEnum"/> collection object enumerates all memory regions that may contain managed objects,
    /// but it does not guarantee that managed objects actually reside in those regions. It may include information about
    /// empty or reserved memory regions.
    /// </remarks>
    public class CorDebugHeapSegmentEnum : IEnumerable<COR_SEGMENT>, IEnumerator<COR_SEGMENT>
    {
        private ICorDebugHeapSegmentEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugHeapSegmentEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public CorDebugHeapSegmentEnum(ICorDebugHeapSegmentEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(COR_SEGMENT);
        }

        public CorDebugHeapSegmentEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugHeapSegmentEnum((ICorDebugHeapSegmentEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<COR_SEGMENT> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public COR_SEGMENT Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            int fetched;
            COR_SEGMENT result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

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