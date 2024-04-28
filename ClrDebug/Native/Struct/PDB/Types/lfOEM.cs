using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for OEM definable type strings
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, cvOEM = {cvOEM}, recOEM = {recOEM}, count = {count}, index = {index}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfOEM
    {
        /// <summary>
        /// LF_OEM
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// MS assigned OEM identified
        /// </summary>
        public short cvOEM;

        /// <summary>
        /// OEM assigned type identifier
        /// </summary>
        public short recOEM;

        /// <summary>
        /// count of type indices to follow
        /// </summary>
        public int count;

        /// <summary>
        /// array of type indices followed by OEM defined data
        /// </summary>
        public fixed int index[1]; //CV_typ_t
    }
}
