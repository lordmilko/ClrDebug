using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// complex 32-bit leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val_real = {val_real}, val_imag = {val_imag}")]
    public struct lfCmplx32
    {
        /// <summary>
        /// LF_COMPLEX32
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// real component
        /// </summary>
        public float val_real;

        /// <summary>
        /// imaginary component
        /// </summary>
        public float val_imag;
    }
}
