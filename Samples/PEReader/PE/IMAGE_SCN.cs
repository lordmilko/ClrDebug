using System;

namespace PEReader.PE
{
    /// <summary>
    /// Represents the IMAGE_SCN_* enumeration which specifies the characteristics of an IMAGE_SECTION_HEADER.
    /// </summary>
    [Flags]
    public enum IMAGE_SCN : uint
    {
        TYPE_REG = 0,
        TYPE_DSECT = 0x00000001,
        TYPE_NOLOAD = 0x00000002,
        TYPE_GROUP = 0x00000004,
        TYPE_NO_PAD = 0x00000008,
        CNT_CODE = 0x00000020,
        CNT_INITIALIZED_DATA = 0x00000040,
        CNT_UNINITIALIZED_DATA = 0x00000080,
        LNK_INFO = 0x00000200,
        LNK_REMOVE = 0x00000800,
        LNK_COMDAT = 0x00001000,
        NO_DEFER_SPEC_EXC = 0x00004000,
        GPREL = 0x00008000,
        ALIGN_1BYTES = 0x00100000,
        ALIGN_2BYTES = 0x00200000,
        ALIGN_4BYTES = 0x00300000,
        ALIGN_8BYTES = 0x00400000,
        ALIGN_16BYTES = 0x00500000,
        ALIGN_32BYTES = 0x00600000,
        ALIGN_64BYTES = 0x00700000,
        ALIGN_128BYTES = 0x00800000,
        ALIGN_256BYTES = 0x00900000,
        ALIGN_512BYTES = 0x00a00000,
        ALIGN_1024BYTES = 0x00b00000,
        ALIGN_2048BYTES = 0x00c00000,
        ALIGN_4096BYTES = 0x00d00000,
        ALIGN_8192BYTES = 0x00e00000,
        LNK_NRELOC_OVFL = 0x01000000,
        MEM_DISCARDABLE = 0x02000000,
        MEM_NOT_CACHED = 0x04000000,
        MEM_NOT_PAGED = 0x08000000,
        MEM_SHARED = 0x10000000,
        MEM_EXECUTE = 0x20000000,
        MEM_READ = 0x40000000,
        MEM_WRITE = 0x80000000,
    }
}