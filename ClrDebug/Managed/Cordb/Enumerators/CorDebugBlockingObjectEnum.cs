using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Provides an enumerator for a list of <see cref="CorDebugBlockingObject"/> structures. This interface is a subclass of the <see cref="ICorDebugEnum"/> interface.
    /// </summary>
    /// <remarks>
    /// Each <see cref="CorDebugBlockingObject"/> structure represents an object that is blocking a thread.
    /// </remarks>
    public class CorDebugBlockingObjectEnum : IEnumerable<CorDebugBlockingObject>, IEnumerator<CorDebugBlockingObject>
    {
        public ICorDebugBlockingObjectEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugBlockingObjectEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugBlockingObjectEnum(ICorDebugBlockingObjectEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugBlockingObject);
        }

        public CorDebugBlockingObjectEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugBlockingObjectEnum((ICorDebugBlockingObjectEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugBlockingObject> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugBlockingObject Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            CorDebugBlockingObject result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result;
            else
                Current = default(CorDebugBlockingObject);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
