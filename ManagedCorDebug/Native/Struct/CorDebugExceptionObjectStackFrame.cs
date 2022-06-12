using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents stack frame information from an exception object.
    /// </summary>
    /// <remarks>
    /// The caller must release the pointer to the <see cref="ICorDebugModule"/> object once it is no longer in use.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct CorDebugExceptionObjectStackFrame
    {
        /// <summary>
        /// A pointer to the <see cref="ICorDebugModule"/> object for the current frame.
        /// </summary>
        [MarshalAs(UnmanagedType.Interface)] public ICorDebugModule pModule;

        /// <summary>
        /// The value of the instruction pointer (EIP/RIP) for the current frame.
        /// </summary>
        public long ip;

        /// <summary>
        /// The method token for the current frame.
        /// </summary>
        public int methodDef;

        /// <summary>
        /// A value that indicates whether the frame is the last frame in a foreign exception.
        /// </summary>
        public int isLastForeignExceptionFrame;
    }
}