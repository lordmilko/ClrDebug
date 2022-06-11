using System;

namespace ManagedCorDebug
{
    public struct EnumInterfaceImplsResult
    {
        public IntPtr PhEnum { get; }

        public mdInterfaceImpl[] RImpls { get; }

        public uint PcImpls { get; }

        public EnumInterfaceImplsResult(IntPtr phEnum, mdInterfaceImpl[] rImpls, uint pcImpls)
        {
            PhEnum = phEnum;
            RImpls = rImpls;
            PcImpls = pcImpls;
        }
    }
}