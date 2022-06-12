using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugThread.GetActiveInternalFrames"/> method.
    /// </summary>
    public struct GetActiveInternalFramesResult
    {
        /// <summary>
        /// [out] A pointer to a ULONG32 that contains the number of internal frames on the stack.
        /// </summary>
        public int pcInternalFrames { get; }

        /// <summary>
        /// [in, out] A pointer to the address of an array of internal frames on the stack.
        /// </summary>
        public IntPtr ppInternalFrames { get; }

        public GetActiveInternalFramesResult(int pcInternalFrames, IntPtr ppInternalFrames)
        {
            this.pcInternalFrames = pcInternalFrames;
            this.ppInternalFrames = ppInternalFrames;
        }
    }
}