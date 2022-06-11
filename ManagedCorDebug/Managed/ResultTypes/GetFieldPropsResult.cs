using System;
using System.Reflection;

namespace ManagedCorDebug
{
    public struct GetFieldPropsResult
    {
        public mdTypeDef PClass { get; }

        public string SzField { get; }

        public CorFieldAttr PdwAttr { get; }

        public IntPtr PpvSigBlob { get; }

        public uint PcbSigBlob { get; }

        public CorElementType PdwCPlusTypeFlag { get; }

        public IntPtr PpValue { get; }

        public uint PcchValue { get; }

        public GetFieldPropsResult(mdTypeDef pClass, string szField, CorFieldAttr pdwAttr, IntPtr ppvSigBlob, uint pcbSigBlob, CorElementType pdwCPlusTypeFlag, IntPtr ppValue, uint pcchValue)
        {
            PClass = pClass;
            SzField = szField;
            PdwAttr = pdwAttr;
            PpvSigBlob = ppvSigBlob;
            PcbSigBlob = pcbSigBlob;
            PdwCPlusTypeFlag = pdwCPlusTypeFlag;
            PpValue = ppValue;
            PcchValue = pcchValue;
        }
    }
}