using System;
using System.Reflection;

namespace ManagedCorDebug
{
    public struct GetMemberPropsResult
    {
        public mdTypeDef PClass { get; }

        public string SzMember { get; }

        public uint PdwAttr { get; }

        public IntPtr PpvSigBlob { get; }

        public uint PcbSigBlob { get; }

        public uint PulCodeRVA { get; }

        public uint PdwImplFlags { get; }

        public CorElementType PdwCPlusTypeFlag { get; }

        public IntPtr PpValue { get; }

        public uint PcchValue { get; }

        public GetMemberPropsResult(mdTypeDef pClass, string szMember, uint pdwAttr, IntPtr ppvSigBlob, uint pcbSigBlob, uint pulCodeRVA, uint pdwImplFlags, CorElementType pdwCPlusTypeFlag, IntPtr ppValue, uint pcchValue)
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