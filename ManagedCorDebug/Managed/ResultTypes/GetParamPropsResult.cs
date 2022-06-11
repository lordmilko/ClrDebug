using System;
using System.Reflection;

namespace ManagedCorDebug
{
    public struct GetParamPropsResult
    {
        public mdMethodDef Pmd { get; }

        public uint PulSequence { get; }

        public string SzName { get; }

        public uint CchName { get; }

        public uint PchName { get; }

        public CorParamAttr PdwAttr { get; }

        public CorElementType PdwCPlusTypeFlag { get; }

        public IntPtr PpValue { get; }

        public IntPtr PcchValue { get; }

        public GetParamPropsResult(mdMethodDef pmd, uint pulSequence, string szName, uint cchName, uint pchName, CorParamAttr pdwAttr, CorElementType pdwCPlusTypeFlag, IntPtr ppValue, IntPtr pcchValue)
        {
            Pmd = pmd;
            PulSequence = pulSequence;
            SzName = szName;
            CchName = cchName;
            PchName = pchName;
            PdwAttr = pdwAttr;
            PdwCPlusTypeFlag = pdwCPlusTypeFlag;
            PpValue = ppValue;
            PcchValue = pcchValue;
        }
    }
}