using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    // Note DEFRANGESYMREGISTERREL and DEFRANGESYMSUBFIELDREGISTER had same layout.

    /// <summary>
    /// A live range of sub field of variable. like locala.i
    /// </summary>
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, reg = {reg}, attr = {attr.ToString(),nq}, offParent = {offParent.ToString(),nq}, paddingdata = {paddingdata}, range = {range.ToString(),nq}, gaps = {gaps}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct DEFRANGESYMSUBFIELDREGISTER
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_DEFRANGE_SUBFIELD_REGISTER
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Register to hold the value of the symbol
        /// </summary>
        public short reg;

        /// <summary>
        /// Attribute of the register range.
        /// </summary>
        public CV_RANGEATTR attr;

        #region BitFIeld

        /// <summary>
        /// Offset in parent variable.
        /// </summary>
        public CV_uoff32_t offParent
        {
            get => GetBits(paddingdata, 0, PDB1.CV_OFFSET_PARENT_LENGTH_LIMIT);
            set => SetBits(ref paddingdata, 0, PDB1.CV_OFFSET_PARENT_LENGTH_LIMIT, value);
        }

        /// <summary>
        /// Padding for future use.
        /// </summary>
        public CV_uoff32_t padding
        {
            get => GetBits(paddingdata, PDB1.CV_OFFSET_PARENT_LENGTH_LIMIT, 20);
            set => SetBits(ref paddingdata, 0, 20, value);
        }

        public int paddingdata;

        #endregion

        /// <summary>
        /// Range of addresses where this program is valid
        /// </summary>
        public CV_LVAR_ADDR_RANGE range;

        /// <summary>
        /// The value is not available in following gaps.
        /// </summary>
        public fixed byte gaps[1]; //CV_LVAR_ADDR_GAP[]
    }
}
