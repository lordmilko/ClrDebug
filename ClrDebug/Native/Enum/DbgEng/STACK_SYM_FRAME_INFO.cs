namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines stack source information for an extended stack frame.
    /// </summary>
    public struct STACK_SYM_FRAME_INFO
    {
        /// <summary>
        /// A stack frame as a <see cref="DEBUG_STACK_FRAME_EX"/> structure.
        /// </summary>
        public DEBUG_STACK_FRAME_EX StackFrameEx;

        /// <summary>
        /// Stack source information as a <see cref="STACK_SRC_INFO"/> structure.
        /// </summary>
        public STACK_SRC_INFO SrcInfo;
    }
}