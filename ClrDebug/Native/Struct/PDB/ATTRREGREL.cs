﻿using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, off = {off.ToString(),nq}, typind = {typind.ToString(),nq}, reg = {reg}, attr = {attr.ToString(),nq}, name = {name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct ATTRREGREL
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_MANREGREL | S_ATTR_REGREL
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// offset of symbol
        /// </summary>
        public CV_uoff32_t off;

        /// <summary>
        /// Type index or metadata token
        /// </summary>
        public CV_typ_t typind;

        /// <summary>
        /// register index for symbol
        /// </summary>
        public short reg;

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
