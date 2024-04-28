﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// argument list leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, count = {count}, arg = {arg}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfArgList_16t
    {
        /// <summary>
        /// LF_ARGLIST_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// number of arguments
        /// </summary>
        public short count;

        /// <summary>
        /// number of arguments
        /// </summary>
        public fixed short arg[1]; //CV_typ16_t
    }
}
