﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.DbgEng.DbgEngExtensions;

namespace ClrDebug.DbgEng
{
    //4096 bytes

    //The entire dump is filled with the word PAGE (EPAG backwards). Fields that don't have values will instead have PAGE
    [DebuggerDisplay("Signature = {Signature}, ValidDump = {ValidDump}, MajorVersion = {MajorVersion}, MinorVersion = {MinorVersion}, DirectoryTableBase = {DirectoryTableBase}, PfnDataBase = {PfnDataBase}, PsLoadedModuleList = {PsLoadedModuleList}, PsActiveProcessHead = {PsActiveProcessHead}, MachineImageType = {MachineImageType.ToString(),nq}, NumberProcessors = {NumberProcessors}, BugCheckCode = {BugCheckCode}, BugCheckParameter1 = {BugCheckParameter1}, BugCheckParameter2 = {BugCheckParameter2}, BugCheckParameter3 = {BugCheckParameter3}, BugCheckParameter4 = {BugCheckParameter4}, VersionUser = {VersionUser}, PaeEnabled = {PaeEnabled}, Spare3 = {Spare3}, KdDebuggerDataBlock = {KdDebuggerDataBlock}, PhysicalMemoryBlock = {PhysicalMemoryBlock.ToString(),nq}, PhysicalMemoryBlockBuffer = {PhysicalMemoryBlockBuffer}, ContextRecord = {ContextRecord}, Exception = {Exception.ToString(),nq}, Comment = {Comment}, _reserved0 = {_reserved0}, DumpType = {DumpType.ToString(),nq}, MiniDumpFields = {MiniDumpFields}, SecondaryDataState = {SecondaryDataState}, ProductType = {ProductType.ToString(),nq}, SuiteMask = {SuiteMask.ToString(),nq}, _reserved1 = {_reserved1}, RequiredDumpSpace = {RequiredDumpSpace.ToString(),nq}, _reserved2 = {_reserved2}, SystemUpTime = {SystemUpTime.ToString(),nq}, SystemUpTimeSpan = {SystemUpTimeSpan.ToString(),nq}, SystemTime = {SystemTime.ToString(),nq}, SystemDateTime = {SystemDateTime.ToString(),nq}, _reserved3 = {_reserved3}")]
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct DUMP_HEADER32
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
        public int DirectoryTableBase;

        [FieldOffset(20)]
        public int PfnDataBase;

        [FieldOffset(24)]
        public int PsLoadedModuleList;

        [FieldOffset(28)]
        public int PsActiveProcessHead;

        [FieldOffset(32)]
        public IMAGE_FILE_MACHINE MachineImageType;

        [FieldOffset(36)]
        public int NumberProcessors;

        [FieldOffset(40)]
        public int BugCheckCode;

        [FieldOffset(44)]
        public int BugCheckParameter1;

        [FieldOffset(48)]
        public int BugCheckParameter2;

        [FieldOffset(52)]
        public int BugCheckParameter3;

        [FieldOffset(56)]
        public int BugCheckParameter4;

        [FieldOffset(60)]
        public fixed byte VersionUser[32];

        [FieldOffset(92)]
        public byte PaeEnabled;

        [FieldOffset(93)]
        public fixed byte Spare3[3];

        [FieldOffset(96)]
        public int KdDebuggerDataBlock;

        [FieldOffset(100)]
        public PHYSICAL_MEMORY_DESCRIPTOR32 PhysicalMemoryBlock;

        [FieldOffset(100)]
        public fixed byte PhysicalMemoryBlockBuffer[DMP_PHYSICAL_MEMORY_BLOCK_SIZE_32];

        [FieldOffset(800)]
        public fixed byte ContextRecord[DMP_CONTEXT_RECORD_SIZE_32];

        [FieldOffset(2000)]
        public EXCEPTION_RECORD32 Exception;

        [FieldOffset(2080)]
        public fixed byte Comment[DMP_HEADER_COMMENT_SIZE];

        [FieldOffset(2208)]
        public fixed byte _reserved0[DMP_RESERVED_0_SIZE_32];

        [FieldOffset(3976)]
        public DUMP_TYPE DumpType;

        [FieldOffset(3980)]
        public int MiniDumpFields;

        [FieldOffset(3984)]
        public int SecondaryDataState;

        [FieldOffset(3988)]
        public VER_NT ProductType;

        [FieldOffset(3992)]
        public VER_SUITE SuiteMask;

        [FieldOffset(3996)]
        public fixed byte _reserved1[DMP_RESERVED_1_SIZE_32];

        [FieldOffset(4000)]
        public LARGE_INTEGER RequiredDumpSpace;

        [FieldOffset(4008)]
        public fixed byte _reserved2[DMP_RESERVED_2_SIZE_32];

        [FieldOffset(4024)]
        public LARGE_INTEGER SystemUpTime;

        //I think SystemUpTime is a FILETIME even though it's actually a duration
        public TimeSpan SystemUpTimeSpan => TimeSpan.FromSeconds(SystemUpTime.QuadPart / 10000000);

        [FieldOffset(4032)]
        public LARGE_INTEGER SystemTime;

        public DateTime SystemDateTime => DateTime.FromFileTime(SystemTime.QuadPart);

        [FieldOffset(4040)]
        public fixed byte _reserved3[DMP_RESERVED_3_SIZE_32];
    }
}
