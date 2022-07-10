using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.GetContextStackTrace"/> method.
    /// </summary>
    [DebuggerDisplay("Frames = {Frames}, FramesFilled = {FramesFilled}")]
    public struct GetContextStackTraceResult
    {
        /// <summary>
        /// Receives the stack frames. The number of elements this array holds is FrameSize. If Frames is NULL, this information is not returned.
        /// </summary>
        public DEBUG_STACK_FRAME[] Frames { get; }

        /// <summary>
        /// Receives the number of frames that were placed in the array Frames and contexts in FrameContexts.<para/>
        /// If FramesFilled is NULL, this information is not returned.
        /// </summary>
        public uint FramesFilled { get; }

        public GetContextStackTraceResult(DEBUG_STACK_FRAME[] frames, uint framesFilled)
        {
            Frames = frames;
            FramesFilled = framesFilled;
        }
    }
}
