using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetModuleInfo"/> method.
    /// </summary>
    [DebuggerDisplay("pcchName = {pcchName}, szName = {szName}, pAssemblyId = {pAssemblyId.ToString(),nq}")]
    public struct GetModuleInfoResult
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

        public GetModuleInfoResult(int pcchName, string szName, AssemblyID pAssemblyId)
        {
            this.pcchName = pcchName;
            this.szName = szName;
            this.pAssemblyId = pAssemblyId;
        }
    }
}
