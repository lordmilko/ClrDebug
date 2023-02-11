using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetFunctionLeave3Info"/> method.
    /// </summary>
    [DebuggerDisplay("pFrameInfo = {pFrameInfo.ToString(),nq}, pRetvalRange = {pRetvalRange.ToString(),nq}")]
    public struct GetFunctionLeave3InfoResult
    {
        /// <summary>
        /// An opaque handle that represents generics information about a given stack frame. This handle is valid only during the FunctionLeave3WithInfo callback in which the profiler called the GetFunctionLeave3Info method.
        /// </summary>
        public COR_PRF_FRAME_INFO pFrameInfo { get; }

        /// <summary>
        /// A pointer to a <see cref="COR_PRF_FUNCTION_ARGUMENT_RANGE"/> structure that contains the value that is returned from the function.<para/>
        /// To access return value information, the COR_PRF_ENABLE_FUNCTION_RETVAL flag must be set. The profiler can use the EventMask to set the event flags.
        /// </summary>
        public COR_PRF_FUNCTION_ARGUMENT_RANGE pRetvalRange { get; }

        public GetFunctionLeave3InfoResult(COR_PRF_FRAME_INFO pFrameInfo, COR_PRF_FUNCTION_ARGUMENT_RANGE pRetvalRange)
        {
            this.pFrameInfo = pFrameInfo;
            this.pRetvalRange = pRetvalRange;
        }
    }
}
