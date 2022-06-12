using System;

namespace ManagedCorDebug
{
    public struct MetaDataImport_GetMethodPropsResult
    {
        public mdTypeDef PClass { get; }

        public string SzMethod { get; }

        public CorMethodAttr PdwAttr { get; }

        public IntPtr PpvSigBlob { get; }

        public int PcbSigBlob { get; }

        public int PulCodeRVA { get; }

        public int PdwImplFlags { get; }

        public MetaDataImport_GetMethodPropsResult(mdTypeDef pClass, string szMethod, CorMethodAttr pdwAttr, IntPtr ppvSigBlob, int pcbSigBlob, int pulCodeRVA, int pdwImplFlags)
        {
            PClass = pClass;
            SzMethod = szMethod;
            PdwAttr = pdwAttr;
            PpvSigBlob = ppvSigBlob;
            PcbSigBlob = pcbSigBlob;
            PulCodeRVA = pulCodeRVA;
            PdwImplFlags = pdwImplFlags;
        }
    }
}