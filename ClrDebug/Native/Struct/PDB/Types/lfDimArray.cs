﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for dimensioned arrays
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, utype = {utype.ToString(),nq}, diminfo = {diminfo.ToString(),nq}, name = {name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfDimArray
    {
        /// <summary>
        /// LF_DIMARRAY
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// underlying type of the array
        /// </summary>
        public CV_typ_t utype;

        /// <summary>
        /// dimension information
        /// </summary>
        public CV_typ_t diminfo;

        /// <summary>
        /// length prefixed name
        /// </summary>
        public fixed byte name[1];
    }
}
