using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.GetContextStackTraceEx"/> method.
    /// </summary>
    [DebuggerDisplay("Frames = {Frames}, FramesFilled = {FramesFilled}")]
    public struct GetContextStackTraceExResult
    {
        /// <summary>
        /// Receives the stack frames. The number of elements this array holds is FrameSize. If Frames is NULL, this information is not returned.
        /// </summary>
        public DEBUG_STACK_FRAME_EX[] Frames { get; }

        /// <summary>
        /// Receives the number of frames that were placed in the array Frames and contexts in FrameContexts.<para/>
        /// If FramesFilled is NULL, this information is not returned.
        /// </summary>
        public uint FramesFilled { get; }

        public GetContextStackTraceExResult(DEBUG_STACK_FRAME_EX[] frames, uint framesFilled)
        {
            Frames = frames;
            FramesFilled = framesFilled;
        }
    }
}
