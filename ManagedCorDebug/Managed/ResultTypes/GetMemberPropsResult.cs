using System;
using System.Reflection;

namespace ManagedCorDebug
{
    public struct GetMemberPropsResult
    {
        public mdTypeDef PClass { get; }

        public string SzMember { get; }

        public int PdwAttr { get; }

        public IntPtr PpvSigBlob { get; }

        public int PcbSigBlob { get; }

        public int PulCodeRVA { get; }

        public int PdwImplFlags { get; }

        public CorElementType PdwCPlusTypeFlag { get; }

        public IntPtr PpValue { get; }

        public int PcchValue { get; }

        public GetMemberPropsResult(mdTypeDef pClass, string szMember, int pdwAttr, IntPtr ppvSigBlob, int pcbSigBlob, int pulCodeRVA, int pdwImplFlags, CorElementType pdwCPlusTypeFlag, IntPtr ppValue, int pcchValue)
        {
            PClass = pClass;
            SzMember = szMember;
            PdwAttr = pdwAttr;
            PpvSigBlob = ppvSigBlob;
            PcbSigBlob = pcbSigBlob;
            PulCodeRVA = pulCodeRVA;
            PdwImplFlags = pdwImplFlags;
            PdwCPlusTypeFlag = pdwCPlusTypeFlag;
            PpValue = ppValue;
            PcchValue = pcchValue;
        }
    }
}