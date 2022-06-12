using System;

namespace ManagedCorDebug
{
    public struct GetAssemblyRefPropsResult
    {
        public IntPtr PpbPublicKeyOrToken { get; }

        public int PcbPublicKeyOrToken { get; }

        public string SzName { get; }

        public ASSEMBLYMETADATA PMetaData { get; }

        public IntPtr PpbHashValue { get; }

        public int PcbHashValue { get; }

        public CorAssemblyFlags PdwAssemblyFlags { get; }

        public GetAssemblyRefPropsResult(IntPtr ppbPublicKeyOrToken, int pcbPublicKeyOrToken, string szName, ASSEMBLYMETADATA pMetaData, IntPtr ppbHashValue, int pcbHashValue, CorAssemblyFlags pdwAssemblyFlags)
        {
            PpbPublicKeyOrToken = ppbPublicKeyOrToken;
            PcbPublicKeyOrToken = pcbPublicKeyOrToken;
            SzName = szName;
            PMetaData = pMetaData;
            PpbHashValue = ppbHashValue;
            PcbHashValue = pcbHashValue;
            PdwAssemblyFlags = pdwAssemblyFlags;
        }
    }
}