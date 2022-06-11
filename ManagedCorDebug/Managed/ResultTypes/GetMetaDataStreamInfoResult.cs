using System;

namespace ManagedCorDebug
{
    public struct GetMetaDataStreamInfoResult
    {
        public IntPtr Ppv { get; }

        public uint Pcb { get; }

        public GetMetaDataStreamInfoResult(IntPtr ppv, uint pcb)
        {
            Ppv = ppv;
            Pcb = pcb;
        }
    }
}