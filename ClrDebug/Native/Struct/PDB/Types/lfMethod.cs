﻿using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for overloaded method list
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfMethod
    {
        /// <summary>
        /// LF_METHOD
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// number of occurrences of function
        /// </summary>
        public short count;

        /// <summary>
        /// index to LF_METHODLIST record
        /// </summary>
        public CV_typ_t mList;

        /// <summary>
        /// length prefixed name of method
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
