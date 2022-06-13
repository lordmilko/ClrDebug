using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugThread.GetActiveInternalFrames"/> method.
    /// </summary>
    [DebuggerDisplay("pcInternalFrames = {pcInternalFrames}, ppInternalFrames = {ppInternalFrames}")]
    public struct GetActiveInternalFramesResult
    {
        /// <summary>
        /// A pointer to a ULONG32 that contains the number of internal frames on the stack.
        /// </summary>
        public int pcInternalFrames { get; }

        /// <summary>
        /// A pointer to the address of an array of internal frames on the stack.
        /// </summary>
        public IntPtr ppInternalFrames { get; }

        public GetActiveInternalFramesResult(int pcInternalFrames, IntPtr ppInternalFrames)
        {
            this.pcInternalFrames = pcInternalFrames;
            this.ppInternalFrames = ppInternalFrames;
        }
    }
}