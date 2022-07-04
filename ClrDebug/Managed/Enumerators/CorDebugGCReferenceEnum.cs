using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Provides an enumerator for objects that will be garbage-collected.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugGCReferenceEnum"/> interface implements the "ICorDebugEnum" interface. An <see cref="ICorDebugGCReferenceEnum"/> instance
    /// is populated with <see cref="COR_GC_REFERENCE"/> instances by calling the <see cref="CorDebugProcess.EnumerateGCReferences"/>
    /// method. <see cref="COR_GC_REFERENCE"/> objects can be enumerated by calling the <see cref="MoveNext"/> method. The
    /// <see cref="COR_GC_REFERENCE"/> objects in the collection populated by this method represent three kinds of objects:
    /// </remarks>
    public class CorDebugGCReferenceEnum : IEnumerable<COR_GC_REFERENCE>, IEnumerator<COR_GC_REFERENCE>
    {
        private ICorDebugGCReferenceEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugGCReferenceEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public CorDebugGCReferenceEnum(ICorDebugGCReferenceEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(COR_GC_REFERENCE);
        }

        public CorDebugGCReferenceEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorDebugEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorDebugGCReferenceEnum((ICorDebugGCReferenceEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<COR_GC_REFERENCE> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public COR_GC_REFERENCE Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            int fetched;
            COR_GC_REFERENCE result;
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
