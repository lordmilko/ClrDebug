using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("Flags = {Flags.ToString(),nq}, TryOffset = {TryOffset}, TryLength = {TryLength}, HandlerOffset = {HandlerOffset}, HandlerLength = {HandlerLength}, ClassToken = {ClassToken.ToString(),nq}, FilterOffset = {FilterOffset}")]
    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_FAT
    {
        [FieldOffset(0)]
        public CorExceptionFlag Flags; //We define the enum as a short for use in EH_CLAUSE_SMALL but in this struct it needs to be 4 bytes
        [FieldOffset(4)]
        public int TryOffset;

        [FieldOffset(8)]
        public int TryLength; // relative to start of try block

        [FieldOffset(12)]
        public int HandlerOffset;

        [FieldOffset(16)]
        public int HandlerLength; // relative to start of handler

        [FieldOffset(20)]
        public mdToken ClassToken; // use for type-based exception handlers

        [FieldOffset(20)]
        public int FilterOffset; // use for filter-based exception handlers (COR_ILEXCEPTION_FILTER is set)
    }
}
