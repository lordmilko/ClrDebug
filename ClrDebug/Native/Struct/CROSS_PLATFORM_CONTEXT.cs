using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("X86Context = {X86Context.ToString(),nq}, Amd64Context = {Amd64Context.ToString(),nq}")]
    [StructLayout(LayoutKind.Explicit)]
    public struct CROSS_PLATFORM_CONTEXT
    {
        [FieldOffset(0)]
        public X86_CONTEXT X86Context;

        [FieldOffset(0)]
        public AMD64_CONTEXT Amd64Context;
    }
}
