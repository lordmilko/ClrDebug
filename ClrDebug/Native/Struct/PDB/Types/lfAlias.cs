﻿using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for LF_ALIAS
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, utype = {utype.ToString(),nq}, Name = {Name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfAlias
    {
        /// <summary>
        /// LF_ALIAS
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// underlying type
        /// </summary>
        public CV_typ_t utype;

        /// <summary>
        /// alias name
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
