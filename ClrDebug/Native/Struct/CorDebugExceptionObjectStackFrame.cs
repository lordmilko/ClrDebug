using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Represents stack frame information from an exception object.
    /// </summary>
    /// <remarks>
    /// The caller must release the pointer to the <see cref="ICorDebugModule"/> object once it is no longer in use.
    /// </remarks>
    [DebuggerDisplay("pModule = {pModule.ToString(),nq}, ip = {ip}, methodDef = {methodDef}, isLastForeignExceptionFrame = {isLastForeignExceptionFrame}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct CorDebugExceptionObjectStackFrame
    {
        /// <summary>
        /// A pointer to the <see cref="ICorDebugModule"/> object for the current frame.
        /// </summary>
        [MarshalAs(UnmanagedType.Interface)]
        public ICorDebugModule pModule;

        /// <summary>
        /// The value of the instruction pointer (EIP/RIP) for the current frame.
        /// </summary>
        public long ip;

        /// <summary>
        /// The method token for the current frame.
        /// </summary>
        public mdMethodDef methodDef;

        /// <summary>
        /// A value that indicates whether the frame is the last frame in a foreign exception.
        /// </summary>
        public bool isLastForeignExceptionFrame;
    }
}
