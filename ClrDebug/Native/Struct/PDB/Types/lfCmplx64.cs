﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// complex 64-bit leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val_real = {val_real}, val_imag = {val_imag}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct lfCmplx64
    {
        /// <summary>
        /// LF_COMPLEX64
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// real component
        /// </summary>
        public double val_real;

        /// <summary>
        /// imaginary component
        /// </summary>
        public double val_imag;
    }
}
