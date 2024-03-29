﻿namespace ClrDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions] Enables the profiler to inform the common language runtime (CLR) of assembly references that the profiler will add in the <see cref="ICorProfilerCallback.ModuleLoadFinished"/> callback.
    /// </summary>
    /// <remarks>
    /// The CLR passes the profiler an ICorProfilerAssemblyReferenceProvider interface object in the <see cref="ICorProfilerCallback6.GetAssemblyReferences"/>
    /// callback. This enables the profiler to inform the CLR of assembly references that the profiler plans to add later
    /// in the <see cref="ICorProfilerCallback.ModuleLoadFinished"/>. callback. This improves the accuracy of the CLR's
    /// assembly reference closure walker and its algorithms for determining whether assemblies may be shared. This interface
    /// can be used only in the <see cref="ICorProfilerCallback6.GetAssemblyReferences"/> callback that passes this interface
    /// object to the profiler.
    /// </remarks>
    public class CorProfilerAssemblyReferenceProvider : ComObject<ICorProfilerAssemblyReferenceProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorProfilerAssemblyReferenceProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorProfilerAssemblyReferenceProvider(ICorProfilerAssemblyReferenceProvider raw) : base(raw)
        {
        }

        #region ICorProfilerAssemblyReferenceProvider
        #region AddAssemblyReference

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Informs the common language runtime (CLR) of an assembly reference that the profiler plans to add in the <see cref="ICorProfilerCallback.ModuleLoadFinished"/> callback.
        /// </summary>
        /// <param name="pAssemblyRefInfo">A pointer to a <see cref="COR_PRF_ASSEMBLY_REFERENCE_INFO"/> structure that provides the CLR with information about an assembly reference that it should consider when performing an assembly reference closure walk.</param>
        /// <remarks>
        /// The profiler calls this method for each target assembly it plans to reference from the assembly specified in the
        /// wszAssemblyPath argument of the <see cref="ICorProfilerCallback6.GetAssemblyReferences"/> callback. The <see cref="ICorProfilerAssemblyReferenceProvider"/>
        /// interface object is passed to the profiler's <see cref="ICorProfilerCallback6.GetAssemblyReferences"/> callback,
        /// along with the assembly path and name in the wszAssemblyPath argument.
        /// </remarks>
        public void AddAssemblyReference(COR_PRF_ASSEMBLY_REFERENCE_INFO pAssemblyRefInfo)
        {
            TryAddAssemblyReference(pAssemblyRefInfo).ThrowOnNotOK();
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Informs the common language runtime (CLR) of an assembly reference that the profiler plans to add in the <see cref="ICorProfilerCallback.ModuleLoadFinished"/> callback.
        /// </summary>
        /// <param name="pAssemblyRefInfo">A pointer to a <see cref="COR_PRF_ASSEMBLY_REFERENCE_INFO"/> structure that provides the CLR with information about an assembly reference that it should consider when performing an assembly reference closure walk.</param>
        /// <remarks>
        /// The profiler calls this method for each target assembly it plans to reference from the assembly specified in the
        /// wszAssemblyPath argument of the <see cref="ICorProfilerCallback6.GetAssemblyReferences"/> callback. The <see cref="ICorProfilerAssemblyReferenceProvider"/>
        /// interface object is passed to the profiler's <see cref="ICorProfilerCallback6.GetAssemblyReferences"/> callback,
        /// along with the assembly path and name in the wszAssemblyPath argument.
        /// </remarks>
        public HRESULT TryAddAssemblyReference(COR_PRF_ASSEMBLY_REFERENCE_INFO pAssemblyRefInfo)
        {
            /*HRESULT AddAssemblyReference(
            [In] ref COR_PRF_ASSEMBLY_REFERENCE_INFO pAssemblyRefInfo);*/
            return Raw.AddAssemblyReference(ref pAssemblyRefInfo);
        }

        #endregion
        #endregion
    }
}
