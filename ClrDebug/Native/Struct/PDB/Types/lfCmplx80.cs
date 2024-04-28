using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// complex 80-bit leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val_real = {val_real}, val_imag = {val_imag}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfCmplx80
    {
        /// <summary>
        /// LF_COMPLEX80
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// real component
        /// </summary>
        public fixed byte val_real[10]; //FLOAT10

        /// <summary>
        /// imaginary component
        /// </summary>
        public fixed byte val_imag[10]; //FLOAT10
    }
}
