using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, isectCoff = {isectCoff}, typind = {typind.ToString(),nq}, imod = {imod}, fLocal = {fLocal}, fData = {fData}, fUDT = {fUDT}, fLabel = {fLabel}, fConst = {fConst}, reserved = {reserved}, data2 = {data2}, name = {name}")]
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct REFMINIPDB
    {
        /// <summary>
        /// Record length
        /// </summary>
        [FieldOffset(0)]
        public short reclen;

        /// <summary>
        /// S_REF_MINIPDB
        /// </summary>
        [FieldOffset(4)]
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// coff section
        /// </summary>
        [FieldOffset(6)]
        public int isectCoff;

        /// <summary>
        /// type index
        /// </summary>
        [FieldOffset(6)]
        public CV_typ_t typind;

        /// <summary>
        /// mod index
        /// </summary>
        [FieldOffset(8)]
        public short imod;

        #region BitField

        /// <summary>
        /// reference to local (vs. global) func or data
        /// </summary>
        public bool fLocal
        {
            get => GetBitFlag(data2, 0);
            set => SetBitFlag(ref data2, 0, value);
        }

        /// <summary>
        /// reference to data (vs. func)
        /// </summary>
        public bool fData
        {
            get => GetBitFlag(data2, 1);
            set => SetBitFlag(ref data2, 1, value);
        }

        /// <summary>
        /// reference to UDT
        /// </summary>
        public bool fUDT
        {
            get => GetBitFlag(data2, 2);
            set => SetBitFlag(ref data2, 2, value);
        }

        /// <summary>
        /// reference to label
        /// </summary>
        public bool fLabel
        {
            get => GetBitFlag(data2, 3);
            set => SetBitFlag(ref data2, 3, value);
        }

        /// <summary>
        /// reference to const
        /// </summary>
        public bool fConst
        {
            get => GetBitFlag(data2, 4);
            set => SetBitFlag(ref data2, 4, value);
        }

        /// <summary>
        /// reserved, must be zero
        /// </summary>
        public short reserved
        {
            get => GetBits(data2, 5, 11); //5-15
            set => SetBits(ref data2, 5, 11, value);
        }

        [FieldOffset(10)]
        public short data2;

        #endregion

        /// <summary>
        /// zero terminated name string
        /// </summary>
        [FieldOffset(12)]
        public fixed byte name[1];

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = name)
                return CreateString(ptr);
        }
    }
}
