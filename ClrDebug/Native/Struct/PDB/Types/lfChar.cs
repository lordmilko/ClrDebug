﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// signed character leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct lfChar
    {
        /// <summary>
        /// LF_CHAR
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// signed 8-bit value
        /// </summary>
        public sbyte val;
    }
}
