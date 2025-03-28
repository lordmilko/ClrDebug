﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for virtual function table pointer
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, type = {type.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct lfVFuncTab_16t
    {
        /// <summary>
        /// LF_VFUNCTAB_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type index of pointer
        /// </summary>
        public CV_typ16_t type;
    }
}
