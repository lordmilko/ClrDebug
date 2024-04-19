using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Provides an enumerator for objects on the managed heap. This interface is a subclass of the <see cref="ICorDebugEnum"/> interface.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugHeapEnum"/> interface implements the <see cref="ICorDebugEnum"/> interface. An <see cref="ICorDebugHeapEnum"/> instance is populated
    /// with <see cref="COR_HEAPOBJECT"/> instances by calling the <see cref="CorDebugProcess.EnumerateHeap"/> method.
    /// Each <see cref="COR_HEAPOBJECT"/> instance in the collection represents either a live object on the heap or an
    /// object that is not rooted by any object but has not yet been collected by the garbage collector. The <see cref="COR_HEAPOBJECT"/>
    /// objects in the collection can be enumerated by calling the <see cref="MoveNext"/> method.
    /// </remarks>
    public class CorDebugHeapEnum : IEnumerable<COR_HEAPOBJECT>, IEnumerator<COR_HEAPOBJECT>
    {
        public ICorDebugHeapEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugHeapEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugHeapEnum(ICorDebugHeapEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(COR_HEAPOBJECT);
        }

        public CorDebugHeapEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugHeapEnum((ICorDebugHeapEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<COR_HEAPOBJECT> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public COR_HEAPOBJECT Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            COR_HEAPOBJECT result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result;
            else
                Current = default(COR_HEAPOBJECT);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
