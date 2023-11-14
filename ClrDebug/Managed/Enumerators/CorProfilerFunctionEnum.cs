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
        public ICorProfilerFunctionEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorProfilerFunctionEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorProfilerFunctionEnum(ICorProfilerFunctionEnum raw)
        {
            Raw = raw;
        }

        #region Count

        /// <summary>
        /// Gets the number of functions that were loaded by the application or forcibly loaded by the profiler.
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
        /// Gets the number of functions that were loaded by the application or forcibly loaded by the profiler.
        /// </summary>
        /// <param name="pcelt">[out] The number of functions that were loaded.</param>
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
            Current = default(COR_PRF_FUNCTION);
        }

        public CorProfilerFunctionEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorProfilerFunctionEnum clone;
            Raw.Clone(out clone);

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
            if (Raw == null)
                return false;

            int fetched;
            COR_PRF_FUNCTION result;
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
