using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    // Note DEFRANGESYMREGISTERREL and DEFRANGESYMSUBFIELDREGISTER had same layout.
    // Used when /GS Copy parameter as local variable or other variable don't cover by FRAMERELATIVE.

    /// <summary>
    /// A live range of variable related to a register.
    /// </summary>
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, baseReg = {baseReg}, spilledUdtMember = {spilledUdtMember}, padding = {padding}, offsetParent = {offsetParent}, flags = {flags}, offBasePointer = {offBasePointer.ToString(),nq}, range = {range.ToString(),nq}, gaps = {gaps}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct DEFRANGESYMREGISTERREL
    {
        internal const int CV_OFFSET_PARENT_LENGTH_LIMIT = 12;

        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_DEFRANGE_REGISTER_REL
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Register to hold the base pointer of the symbol
        /// </summary>
        public short baseReg;

        #region BitField

        /// <summary>
        /// Spilled member for s.i.
        /// </summary>
        public bool spilledUdtMember
        {
            get => GetBitFlag(flags, 0);
            set => SetBitFlag(ref flags, 0, value);
        }

        /// <summary>
        /// Padding for future use.
        /// </summary>
        public short padding
        {
            get => GetBits(flags, 1, 3); //1-3
            set => SetBits(ref flags, 1, 3, value);
        }

        /// <summary>
        /// Offset in parent variable.
        /// </summary>
        public short offsetParent
        {
            get => GetBits(flags, 4, CV_OFFSET_PARENT_LENGTH_LIMIT); //4-15
            set => SetBits(ref flags, 4, CV_OFFSET_PARENT_LENGTH_LIMIT, value);
        }

        public short flags;

        #endregion

        /// <summary>
        /// offset to register
        /// </summary>
        public CV_off32_t offBasePointer;

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
