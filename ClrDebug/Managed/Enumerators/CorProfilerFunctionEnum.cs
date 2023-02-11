using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods to sequentially iterate through a collection of functions in the common language runtime.
    /// </summary>
    /// <remarks>
    /// The ICorProfilerFunctionEnum interface is an enumerator. It allows the receiver of an array to pull elements from
    /// the sender at a rate that is appropriate for the receiver. In other words, the receiver is able to explicitly control
    /// the flow of array elements, thereby avoiding the problems associated with passing large arrays as method parameters.
    /// ICorProfilerFunctionEnum enumerates over functions that have already been JIT-compiled, but does not include functions
    /// that are loaded from native images generated with Ngen.exe.
    /// </remarks>
    public class CorProfilerFunctionEnum : IEnumerable<COR_PRF_FUNCTION>, IEnumerator<COR_PRF_FUNCTION>
    {
        private ICorProfilerFunctionEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorProfilerFunctionEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public CorProfilerFunctionEnum(ICorProfilerFunctionEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(COR_PRF_FUNCTION);
        }

        public CorProfilerFunctionEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorProfilerFunctionEnum clone;
            rawEnumerator.Clone(out clone);

            return new CorProfilerFunctionEnum(clone);
        }

        #region IEnumerable

        public IEnumerator<COR_PRF_FUNCTION> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public COR_PRF_FUNCTION Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (rawEnumerator == null)
                return false;

            int fetched;
            COR_PRF_FUNCTION result;
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
