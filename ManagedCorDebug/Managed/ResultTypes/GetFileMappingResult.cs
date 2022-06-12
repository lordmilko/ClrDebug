using System;

namespace ManagedCorDebug
{
    public struct GetFileMappingResult
    {
        public IntPtr PpvData { get; }

        public long PcbData { get; }

        public CorFileMapping PdwMappingType { get; }

        public GetFileMappingResult(IntPtr ppvData, long pcbData, CorFileMapping pdwMappingType)
        {
            PpvData = ppvData;
            PcbData = pcbData;
            PdwMappingType = pdwMappingType;
        }
    }
}