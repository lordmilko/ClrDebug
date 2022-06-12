using System;

namespace ManagedCorDebug
{
    public struct GetAssemblyPropsResult
    {
        public IntPtr PpbPublicKey { get; }

        public int PcbPublicKey { get; }

        public int PulHashAlgId { get; }

        public string SzName { get; }

        public ASSEMBLYMETADATA PMetaData { get; }

        public CorAssemblyFlags PdwAssemblyFlags { get; }

        public GetAssemblyPropsResult(IntPtr ppbPublicKey, int pcbPublicKey, int pulHashAlgId, string szName, ASSEMBLYMETADATA pMetaData, CorAssemblyFlags pdwAssemblyFlags)
        {
            PpbPublicKey = ppbPublicKey;
            PcbPublicKey = pcbPublicKey;
            PulHashAlgId = pulHashAlgId;
            SzName = szName;
            PMetaData = pMetaData;
            PdwAssemblyFlags = pdwAssemblyFlags;
        }
    }
}