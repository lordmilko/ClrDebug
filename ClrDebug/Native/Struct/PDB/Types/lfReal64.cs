﻿using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// real 64-bit leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    public struct lfReal64
    {
        /// <summary>
        /// LF_REAL64
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// 64-bit real value
        /// </summary>
        public double val;
    }
}
