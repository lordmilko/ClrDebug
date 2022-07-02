using System.Runtime.InteropServices;

namespace ClrDebug
{
    //This is 100% right, theres some items which should be arrays,
    //and some minor items missing (e.g. FltSave, Header and Legacy, etc in the Floating Point State section)

    [StructLayout(LayoutKind.Explicit, Size = 1232)]
    public struct AMD64_CONTEXT
    {
        // Register Parameter Home Addresses
        [FieldOffset(0x0)]
        public ulong P1Home;
        [FieldOffset(0x8)]
        public ulong P2Home;
        [FieldOffset(0x10)]
        public ulong P3Home;
        [FieldOffset(0x18)]
        public ulong P4Home;
        [FieldOffset(0x20)]
        public ulong P5Home;
        [FieldOffset(0x28)]
        public ulong P6Home;

        // Control Flags
        [FieldOffset(0x30)]
        public ContextFlags ContextFlags;
        [FieldOffset(0x34)]
        public uint MxCsr;

        // Segment Registers and Processor Flags
        [FieldOffset(0x38)]
        public ushort SegCs;
        [FieldOffset(0x3a)]
        public ushort SegDs;
        [FieldOffset(0x3c)]
        public ushort SegEs;
        [FieldOffset(0x3e)]
        public ushort SegFs;
        [FieldOffset(0x40)]
        public ushort SegGs;
        [FieldOffset(0x42)]
        public ushort SegSs;
        [FieldOffset(0x44)]
        public uint EFlags;

        // Debug Registers
        [FieldOffset(0x48)]
        public ulong Dr0;
        [FieldOffset(0x50)]
        public ulong Dr1;
        [FieldOffset(0x58)]
        public ulong Dr2;
        [FieldOffset(0x60)]
        public ulong Dr3;
        [FieldOffset(0x68)]
        public ulong Dr6;
        [FieldOffset(0x70)]
        public ulong Dr7;

        // Integer Registers
        [FieldOffset(0x78)]
        public ulong Rax;
        [FieldOffset(0x80)]
        public ulong Rcx;
        [FieldOffset(0x88)]
        public ulong Rdx;
        [FieldOffset(0x90)]
        public ulong Rbx;
        [FieldOffset(0x98)]
        public ulong Rsp;
        [FieldOffset(0xa0)]
        public ulong Rbp;
        [FieldOffset(0xa8)]
        public ulong Rsi;
        [FieldOffset(0xb0)]
        public ulong Rdi;
        [FieldOffset(0xb8)]
        public ulong R8;
        [FieldOffset(0xc0)]
        public ulong R9;
        [FieldOffset(0xc8)]
        public ulong R10;
        [FieldOffset(0xd0)]
        public ulong R11;
        [FieldOffset(0xd8)]
        public ulong R12;
        [FieldOffset(0xe0)]
        public ulong R13;
        [FieldOffset(0xe8)]
        public ulong R14;
        [FieldOffset(0xf0)]
        public ulong R15;

        // Program Counter
        [FieldOffset(0xf8)]
        public ulong Rip;

        // Floating Point State
        [FieldOffset(0x100)]
        public ulong FltSave;
        [FieldOffset(0x120)]
        public ulong Legacy;
        [FieldOffset(0x1a0)]
        public ulong Xmm0;
        [FieldOffset(0x1b0)]
        public ulong Xmm1;
        [FieldOffset(0x1c0)]
        public ulong Xmm2;
        [FieldOffset(0x1d0)]
        public ulong Xmm3;
        [FieldOffset(0x1e0)]
        public ulong Xmm4;
        [FieldOffset(0x1f0)]
        public ulong Xmm5;
        [FieldOffset(0x200)]
        public ulong Xmm6;
        [FieldOffset(0x210)]
        public ulong Xmm7;
        [FieldOffset(0x220)]
        public ulong Xmm8;
        [FieldOffset(0x230)]
        public ulong Xmm9;
        [FieldOffset(0x240)]
        public ulong Xmm10;
        [FieldOffset(0x250)]
        public ulong Xmm11;
        [FieldOffset(0x260)]
        public ulong Xmm12;
        [FieldOffset(0x270)]
        public ulong Xmm13;
        [FieldOffset(0x280)]
        public ulong Xmm14;
        [FieldOffset(0x290)]
        public ulong Xmm15;

        // Vector Registers
        [FieldOffset(0x300)]
        public ulong VectorRegister;
        [FieldOffset(0x4a0)]
        public ulong VectorControl;

        // Special Debug Control Registers
        [FieldOffset(0x4a8)]
        public ulong DebugControl;
        [FieldOffset(0x4b0)]
        public ulong LastBranchToRip;
        [FieldOffset(0x4b8)]
        public ulong LastBranchFromRip;
        [FieldOffset(0x4c0)]
        public ulong LastExceptionToRip;
        [FieldOffset(0x4c8)]
        public ulong LastExceptionFromRip;
    }
}