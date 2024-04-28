﻿using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct BPRELSYM32_16t
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_BPREL32_16t
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// BP-relative offset
        /// </summary>
        public CV_off32_t off;

        /// <summary>
        /// Type index
        /// </summary>
        public CV_typ16_t typind;

        /// <summary>
        /// Length-prefixed name
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
