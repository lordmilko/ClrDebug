using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("RVA = {RVA}, Count = {Count}, Type = {Type.ToString(),nq}")]
    public struct IMAGE_COR_VTABLEFIXUP
    {
        public int RVA; // Offset of v-table array in image.
        public short Count; // How many entries at location.
        public COR_VTABLE Type; // COR_VTABLE_xxx type of entries.
    }
}
