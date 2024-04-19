using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods to sequentially iterate through a collection of threads in the common language runtime.
    /// </summary>
    /// <remarks>
    /// The ICorProfilerThreadEnum interface is an enumerator. It allows the receiver of an array to pull elements from
    /// the sender at a rate that is appropriate for the receiver. In other words, the receiver is able to explicitly control
    /// the flow of array elements, thereby avoiding the problems associated with passing large arrays as method parameters.
    /// </remarks>
    public class CorProfilerThreadEnum : IEnumerable<ThreadID>, IEnumerator<ThreadID>
    {
        public ICorProfilerThreadEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorProfilerThreadEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorProfilerThreadEnum(ICorProfilerThreadEnum raw)
        {
            Raw = raw;
        }

        #region Count

        /// <summary>
        /// Gets the number of threads that are used by the application.
        /// </summary>
        public int Count
        {
            get
            {
                int pcelt;
                TryGetCount(out pcelt).ThrowOnNotOK();

                return pcelt;
            }
        }

        /// <summary>
        /// Gets the number of threads that are used by the application.
        /// </summary>
        /// <param name="pcelt">[out] The number of threads used by the application.</param>
        public HRESULT TryGetCount(out int pcelt)
        {
            /*HRESULT GetCount(
            [Out] out int pcelt);*/
            return Raw.GetCount(out pcelt);
        }

        #endregion

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(ThreadID);
        }

        public CorProfilerThreadEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorProfilerThreadEnum clone;
            Raw.Clone(out clone);

            return new CorProfilerThreadEnum(clone);
        }

        #region IEnumerable

        public IEnumerator<ThreadID> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public ThreadID Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            ThreadID result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result;
            else
                Current = default(ThreadID);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
