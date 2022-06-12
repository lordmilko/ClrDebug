using System;

namespace ManagedCorDebug
{
    public struct GetMetaDataStreamInfoResult
    {
        public IntPtr Ppv { get; }

        public int Pcb { get; }

        public GetMetaDataStreamInfoResult(IntPtr ppv, int pcb)
        {
            Ppv = ppv;
            Pcb = pcb;
        }
    }
}