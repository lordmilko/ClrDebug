﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ENDARGSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_ENDARG
        /// </summary>
        public SYM_ENUM_e rectyp;
    }
}
