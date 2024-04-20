using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("Flags_CodeSize = {Flags_CodeSize}")]
    public struct IMAGE_COR_ILMETHOD_TINY
    {
        public byte Flags_CodeSize;
    }
}
