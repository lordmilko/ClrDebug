﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for nonoverloaded method
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, attr = {attr.ToString(),nq}, index = {index.ToString(),nq}, vbaseoff = {vbaseoff}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfOneMethod_16t
    {
        /// <summary>
        /// LF_ONEMETHOD_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// method attribute
        /// </summary>
        public CV_fldattr_t attr;

        /// <summary>
        /// index to type record for procedure
        /// </summary>
        public CV_typ16_t index;

        /// <summary>
        /// offset in vfunctable if intro virtual followed by length prefixed name of method
        /// </summary>
        public fixed int vbaseoff[1];
    }
}
