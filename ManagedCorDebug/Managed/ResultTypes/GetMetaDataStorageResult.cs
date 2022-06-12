using System;

namespace ManagedCorDebug
{
    public struct GetMetaDataStorageResult
    {
        public IntPtr PpvMd { get; }

        public int PcbMd { get; }

        public GetMetaDataStorageResult(IntPtr ppvMd, int pcbMd)
        {
            PpvMd = ppvMd;
            PcbMd = pcbMd;
        }
    }
}