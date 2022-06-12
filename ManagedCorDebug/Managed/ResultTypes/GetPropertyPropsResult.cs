using System;
using System.Reflection;

namespace ManagedCorDebug
{
    public struct GetPropertyPropsResult
    {
        public mdTypeDef PClass { get; }

        public string SzProperty { get; }

        public CorPropertyAttr PdwPropFlags { get; }

        public IntPtr PpvSig { get; }

        public int PbSig { get; }

        public CorElementType PdwCPlusTypeFlag { get; }

        public IntPtr PpDefaultValue { get; }

        public int PcchDefaultValue { get; }

        public mdMethodDef PmdSetter { get; }

        public mdMethodDef PmdGetter { get; }

        public mdMethodDef[] RmdOtherMethod { get; }

        public GetPropertyPropsResult(mdTypeDef pClass, string szProperty, CorPropertyAttr pdwPropFlags, IntPtr ppvSig, int pbSig, CorElementType pdwCPlusTypeFlag, IntPtr ppDefaultValue, int pcchDefaultValue, mdMethodDef pmdSetter, mdMethodDef pmdGetter, mdMethodDef[] rmdOtherMethod)
        {
            PClass = pClass;
            SzProperty = szProperty;
            PdwPropFlags = pdwPropFlags;
            PpvSig = ppvSig;
            PbSig = pbSig;
            PdwCPlusTypeFlag = pdwCPlusTypeFlag;
            PpDefaultValue = ppDefaultValue;
            PcchDefaultValue = pcchDefaultValue;
            PmdSetter = pmdSetter;
            PmdGetter = pmdGetter;
            RmdOtherMethod = rmdOtherMethod;
        }
    }
}