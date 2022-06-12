using System;

namespace ManagedCorDebug
{
    public struct EnumInterfaceImplsResult
    {
        public IntPtr PhEnum { get; }

        public mdInterfaceImpl[] RImpls { get; }

        public int PcImpls { get; }

        public EnumInterfaceImplsResult(IntPtr phEnum, mdInterfaceImpl[] rImpls, int pcImpls)
        {
            PhEnum = phEnum;
            RImpls = rImpls;
            PcImpls = pcImpls;
        }
    }
}