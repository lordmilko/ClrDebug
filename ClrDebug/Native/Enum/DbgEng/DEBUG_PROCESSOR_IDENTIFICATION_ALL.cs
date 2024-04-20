using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// This union contains relevant information for a processor the supported processors.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct DEBUG_PROCESSOR_IDENTIFICATION_ALL
    {
        /// <summary>
        /// An Alpha processor as a <see cref="DEBUG_PROCESSOR_IDENTIFICATION_ALPHA"/> struct.
        /// </summary>
        [FieldOffset(0)]
        public DEBUG_PROCESSOR_IDENTIFICATION_ALPHA Alpha;

        /// <summary>
        /// An AMD64 processor as a <see cref="DEBUG_PROCESSOR_IDENTIFICATION_AMD64"/> struct.
        /// </summary>
        [FieldOffset(0)]
        public DEBUG_PROCESSOR_IDENTIFICATION_AMD64 Amd64;

        /// <summary>
        /// An Itanium architecture processor as a <see cref="DEBUG_PROCESSOR_IDENTIFICATION_IA64"/> struct.
        /// </summary>
        [FieldOffset(0)]
        public DEBUG_PROCESSOR_IDENTIFICATION_IA64 Ia64;

        /// <summary>
        /// An x86 processor as a <see cref="DEBUG_PROCESSOR_IDENTIFICATION_X86"/> struct.
        /// </summary>
        [FieldOffset(0)]
        public DEBUG_PROCESSOR_IDENTIFICATION_X86 X86;

        /// <summary>
        /// An ARM processor as a <see cref="DEBUG_PROCESSOR_IDENTIFICATION_ARM"/> struct.
        /// </summary>
        [FieldOffset(0)]
        public DEBUG_PROCESSOR_IDENTIFICATION_ARM Arm;

        /// <summary>
        /// An ARM64 processor as a <see cref="DEBUG_PROCESSOR_IDENTIFICATION_ARM64"/> struct.
        /// </summary>
        [FieldOffset(0)]
        public DEBUG_PROCESSOR_IDENTIFICATION_ARM64 Arm64;
    }
}