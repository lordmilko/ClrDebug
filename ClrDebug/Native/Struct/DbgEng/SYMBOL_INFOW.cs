using System.Runtime.InteropServices;
using ClrDebug.DIA;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SYMBOL_INFOW
    {
        public int SizeOfStruct;
        public int TypeIndex;
        public fixed long Reserved[2];
        public int Index;
        public int Size;
        public long ModBase;
        public SymFlag Flags;
        public long Value;
        public long Address;
        public CV_HREG_e Register;
        public SymTagEnum Scope;
        public SymTagEnum Tag;
        public int NameLen;
        public int MaxNameLen;
        public fixed short Name[1];
    }
}
