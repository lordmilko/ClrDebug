using System;

namespace ManagedCorDebug
{
    public struct GetFieldMarshalResult
    {
        public IntPtr PpvNativeType { get; }

        public uint PcbNativeType { get; }

        public GetFieldMarshalResult(IntPtr ppvNativeType, uint pcbNativeType)
        {
            PpvNativeType = ppvNativeType;
            PcbNativeType = pcbNativeType;
        }
    }
}