﻿using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for LF_BITFIELD
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, type = {type.ToString(),nq}, length = {length}, position = {position}")]
    public struct lfBitfield
    {
        /// <summary>
        /// LF_BITFIELD
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type of bitfield
        /// </summary>
        public CV_typ_t type;

        public byte length;
        public byte position;
    }
}
