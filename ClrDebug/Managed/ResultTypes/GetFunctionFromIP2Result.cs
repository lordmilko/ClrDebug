using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetFunctionFromIP2"/> method.
    /// </summary>
    [DebuggerDisplay("pFunctionId = {pFunctionId.ToString(),nq}, pReJitId = {pReJitId.ToString(),nq}")]
    public struct GetFunctionFromIP2Result
    {
        /// <summary>
        /// The function ID.
        /// </summary>
        public FunctionID pFunctionId { get; }

        /// <summary>
        /// The identity of the JIT-recompiled version of the function.
        /// </summary>
        public ReJITID pReJitId { get; }

        public GetFunctionFromIP2Result(FunctionID pFunctionId, ReJITID pReJitId)
        {
            this.pFunctionId = pFunctionId;
            this.pReJitId = pReJitId;
        }
    }
}
