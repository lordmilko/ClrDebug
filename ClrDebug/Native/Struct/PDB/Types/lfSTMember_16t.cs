﻿using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for static data members
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfSTMember_16t
    {
        /// <summary>
        /// LF_STMEMBER_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// index of type record for field
        /// </summary>
        public CV_typ16_t index;

        /// <summary>
        /// attribute mask
        /// </summary>
        public CV_fldattr_t attr;

        /// <summary>
        /// length prefixed name of field
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
