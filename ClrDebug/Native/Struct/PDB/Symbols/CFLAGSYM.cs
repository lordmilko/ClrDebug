using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct CFLAGSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_COMPILE
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// target processor
        /// </summary>
        public byte machine;

        #region BitField

        /// <summary>
        /// language index
        /// </summary>
        public byte language;

        /// <summary>
        /// true if pcode present
        /// </summary>
        public bool pcode
        {
            get => GetBitFlag(flags1, 0);
            set => SetBitFlag(ref flags1, 0, value);
        }

        /// <summary>
        /// floating precision
        /// </summary>
        public byte floatprec
        {
            get => GetBits(flags1, 1, 2); //1-2
            set => SetBits(ref flags1, 1, 2, value);
        }

        /// <summary>
        /// float package
        /// </summary>
        public byte floatpkg
        {
            get => GetBits(flags1, 2, 2); //3-4
            set => SetBits(ref flags1, 2, 2, value);
        }

        /// <summary>
        /// ambient data model
        /// </summary>
        public byte ambdata
        {
            get => GetBits(flags1, 5, 2); //5-8
            set => SetBits(ref flags1, 5, 2, value);
        }

        /// <summary>
        /// ambient code model
        /// </summary>
        public byte ambcode
        {
            get => GetBits(flags2, 0, 3); //0-2
            set => SetBits(ref flags2, 0, 3, value);
        }

        /// <summary>
        /// true if compiled 32 bit mode
        /// </summary>
        public bool mode32
        {
            get => GetBitFlag(flags2, 3);
            set => SetBitFlag(ref flags2, 3, value);
        }

        /// <summary>
        /// reserved
        /// </summary>
        public byte pad
        {
            get => GetBits(flags2, 4, 4); //4-7
            set => SetBits(ref flags2, 4, 4, value);
        }

        //16 bits (language was 8 bits so is a standalone byte)
        public byte flags1;
        public byte flags2;

        #endregion

        /// <summary>
        /// Length-prefixed compiler version string
        /// </summary>
        public fixed byte ver[1];

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = ver)
                return CreateString(ptr);
        }
    }
}
