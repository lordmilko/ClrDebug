using System;

namespace ManagedCorDebug
{
    public struct GetActiveInternalFramesResult
    {
        public int PcInternalFrames { get; }

        public IntPtr PpInternalFrames { get; }

        public GetActiveInternalFramesResult(int pcInternalFrames, IntPtr ppInternalFrames)
        {
            PcInternalFrames = pcInternalFrames;
            PpInternalFrames = ppInternalFrames;
        }
    }
}