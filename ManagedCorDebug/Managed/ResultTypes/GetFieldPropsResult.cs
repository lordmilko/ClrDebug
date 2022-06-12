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

        public int PcbSigBlob { get; }

        public CorElementType PdwCPlusTypeFlag { get; }

        public IntPtr PpValue { get; }

        public int PcchValue { get; }

        public GetFieldPropsResult(mdTypeDef pClass, string szField, CorFieldAttr pdwAttr, IntPtr ppvSigBlob, int pcbSigBlob, CorElementType pdwCPlusTypeFlag, IntPtr ppValue, int pcchValue)
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