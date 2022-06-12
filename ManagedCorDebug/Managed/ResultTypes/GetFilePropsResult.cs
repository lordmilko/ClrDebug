using System;

namespace ManagedCorDebug
{
    public struct GetFilePropsResult
    {
        public string SzName { get; }

        public IntPtr PpbHashValue { get; }

        public int PcbHashValue { get; }

        public CorFileFlags PdwFileFlags { get; }

        public GetFilePropsResult(string szName, IntPtr ppbHashValue, int pcbHashValue, CorFileFlags pdwFileFlags)
        {
            SzName = szName;
            PpbHashValue = ppbHashValue;
            PcbHashValue = pcbHashValue;
            PdwFileFlags = pdwFileFlags;
        }
    }
}