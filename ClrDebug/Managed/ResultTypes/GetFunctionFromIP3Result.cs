using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetFunctionFromIP3"/> method.
    /// </summary>
    [DebuggerDisplay("functionId = {functionId.ToString(),nq}, pReJitId = {pReJitId.ToString(),nq}")]
    public struct GetFunctionFromIP3Result
    {
        /// <summary>
        /// The function ID.
        /// </summary>
        public FunctionID functionId { get; }

        /// <summary>
        /// The identity of the JIT-recompiled version of the function.
        /// </summary>
        public ReJITID pReJitId { get; }

        public GetFunctionFromIP3Result(FunctionID functionId, ReJITID pReJitId)
        {
            this.functionId = functionId;
            this.pReJitId = pReJitId;
        }
    }
}
