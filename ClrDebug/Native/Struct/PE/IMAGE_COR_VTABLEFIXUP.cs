using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("RVA = {RVA}, Count = {Count}, Type = {Type.ToString(),nq}")]
    public struct IMAGE_COR_VTABLEFIXUP
    {
        /// <summary>
        /// Offset of v-table array in image.
        /// </summary>
        public int RVA;

        /// <summary>
        /// How many entries at location.
        /// </summary>
        public short Count;

        /// <summary>
        /// COR_VTABLE_xxx type of entries.
        /// </summary>
        public COR_VTABLE Type;
    }
}
