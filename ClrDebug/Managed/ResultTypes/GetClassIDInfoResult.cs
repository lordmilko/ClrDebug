using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetClassIDInfo"/> method.
    /// </summary>
    [DebuggerDisplay("pModuleId = {pModuleId.ToString(),nq}, pTypeDefToken = {pTypeDefToken.ToString(),nq}")]
    public struct GetClassIDInfoResult
    {
        /// <summary>
        /// A pointer to the ID of the parent module of the class.
        /// </summary>
        public ModuleID pModuleId { get; }

        /// <summary>
        /// A pointer to the metadata token for the class.
        /// </summary>
        public mdTypeDef pTypeDefToken { get; }

        public GetClassIDInfoResult(ModuleID pModuleId, mdTypeDef pTypeDefToken)
        {
            this.pModuleId = pModuleId;
            this.pTypeDefToken = pTypeDefToken;
        }
    }
}
