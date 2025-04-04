﻿using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ATTRSLOTSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_MANSLOT
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// slot index
        /// </summary>
        public int iSlot;

        /// <summary>
        /// Type index or Metadata token
        /// </summary>
        public CV_typ_t typind;

        /// <summary>
        /// local var attributes
        /// </summary>
        public CV_lvar_attr attr;

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
