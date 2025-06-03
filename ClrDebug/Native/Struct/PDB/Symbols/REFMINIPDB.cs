using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct REFMINIPDB
    {
        /// <summary>
        /// Record length
        /// </summary>
        [FieldOffset(0)]
        public ushort reclen;

        /// <summary>
        /// S_REF_MINIPDB
        /// </summary>
        [FieldOffset(2)]
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// coff section
        /// </summary>
        [FieldOffset(4)]
        public int isectCoff;

        /// <summary>
        /// type index
        /// </summary>
        [FieldOffset(4)]
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
            get => GetBitFlag(data, 0);
            set => SetBitFlag(ref data, 0, value);
        }

        /// <summary>
        /// reference to data (vs. func)
        /// </summary>
        public bool fData
        {
            get => GetBitFlag(data, 1);
            set => SetBitFlag(ref data, 1, value);
        }

        /// <summary>
        /// reference to UDT
        /// </summary>
        public bool fUDT
        {
            get => GetBitFlag(data, 2);
            set => SetBitFlag(ref data, 2, value);
        }

        /// <summary>
        /// reference to label
        /// </summary>
        public bool fLabel
        {
            get => GetBitFlag(data, 3);
            set => SetBitFlag(ref data, 3, value);
        }

        /// <summary>
        /// reference to const
        /// </summary>
        public bool fConst
        {
            get => GetBitFlag(data, 4);
            set => SetBitFlag(ref data, 4, value);
        }

        /// <summary>
        /// reserved, must be zero
        /// </summary>
        public short reserved
        {
            get => GetBits(data, 5, 11); //5-15
            set => SetBits(ref data, 5, 11, value);
        }

        [FieldOffset(10)]
        public short data;

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
