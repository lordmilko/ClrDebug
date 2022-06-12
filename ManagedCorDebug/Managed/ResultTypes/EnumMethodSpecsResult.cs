using System;

namespace ManagedCorDebug
{
    public struct EnumMethodSpecsResult
    {
        public IntPtr PhEnum { get; }

        public mdMethodSpec[] RMethodSpecs { get; }

        public int PcMethodSpecs { get; }

        public EnumMethodSpecsResult(IntPtr phEnum, mdMethodSpec[] rMethodSpecs, int pcMethodSpecs)
        {
            PhEnum = phEnum;
            RMethodSpecs = rMethodSpecs;
            PcMethodSpecs = pcMethodSpecs;
        }
    }
}