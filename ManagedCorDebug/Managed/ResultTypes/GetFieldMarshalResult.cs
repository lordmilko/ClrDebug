using System;

namespace ManagedCorDebug
{
    public struct GetFieldMarshalResult
    {
        public IntPtr PpvNativeType { get; }

        public int PcbNativeType { get; }

        public GetFieldMarshalResult(IntPtr ppvNativeType, int pcbNativeType)
        {
            PpvNativeType = ppvNativeType;
            PcbNativeType = pcbNativeType;
        }
    }
}