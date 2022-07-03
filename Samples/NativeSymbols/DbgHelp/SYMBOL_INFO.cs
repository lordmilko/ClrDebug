using System.Runtime.InteropServices;

namespace NativeSymbols
{
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct SYMBOL_INFO
    {
        public int SizeOfStruct;
        public int TypeIndex;       // Type Index of symbol
        public fixed ulong Reserved[2];
        public int Index;
        public int Size;
        public ulong ModBase;         // Base Address of module comtaining this symbol
        public SymbolInfoFlags Flags;
        public ulong Value;           // Value of symbol, ValuePresent should be 1
        public ulong Address;         // Address of symbol including base address of module
        public int Register;        // register holding value or pointer to value
        public int Scope;           // scope of the symbol
        public SymTag Tag;             // pdb classification
        public int NameLen;         // Actual length of name
        public int MaxNameLen;
        public fixed char Name[1];       // Name of symbol
    }
}
