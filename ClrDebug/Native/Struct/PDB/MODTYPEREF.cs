using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, fNone = {fNone}, fRefTMPCT = {fRefTMPCT}, fOwnTMPCT = {fOwnTMPCT}, fOwnTMR = {fOwnTMR}, fOwnTM = {fOwnTM}, fRefTM = {fRefTM}, reserved = {reserved}, data = {data}, word0 = {word0}, word1 = {word1}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct MODTYPEREF
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_MOD_TYPEREF
        /// </summary>
        public SYM_ENUM_e rectyp;

        #region BitField

        /// <summary>
        /// module doesn't reference any type
        /// </summary>
        public bool fNone
        {
            get => GetBitFlag(data, 0);
            set => SetBitFlag(ref data, 0, value);
        }

        /// <summary>
        /// reference /Z7 PCH types
        /// </summary>
        public bool fRefTMPCT
        {
            get => GetBitFlag(data, 1);
            set => SetBitFlag(ref data, 1, value);
        }

        /// <summary>
        /// module contains /Z7 PCH types
        /// </summary>
        public bool fOwnTMPCT
        {
            get => GetBitFlag(data, 2);
            set => SetBitFlag(ref data, 2, value);
        }

        /// <summary>
        /// module contains type info (/Z7)
        /// </summary>
        public bool fOwnTMR
        {
            get => GetBitFlag(data, 3);
            set => SetBitFlag(ref data, 3, value);
        }

        /// <summary>
        /// module contains type info (/Zi or /ZI)
        /// </summary>
        public bool fOwnTM
        {
            get => GetBitFlag(data, 4);
            set => SetBitFlag(ref data, 4, value);
        }

        /// <summary>
        /// module references type info owned by other module
        /// </summary>
        public bool fRefTM
        {
            get => GetBitFlag(data, 5);
            set => SetBitFlag(ref data, 5, value);
        }

        public int reserved
        {
            get => GetBits(data, 6, 9); //6-15
            set => SetBits(ref data, 6, 9, value);
        }

        //The bitfield is 32 bits, but Microsoft erroneously only added 9 bits of padding
        public int data;

        #endregion

        /// <summary>
        /// these two words contain SN or module index depending
        /// </summary>
        public short word0;

        /// <summary>
        /// on above flags
        /// </summary>
        public short word1;
    }
}
