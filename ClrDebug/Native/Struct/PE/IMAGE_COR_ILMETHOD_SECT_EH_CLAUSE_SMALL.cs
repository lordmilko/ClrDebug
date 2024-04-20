using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("Flags = {Flags.ToString(),nq}, TryOffset = {TryOffset}, TryLength = {TryLength}, HandlerOffset = {HandlerOffset}, HandlerLength = {HandlerLength}, ClassToken = {ClassToken.ToString(),nq}, FilterOffset = {FilterOffset}")]
    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_SMALL
    {
        [FieldOffset(0)]
        public CorExceptionFlag Flags;

        [FieldOffset(2)]
        public short TryOffset;

        [FieldOffset(4)]
        public byte TryLength; // relative to start of try block

        [FieldOffset(5)]
        public short HandlerOffset;

        [FieldOffset(7)]
        public byte HandlerLength; // relative to start of handler

        [FieldOffset(8)]
        public mdToken ClassToken;

        [FieldOffset(8)]
        public int FilterOffset;
    }
}
