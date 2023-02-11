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
        private ICorProfilerThreadEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorProfilerThreadEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public CorProfilerThreadEnum(ICorProfilerThreadEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(ThreadID);
        }

        public CorProfilerThreadEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorProfilerThreadEnum clone;
            rawEnumerator.Clone(out clone);

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
            if (rawEnumerator == null)
                return false;

            int fetched;
            ThreadID result;
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
