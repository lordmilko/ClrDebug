using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetAssemblyInfo"/> method.
    /// </summary>
    [DebuggerDisplay("szName = {szName}, pAppDomainId = {pAppDomainId.ToString(),nq}, pModuleId = {pModuleId.ToString(),nq}")]
    public struct GetAssemblyInfoResult
    {
        /// <summary>
        /// A caller-provided wide character buffer. When the function returns, it will contain the assembly's name.
        /// </summary>
        public string szName { get; }

        /// <summary>
        /// A pointer to the ID of the application domain that contains the assembly.
        /// </summary>
        public AppDomainID pAppDomainId { get; }

        /// <summary>
        /// A pointer to the ID of the assembly's manifest module.
        /// </summary>
        public ModuleID pModuleId { get; }

        public GetAssemblyInfoResult(string szName, AppDomainID pAppDomainId, ModuleID pModuleId)
        {
            this.szName = szName;
            this.pAppDomainId = pAppDomainId;
            this.pModuleId = pModuleId;
        }
    }
}
