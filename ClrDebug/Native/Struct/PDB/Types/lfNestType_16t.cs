﻿using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for nested (scoped) type definition
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfNestType_16t
    {
        /// <summary>
        /// LF_NESTTYPE_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// index of nested type definition
        /// </summary>
        public CV_typ16_t index;

        /// <summary>
        /// length prefixed type name
        /// </summary>
        public fixed byte Name[1];

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = Name)
                return CreateString(ptr);
        }
    }
}
