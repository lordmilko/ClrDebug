using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods to sequentially iterate through a collection of modules loaded by the application or the profiler.
    /// </summary>
    /// <remarks>
    /// The ICorProfilerModuleEnum interface is an enumerator. It allows the receiver of an array to pull elements from
    /// the sender at a rate that is appropriate for the receiver. In other words, the receiver is able to explicitly control
    /// the flow of array elements, thereby avoiding the problems associated with passing large arrays as method parameters.
    /// </remarks>
    public class CorProfilerModuleEnum : IEnumerable<ModuleID>, IEnumerator<ModuleID>
    {
        public ICorProfilerModuleEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorProfilerModuleEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorProfilerModuleEnum(ICorProfilerModuleEnum raw)
        {
            Raw = raw;
        }

        #region Count

        /// <summary>
        /// Gets the number of managed modules that were loaded into the application.
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
        /// Gets the number of managed modules that were loaded into the application.
        /// </summary>
        /// <param name="pcelt">[out] The number of runtime modules in the collection.</param>
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
            Current = default(ModuleID);
        }

        public CorProfilerModuleEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorProfilerModuleEnum clone;
            Raw.Clone(out clone);

            return new CorProfilerModuleEnum(clone);
        }

        #region IEnumerable

        public IEnumerator<ModuleID> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public ModuleID Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            ModuleID result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result;
            else
                Current = default(ModuleID);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
