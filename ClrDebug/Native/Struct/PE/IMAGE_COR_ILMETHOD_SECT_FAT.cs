using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("Kind = {Kind.ToString(),nq}, DataSize = {DataSize}")]
    public unsafe struct IMAGE_COR_ILMETHOD_SECT_FAT
    {
        public CorILMethodSect Kind;
        public fixed byte DataSize[3]; //24 bits
    }
}
