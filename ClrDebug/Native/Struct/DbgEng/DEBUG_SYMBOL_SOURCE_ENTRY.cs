using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_SYMBOL_SOURCE_ENTRY
    {
        public ulong ModuleBase;
        public ulong Offset;
        public ulong FileNameId;
        public ulong EngineInternal;
        public uint Size;
        public uint Flags;
        public uint FileNameSize;

        // Line numbers are one-based.
        // May be DEBUG_ANY_ID if unknown.
        public uint StartLine;
        public uint EndLine;

        // Column numbers are one-based byte indices.
        // May be DEBUG_ANY_ID if unknown.
        public uint StartColumn;
        public uint EndColumn;
        public uint Reserved;
    }
}
