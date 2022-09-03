using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    //This is 100% right, theres some items which should be arrays,
    //and some minor items missing (e.g. FltSave, Header and Legacy, etc in the Floating Point State section)
    [DebuggerDisplay("P1Home = {P1Home}, P2Home = {P2Home}, P3Home = {P3Home}, P4Home = {P4Home}, P5Home = {P5Home}, P6Home = {P6Home}, ContextFlags = {ContextFlags.ToString(),nq}, MxCsr = {MxCsr}, SegCs = {SegCs}, SegDs = {SegDs}, SegEs = {SegEs}, SegFs = {SegFs}, SegGs = {SegGs}, SegSs = {SegSs}, EFlags = {EFlags}, Dr0 = {Dr0}, Dr1 = {Dr1}, Dr2 = {Dr2}, Dr3 = {Dr3}, Dr6 = {Dr6}, Dr7 = {Dr7}, Rax = {Rax}, Rcx = {Rcx}, Rdx = {Rdx}, Rbx = {Rbx}, Rsp = {Rsp}, Rbp = {Rbp}, Rsi = {Rsi}, Rdi = {Rdi}, R8 = {R8}, R9 = {R9}, R10 = {R10}, R11 = {R11}, R12 = {R12}, R13 = {R13}, R14 = {R14}, R15 = {R15}, Rip = {Rip}, FltSave = {FltSave}, Legacy = {Legacy}, Xmm0 = {Xmm0}, Xmm1 = {Xmm1}, Xmm2 = {Xmm2}, Xmm3 = {Xmm3}, Xmm4 = {Xmm4}, Xmm5 = {Xmm5}, Xmm6 = {Xmm6}, Xmm7 = {Xmm7}, Xmm8 = {Xmm8}, Xmm9 = {Xmm9}, Xmm10 = {Xmm10}, Xmm11 = {Xmm11}, Xmm12 = {Xmm12}, Xmm13 = {Xmm13}, Xmm14 = {Xmm14}, Xmm15 = {Xmm15}, VectorRegister = {VectorRegister}, VectorControl = {VectorControl}, DebugControl = {DebugControl}, LastBranchToRip = {LastBranchToRip}, LastBranchFromRip = {LastBranchFromRip}, LastExceptionToRip = {LastExceptionToRip}, LastExceptionFromRip = {LastExceptionFromRip}")]
    [StructLayout(LayoutKind.Explicit, Size = 1232)]
    public struct AMD64_CONTEXT
    {
        // Register Parameter Home Addresses
        [FieldOffset(0x0)]
        public long P1Home;
        [FieldOffset(0x8)]
        public long P2Home;
        [FieldOffset(0x10)]
        public long P3Home;
        [FieldOffset(0x18)]
        public long P4Home;
        [FieldOffset(0x20)]
        public long P5Home;
        [FieldOffset(0x28)]
        public long P6Home;

        // Control Flags
        [FieldOffset(0x30)]
        public ContextFlags ContextFlags;
        [FieldOffset(0x34)]
        public int MxCsr;

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
        public int EFlags;

        // Debug Registers
        [FieldOffset(0x48)]
        public long Dr0;
        [FieldOffset(0x50)]
        public long Dr1;
        [FieldOffset(0x58)]
        public long Dr2;
        [FieldOffset(0x60)]
        public long Dr3;
        [FieldOffset(0x68)]
        public long Dr6;
        [FieldOffset(0x70)]
        public long Dr7;

        // Integer Registers
        [FieldOffset(0x78)]
        public long Rax;
        [FieldOffset(0x80)]
        public long Rcx;
        [FieldOffset(0x88)]
        public long Rdx;
        [FieldOffset(0x90)]
        public long Rbx;
        [FieldOffset(0x98)]
        public long Rsp;
        [FieldOffset(0xa0)]
        public long Rbp;
        [FieldOffset(0xa8)]
        public long Rsi;
        [FieldOffset(0xb0)]
        public long Rdi;
        [FieldOffset(0xb8)]
        public long R8;
        [FieldOffset(0xc0)]
        public long R9;
        [FieldOffset(0xc8)]
        public long R10;
        [FieldOffset(0xd0)]
        public long R11;
        [FieldOffset(0xd8)]
        public long R12;
        [FieldOffset(0xe0)]
        public long R13;
        [FieldOffset(0xe8)]
        public long R14;
        [FieldOffset(0xf0)]
        public long R15;

        // Program Counter
        [FieldOffset(0xf8)]
        public long Rip;

        // Floating Point State
        [FieldOffset(0x100)]
        public long FltSave;
        [FieldOffset(0x120)]
        public long Legacy;
        [FieldOffset(0x1a0)]
        public long Xmm0;
        [FieldOffset(0x1b0)]
        public long Xmm1;
        [FieldOffset(0x1c0)]
        public long Xmm2;
        [FieldOffset(0x1d0)]
        public long Xmm3;
        [FieldOffset(0x1e0)]
        public long Xmm4;
        [FieldOffset(0x1f0)]
        public long Xmm5;
        [FieldOffset(0x200)]
        public long Xmm6;
        [FieldOffset(0x210)]
        public long Xmm7;
        [FieldOffset(0x220)]
        public long Xmm8;
        [FieldOffset(0x230)]
        public long Xmm9;
        [FieldOffset(0x240)]
        public long Xmm10;
        [FieldOffset(0x250)]
        public long Xmm11;
        [FieldOffset(0x260)]
        public long Xmm12;
        [FieldOffset(0x270)]
        public long Xmm13;
        [FieldOffset(0x280)]
        public long Xmm14;
        [FieldOffset(0x290)]
        public long Xmm15;

        // Vector Registers
        [FieldOffset(0x300)]
        public long VectorRegister;
        [FieldOffset(0x4a0)]
        public long VectorControl;

        // Special Debug Control Registers
        [FieldOffset(0x4a8)]
        public long DebugControl;
        [FieldOffset(0x4b0)]
        public long LastBranchToRip;
        [FieldOffset(0x4b8)]
        public long LastBranchFromRip;
        [FieldOffset(0x4c0)]
        public long LastExceptionToRip;
        [FieldOffset(0x4c8)]
        public long LastExceptionFromRip;
    }
}
