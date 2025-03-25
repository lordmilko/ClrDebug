using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Precompiled types mapping table<para/>
    /// This table should be ignored by all consumers except the incremental
    /// packer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct OMFPreCompMap
    {
        /// <summary>
        /// first precompiled type index
        /// </summary>
        public ushort FirstType;

        /// <summary>
        /// number of precompiled types
        /// </summary>
        public ushort cTypes;

        /// <summary>
        /// precompiled types signature
        /// </summary>
        public uint signature;

        public ushort pad;

        /// <summary>
        /// mapping of precompiled types<para/>
        /// This value is an array of <see cref="CV_typ_t"/>
        /// </summary>
        public fixed int map[1]; //CV_typ_t
    }
}
