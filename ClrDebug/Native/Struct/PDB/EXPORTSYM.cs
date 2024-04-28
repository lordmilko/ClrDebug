using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct EXPORTSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_EXPORT
        /// </summary>
        public SYM_ENUM_e rectyp;

        public short ordinal;

        #region BitField

        /// <summary>
        /// CONSTANT
        /// </summary>
        public bool fConstant
        {
            get => GetBitFlag(data, 0);
            set => SetBitFlag(ref data, 0, value);
        }

        /// <summary>
        /// DATA
        /// </summary>
        public bool fData
        {
            get => GetBitFlag(data, 1);
            set => SetBitFlag(ref data, 1, value);
        }

        /// <summary>
        /// PRIVATE
        /// </summary>
        public bool fPrivate
        {
            get => GetBitFlag(data, 2);
            set => SetBitFlag(ref data, 2, value);
        }

        /// <summary>
        /// NONAME
        /// </summary>
        public bool fNoName
        {
            get => GetBitFlag(data, 3);
            set => SetBitFlag(ref data, 3, value);
        }

        /// <summary>
        /// Ordinal was explicitly assigned
        /// </summary>
        public bool fOrdinal
        {
            get => GetBitFlag(data, 4);
            set => SetBitFlag(ref data, 4, value);
        }

        /// <summary>
        /// This is a forwarder
        /// </summary>
        public bool fForwarder
        {
            get => GetBitFlag(data, 5);
            set => SetBitFlag(ref data, 5, value);
        }

        /// <summary>
        /// Reserved. Must be zero.
        /// </summary>
        public short reserved
        {
            get => GetBits(data, 6, 10); //6-15
            set => SetBits(ref data, 6, 10, value);
        }

        public short data;

        #endregion

        /// <summary>
        /// name of
        /// </summary>
        public fixed byte name[1];

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = name)
                return CreateString(ptr);
        }
    }
}
