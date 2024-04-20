using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Explicit)]
    public struct DEBUG_PROCESSOR_IDENTIFICATION_ALL
    {
        [FieldOffset(0)]
        public DEBUG_PROCESSOR_IDENTIFICATION_ALPHA Alpha;

        [FieldOffset(0)]
        public DEBUG_PROCESSOR_IDENTIFICATION_AMD64 Amd64;

        [FieldOffset(0)]
        public DEBUG_PROCESSOR_IDENTIFICATION_IA64 Ia64;

        [FieldOffset(0)]
        public DEBUG_PROCESSOR_IDENTIFICATION_X86 X86;

        [FieldOffset(0)]
        public DEBUG_PROCESSOR_IDENTIFICATION_ARM Arm;

        [FieldOffset(0)]
        public DEBUG_PROCESSOR_IDENTIFICATION_ARM64 Arm64;
    }
}