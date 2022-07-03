using System;
using System.Runtime.InteropServices;
using ClrDebug;

namespace NativeSymbols
{
    internal struct IMAGEHLP_MODULE64
    {
        public int SizeOfStruct;
        public ulong BaseOfImage;
        public uint ImageSize;
        public uint TimeDateStamp;
        public uint CheckSum;
        public uint NumSyms;
        public SYM_TYPE SymType;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string ModuleName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string ImageName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string LoadedImageName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string LoadedPdbName;
        public uint CVSig;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260 * 3)]
        public string CVData;
        public uint PdbSig;
        public Guid PdbSig70;
        public uint PdbAge;
        public bool PdbUnmatched;
        public bool DbgUnmatched;
        public bool LineNumbers;
        public bool GlobalSymbols;
        public bool TypeInfo;
        public bool SourceIndexed;
        public bool Publics;
        public IMAGE_FILE_MACHINE MachineType;
        public int Reserved;
    }
}
