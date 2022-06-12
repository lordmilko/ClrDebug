using System;

namespace ManagedCorDebug
{
    public struct StrongNameGetBlobResult
    {
        public IntPtr PbBlob { get; }

        public int PcbBlob { get; }

        public StrongNameGetBlobResult(IntPtr pbBlob, int pcbBlob)
        {
            PbBlob = pbBlob;
            PcbBlob = pcbBlob;
        }
    }
}