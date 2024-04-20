using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("Kind = {Kind.ToString(),nq}, DataSize = {DataSize}")]
    public struct IMAGE_COR_ILMETHOD_SECT_SMALL
    {
        public CorILMethodSect Kind;
        public byte DataSize;
    }
}
