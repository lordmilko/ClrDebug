using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    //8196 bytes

    //The entire dump is filled with the word PAGE (EPAG backwards). Fields that don't have values will instead have PAGE
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct DUMP_HEADER64
    {
        [FieldOffset(0)]
        public int Signature;

        [FieldOffset(4)]
        public int ValidDump;

        [FieldOffset(8)]
        public int MajorVersion;

        [FieldOffset(12)]
        public int MinorVersion;

        [FieldOffset(16)]
        public ulong DirectoryTableBase;

        [FieldOffset(24)]
        public ulong PfnDataBase;

        [FieldOffset(32)]
        public ulong PsLoadedModuleList;

        [FieldOffset(40)]
        public ulong PsActiveProcessHead;

        [FieldOffset(48)]
        public IMAGE_FILE_MACHINE MachineImageType;

        [FieldOffset(52)]
        public int NumberProcessors;

        [FieldOffset(56)]
        public int BugCheckCode;

        //Compiler pads 4 bytes here in C# and C++

        [FieldOffset(64)]
        public ulong BugCheckParameter1;

        [FieldOffset(72)]
        public ulong BugCheckParameter2;

        [FieldOffset(80)]
        public ulong BugCheckParameter3;

        [FieldOffset(88)]
        public ulong BugCheckParameter4;

        [FieldOffset(96)]
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPStr, SizeConst = 32)]
        public char[] VersionUser;

        [FieldOffset(128)]
        public ulong KdDebuggerDataBlock;

        [FieldOffset(136)]
        public PHYSICAL_MEMORY_DESCRIPTOR64 PhysicalMemoryBlock;

        [FieldOffset(136)]
        public fixed byte PhysicalMemoryBlockBuffer[DbgEngExtensions.DMP_PHYSICAL_MEMORY_BLOCK_SIZE_64];

        [FieldOffset(836)]
        public fixed byte ContextRecord[DbgEngExtensions.DMP_CONTEXT_RECORD_SIZE_64];

        [FieldOffset(3836)]
        public EXCEPTION_RECORD64 Exception;

        //Compiler pads 4 bytes here in C# and C++

        [FieldOffset(3992)]
        public DUMP_TYPE DumpType;

        //Compiler pads 4 bytes here in C# and C++

        [FieldOffset(4000)]
        public LARGE_INTEGER RequiredDumpSpace;

        [FieldOffset(4008)]
        public LARGE_INTEGER SystemTime;

        public DateTime SystemDateTime => DateTime.FromFileTime(SystemTime.QuadPart);

        [FieldOffset(4016)]
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPStr, SizeConst = DbgEngExtensions.DMP_HEADER_COMMENT_SIZE)]
        public char[] Comment;

        [FieldOffset(4144)]
        public LARGE_INTEGER SystemUpTime;

        //I think SystemUpTime is a FILETIME even though it's actually a duration
        public TimeSpan SystemUpTimeSpan => TimeSpan.FromSeconds(SystemUpTime.QuadPart / 10000000);

        [FieldOffset(4152)]
        public int MiniDumpFields;

        [FieldOffset(4156)]
        public int SecondaryDataState;

        [FieldOffset(4160)]
        public VER_NT ProductType;

        [FieldOffset(4164)]
        public VER_SUITE SuiteMask;

        [FieldOffset(4168)]
        public fixed byte _reserved0[DbgEngExtensions.DMP_RESERVED_0_SIZE_64];

        //Compiler pads 4 bytes here in C# and C++
    }
}
