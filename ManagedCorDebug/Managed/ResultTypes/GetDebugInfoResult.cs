using System;

namespace ManagedCorDebug
{
    public struct GetDebugInfoResult
    {
        public IntPtr PIDD { get; }

        public int PcData { get; }

        public byte[] Data { get; }

        public GetDebugInfoResult(IntPtr pIDD, int pcData, byte[] data)
        {
            PIDD = pIDD;
            PcData = pcData;
            Data = data;
        }
    }
}