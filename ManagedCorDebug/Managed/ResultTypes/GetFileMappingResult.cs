using System;

namespace ManagedCorDebug
{
    public struct GetFileMappingResult
    {
        public IntPtr PpvData { get; }

        public ulong PcbData { get; }

        public CorFileMapping PdwMappingType { get; }

        public GetFileMappingResult(IntPtr ppvData, ulong pcbData, CorFileMapping pdwMappingType)
        {
            PpvData = ppvData;
            PcbData = pcbData;
            PdwMappingType = pdwMappingType;
        }
    }
}