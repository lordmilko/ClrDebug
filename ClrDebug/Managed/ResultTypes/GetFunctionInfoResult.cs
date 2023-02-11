using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetFunctionInfo"/> method.
    /// </summary>
    [DebuggerDisplay("pClassId = {pClassId.ToString(),nq}, pModuleId = {pModuleId.ToString(),nq}, pToken = {pToken.ToString(),nq}")]
    public struct GetFunctionInfoResult
    {
        /// <summary>
        /// A pointer to the parent class of the function.
        /// </summary>
        public ClassID pClassId { get; }

        /// <summary>
        /// A pointer to the module in which the function's parent class is defined.
        /// </summary>
        public ModuleID pModuleId { get; }

        /// <summary>
        /// A pointer to the metadata token for the function.
        /// </summary>
        public mdToken pToken { get; }

        public GetFunctionInfoResult(ClassID pClassId, ModuleID pModuleId, mdToken pToken)
        {
            this.pClassId = pClassId;
            this.pModuleId = pModuleId;
            this.pToken = pToken;
        }
    }
}
