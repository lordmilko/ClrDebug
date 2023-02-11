using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetModuleInfo2"/> method.
    /// </summary>
    [DebuggerDisplay("ppBaseLoadAddress = {ppBaseLoadAddress.ToString(),nq}, szName = {szName}, pAssemblyId = {pAssemblyId.ToString(),nq}, pdwModuleFlags = {pdwModuleFlags.ToString(),nq}")]
    public struct GetModuleInfo2Result
    {
        /// <summary>
        /// The base address at which the module is loaded.
        /// </summary>
        public IntPtr ppBaseLoadAddress { get; }

        /// <summary>
        /// A caller-provided wide character buffer. When the method returns, this buffer contains the file name of the module.
        /// </summary>
        public string szName { get; }

        /// <summary>
        /// A pointer to the ID of the module's parent assembly.
        /// </summary>
        public AssemblyID pAssemblyId { get; }

        /// <summary>
        /// A bitmask of values from the COR_PRF_MODULE_FLAGS enumeration that specify the properties of the module.
        /// </summary>
        public COR_PRF_MODULE_FLAGS pdwModuleFlags { get; }

        public GetModuleInfo2Result(IntPtr ppBaseLoadAddress, string szName, AssemblyID pAssemblyId, COR_PRF_MODULE_FLAGS pdwModuleFlags)
        {
            this.ppBaseLoadAddress = ppBaseLoadAddress;
            this.szName = szName;
            this.pAssemblyId = pAssemblyId;
            this.pdwModuleFlags = pdwModuleFlags;
        }
    }
}
