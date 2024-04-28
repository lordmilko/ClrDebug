using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for generic HLSL type
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, subtype = {subtype.ToString(),nq}, kind = {kind}, numprops = {numprops}, unused = {unused}, propdata = {propdata}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfHLSL
    {
        /// <summary>
        /// LF_HLSL
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// sub-type index, if any
        /// </summary>
        public CV_typ_t subtype;

        /// <summary>
        /// kind of built-in type from CV_builtin_e
        /// </summary>
        public short kind;

        #region BitField

        /// <summary>
        /// number of numeric properties
        /// </summary>
        public short numprops
        {
            get => GetBits(propdata, 0, 4); //0-3
            set => SetBits(ref propdata, 0, 4, value);
        }

        /// <summary>
        /// padding, must be 0
        /// </summary>
        public short unused
        {
            get => GetBits(propdata, 4, 12); //4-15
            set => SetBits(ref propdata, 4, 12, value);
        }

        public short propdata;

        #endregion

        /// <summary>
        /// variable-length array of numeric properties
        /// </summary>
        public fixed byte data[1];

        // followed by byte size
    }
}
