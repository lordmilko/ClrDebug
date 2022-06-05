using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains the offset information for a range of code.<para/>
    /// This structure is used by the <see cref="ICorDebugStepper.StepRange"/> method.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct COR_DEBUG_STEP_RANGE
    {
        /// <summary>
        /// The offset of the beginning of the range.
        /// </summary>
        public uint startOffset;

        /// <summary>
        /// The offset of the end of the range.
        /// </summary>
        public uint endOffset;
    }
}