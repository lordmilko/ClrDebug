using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetReJITIDs"/> method.
    /// </summary>
    [DebuggerDisplay("pcReJitIds = {pcReJitIds}, reJitIds = {reJitIds.ToString(),nq}")]
    public struct GetReJITIDsResult
    {
        /// <summary>
        /// The actual number of JIT-recompiled IDs.
        /// </summary>
        public int pcReJitIds { get; }

        /// <summary>
        /// A caller-allocated array that will contain the JIT-recompiled IDs for the specified function.
        /// </summary>
        public ReJITID reJitIds { get; }

        public GetReJITIDsResult(int pcReJitIds, ReJITID reJitIds)
        {
            this.pcReJitIds = pcReJitIds;
            this.reJitIds = reJitIds;
        }
    }
}
