using System;

namespace ManagedCorDebug
{
    public struct GetDebugInfoWithPaddingResult
    {
        public IntPtr PIDD { get; }

        public int PcData { get; }

        public byte[] Data { get; }

        public GetDebugInfoWithPaddingResult(IntPtr pIDD, int pcData, byte[] data)
        {
            PIDD = pIDD;
            PcData = pcData;
            Data = data;
        }
    }
}