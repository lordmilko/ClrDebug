using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetModuleInfo2"/> method.
    /// </summary>
    [DebuggerDisplay("pcchName = {pcchName}, szName = {szName}, pAssemblyId = {pAssemblyId.ToString(),nq}, pdwModuleFlags = {pdwModuleFlags.ToString(),nq}")]
    public struct GetModuleInfo2Result
    {
        /// <summary>
        /// A pointer to the total character length of the module's file name that is returned.
        /// </summary>
        public int pcchName { get; }

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

        public GetModuleInfo2Result(int pcchName, string szName, AssemblyID pAssemblyId, COR_PRF_MODULE_FLAGS pdwModuleFlags)
        {
            this.pcchName = pcchName;
            this.szName = szName;
            this.pAssemblyId = pAssemblyId;
            this.pdwModuleFlags = pdwModuleFlags;
        }
    }
}
