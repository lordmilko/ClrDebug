using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("Tiny = {Tiny.ToString(),nq}, Fat = {Fat.ToString(),nq}")]
    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_COR_ILMETHOD
    {
        [FieldOffset(0)]
        public IMAGE_COR_ILMETHOD_TINY Tiny;

        [FieldOffset(0)]
        public IMAGE_COR_ILMETHOD_FAT Fat;
    }
}
