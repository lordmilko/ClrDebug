using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetFunctionEnter3Info"/> method.
    /// </summary>
    [DebuggerDisplay("pFrameInfo = {pFrameInfo.ToString(),nq}, pArgumentInfo = {pArgumentInfo.ToString(),nq}")]
    public struct GetFunctionEnter3InfoResult
    {
        /// <summary>
        /// An opaque handle that represents generics information about a given stack frame. This handle is valid only during the FunctionEnter3WithInfo callback in which the profiler called the GetFunctionEnter3Info method.
        /// </summary>
        public COR_PRF_FRAME_INFO pFrameInfo { get; }

        /// <summary>
        /// A pointer to a <see cref="COR_PRF_FUNCTION_ARGUMENT_INFO"/> structure that describes the locations of the function's arguments in memory, in left-to-right order.
        /// </summary>
        public COR_PRF_FUNCTION_ARGUMENT_INFO pArgumentInfo { get; }

        public GetFunctionEnter3InfoResult(COR_PRF_FRAME_INFO pFrameInfo, COR_PRF_FUNCTION_ARGUMENT_INFO pArgumentInfo)
        {
            this.pFrameInfo = pFrameInfo;
            this.pArgumentInfo = pArgumentInfo;
        }
    }
}
