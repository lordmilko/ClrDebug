using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// complex 128-bit leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val_real = {val_real}, val_imag = {val_imag}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfCmplx128
    {
        /// <summary>
        /// LF_COMPLEX128
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// real component
        /// </summary>
        public fixed byte val_real[16];

        /// <summary>
        /// imaginary component
        /// </summary>
        public fixed byte val_imag[16];
    }
}
