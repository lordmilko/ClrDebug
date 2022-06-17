using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains the offset information for a range of code. This structure is used by the <see cref="ICorDebugStepper.StepRange"/> method.
    /// </summary>
    [DebuggerDisplay("startOffset = {startOffset}, endOffset = {endOffset}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct COR_DEBUG_STEP_RANGE
    {
        /// <summary>
        /// The offset of the beginning of the range.
        /// </summary>
        public int startOffset;

        /// <summary>
        /// The offset of the end of the range.
        /// </summary>
        public int endOffset;
    }
}
