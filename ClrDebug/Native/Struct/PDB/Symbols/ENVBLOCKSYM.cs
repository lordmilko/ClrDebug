using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, rev = {rev}, pad = {pad}, flags = {flags}, rgsz = {rgsz}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct ENVBLOCKSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_ENVBLOCK
        /// </summary>
        public SYM_ENUM_e rectyp;

        #region BitField

        /// <summary>
        /// reserved
        /// </summary>
        public bool rev
        {
            get => GetBitFlag(flags, 0);
            set => SetBitFlag(ref flags, 0, value);
        }

        /// <summary>
        /// reserved, must be 0
        /// </summary>
        public byte pad
        {
            get => GetBits(flags, 1, 7); //1-7
            set => SetBits(ref flags, 1, 7, value);
        }

        public byte flags;

        #endregion

        /// <summary>
        /// Sequence of zero-terminated strings
        /// </summary>
        public fixed byte rgsz[1];
    }
}
