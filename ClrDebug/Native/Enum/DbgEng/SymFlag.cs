using System;

namespace ClrDebug
{
    [Flags]
    public enum SymFlag : uint
    {
        ValuePresent = 0x00000001,
        Register = 0x00000008,
        RegRel = 0x00000010,
        FrameRel = 0x00000020,
        Parameter = 0x00000040,
        Local = 0x00000080,
        Constant = 0x00000100,
        Export = 0x00000200,
        Forwarder = 0x00000400,
        Function = 0x00000800,
        Virtual = 0x00001000,
        Thunk = 0x00002000,
        TlsRel = 0x00004000,
        Slot = 0x00008000,
        ILRel = 0x00010000,
        Metadata = 0x00020000,
        ClrToken = 0x00040000,
        Null = 0x00080000,
        FuncNoReturn = 0x00100000,
        SyntheticZerobase = 0x00200000,
        PublicCode = 0x00400000,
        RegRelAliasIndir = 0x00800000,
        Fixup_ARM64X = 0x01000000,
        Global = 0x02000000
    }
}
