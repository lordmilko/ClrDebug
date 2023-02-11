using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetModuleInfo"/> method.
    /// </summary>
    [DebuggerDisplay("ppBaseLoadAddress = {ppBaseLoadAddress.ToString(),nq}, szName = {szName}, pAssemblyId = {pAssemblyId.ToString(),nq}")]
    public struct GetModuleInfoResult
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

        public GetModuleInfoResult(IntPtr ppBaseLoadAddress, string szName, AssemblyID pAssemblyId)
        {
            this.ppBaseLoadAddress = ppBaseLoadAddress;
            this.szName = szName;
            this.pAssemblyId = pAssemblyId;
        }
    }
}
