﻿using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct COFFGROUPSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_COFFGROUP
        /// </summary>
        public SYM_ENUM_e rectyp;

        public int cb;
        public int characteristics; //todo: enum?

        /// <summary>
        /// Symbol offset
        /// </summary>
        public CV_uoff32_t off;

        /// <summary>
        /// Symbol segment
        /// </summary>
        public short seg;

        /// <summary>
        /// name
        /// </summary>
        public fixed byte name[1];

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = name)
                return CreateString(ptr);
        }
    }
}
