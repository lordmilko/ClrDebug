using System;

namespace ManagedCorDebug
{
    public struct EnumMethodSpecsResult
    {
        public IntPtr PhEnum { get; }

        public mdMethodSpec[] RMethodSpecs { get; }

        public uint PcMethodSpecs { get; }

        public EnumMethodSpecsResult(IntPtr phEnum, mdMethodSpec[] rMethodSpecs, uint pcMethodSpecs)
        {
            PhEnum = phEnum;
            RMethodSpecs = rMethodSpecs;
            PcMethodSpecs = pcMethodSpecs;
        }
    }
}