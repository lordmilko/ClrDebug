﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for LF_ARRAY
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, elemtype = {elemtype.ToString(),nq}, idxtype = {idxtype.ToString(),nq}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfArray
    {
        /// <summary>
        /// LF_ARRAY
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type index of element type
        /// </summary>
        public CV_typ_t elemtype;

        /// <summary>
        /// type index of indexing type
        /// </summary>
        public CV_typ_t idxtype;

        /// <summary>
        /// variable length data specifying size in bytes and name
        /// </summary>
        public fixed byte data[1];
    }
}
