using System;

namespace ManagedCorDebug
{
    public struct StrongNameGetBlobResult
    {
        public IntPtr PbBlob { get; }

        public uint PcbBlob { get; }

        public StrongNameGetBlobResult(IntPtr pbBlob, uint pcbBlob)
        {
            PbBlob = pbBlob;
            PcbBlob = pcbBlob;
        }
    }
}