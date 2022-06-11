using System;

namespace ManagedCorDebug
{
    public struct MetaDataImport_GetMethodPropsResult
    {
        public mdTypeDef PClass { get; }

        public string SzMethod { get; }

        public CorMethodAttr PdwAttr { get; }

        public IntPtr PpvSigBlob { get; }

        public uint PcbSigBlob { get; }

        public uint PulCodeRVA { get; }

        public uint PdwImplFlags { get; }

        public MetaDataImport_GetMethodPropsResult(mdTypeDef pClass, string szMethod, CorMethodAttr pdwAttr, IntPtr ppvSigBlob, uint pcbSigBlob, uint pulCodeRVA, uint pdwImplFlags)
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