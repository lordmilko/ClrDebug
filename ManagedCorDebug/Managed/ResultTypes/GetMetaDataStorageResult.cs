using System;

namespace ManagedCorDebug
{
    public struct GetMetaDataStorageResult
    {
        public IntPtr PpvMd { get; }

        public uint PcbMd { get; }

        public GetMetaDataStorageResult(IntPtr ppvMd, uint pcbMd)
        {
            PpvMd = ppvMd;
            PcbMd = pcbMd;
        }
    }
}