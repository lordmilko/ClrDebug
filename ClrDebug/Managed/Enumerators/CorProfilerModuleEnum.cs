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
        private ICorProfilerModuleEnum rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorProfilerModuleEnum"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public CorProfilerModuleEnum(ICorProfilerModuleEnum rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(ModuleID);
        }

        public CorProfilerModuleEnum Clone()
        {
            if (rawEnumerator == null)
                return this;

            ICorProfilerModuleEnum clone;
            rawEnumerator.Clone(out clone);

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
            if (rawEnumerator == null)
                return false;

            int fetched;
            ModuleID result;
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
