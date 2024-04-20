using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("Flags = {Flags.ToString(),nq}, TryStartPC = {TryStartPC}, TryEndPC = {TryEndPC}, HandlerStartPC = {HandlerStartPC}, HandlerEndPC = {HandlerEndPC}, ClassToken = {ClassToken.ToString(),nq}, FilterOffset = {FilterOffset}")]
    [StructLayout(LayoutKind.Explicit)]
    struct READYTORUN_EXCEPTION_CLAUSE
    {
        [FieldOffset(0)]
        public CorExceptionFlag Flags;

        [FieldOffset(4)]
        public int TryStartPC;

        [FieldOffset(8)]
        public int TryEndPC;

        [FieldOffset(12)]
        public int HandlerStartPC;

        [FieldOffset(16)]
        public int HandlerEndPC;

        [FieldOffset(20)]
        public mdToken ClassToken;

        [FieldOffset(20)]
        public int FilterOffset;
    }
}
