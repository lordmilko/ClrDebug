using System;

namespace ManagedCorDebug
{
    public struct GetActiveInternalFramesResult
    {
        public uint PcInternalFrames { get; }

        public IntPtr PpInternalFrames { get; }

        public GetActiveInternalFramesResult(uint pcInternalFrames, IntPtr ppInternalFrames)
        {
            PcInternalFrames = pcInternalFrames;
            PpInternalFrames = ppInternalFrames;
        }
    }
}