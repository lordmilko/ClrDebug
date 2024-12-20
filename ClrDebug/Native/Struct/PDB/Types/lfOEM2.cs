using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for OEM definable type strings
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, idOem = {idOem}, count = {count}, index = {index}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfOEM2
    {
        /// <summary>
        /// LF_OEM2
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// an oem ID (GUID)
        /// </summary>
        public Guid idOem;

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
