using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions] Provides the common language runtime with information about an assembly reference that it should consider when performing an assembly reference closure walk.
    /// </summary>
    /// <remarks>
    /// The COR_PRF_EX_CLAUSE_INFO structure is populated by the profiler when it declares additional assembly references
    /// that the common language runtime should consider when performing an assembly reference closure walk. If the profiler
    /// registers for the <see cref="ICorProfilerCallback6.GetAssemblyReferences"/> callback method, the runtime passes
    /// the path and name of the assembly to be loaded, along with a pointer to an <see cref="ICorProfilerAssemblyReferenceProvider"/>
    /// interface object to that method. The profiler can then call the <see cref="ICorProfilerAssemblyReferenceProvider.AddAssemblyReference"/>
    /// method with a COR_PRF_ASSEMBLY_REFERENCE_INFO object for each target assembly it plans to reference from the assembly
    /// specified in the <see cref="ICorProfilerCallback6.GetAssemblyReferences"/> callback.
    /// </remarks>
    [DebuggerDisplay("pbPublicKeyOrToken = {pbPublicKeyOrToken.ToString(),nq}, cbPublicKeyOrToken = {cbPublicKeyOrToken}, szName = {szName}, pMetaData = {pMetaData}, pbHashValue = {pbHashValue.ToString(),nq}, cbHashValue = {cbHashValue}, dwAssemblyRefFlags = {dwAssemblyRefFlags}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public unsafe partial struct COR_PRF_ASSEMBLY_REFERENCE_INFO
    {
        /// <summary>
        /// A pointer to the public key or token of the assembly.
        /// </summary>
        public IntPtr pbPublicKeyOrToken;

        /// <summary>
        /// The number of bytes in the public key or token.
        /// </summary>
        public int cbPublicKeyOrToken;

        /// <summary>
        /// The name of the assembly that is referenced.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string szName;

        /// <summary>
        /// A pointer to the assembly's metadata.
        /// </summary>
        public ASSEMBLYMETADATA* pMetaData;

        /// <summary>
        /// A pointer to a hash binary large object (BLOB).
        /// </summary>
        public IntPtr pbHashValue;

        /// <summary>
        /// The number of bytes in the hash BLOB.
        /// </summary>
        public int cbHashValue;

        /// <summary>
        /// The assembly's flags.
        /// </summary>
        public int dwAssemblyRefFlags;
    }
}
