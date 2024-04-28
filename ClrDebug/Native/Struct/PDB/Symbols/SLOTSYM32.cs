using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, iSlot = {iSlot}, typind = {typind.ToString(),nq}, name = {name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct SLOTSYM32
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_LOCALSLOT or S_PARAMSLOT
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// slot index
        /// </summary>
        public int iSlot;

        /// <summary>
        /// Type index or Metadata token
        /// </summary>
        public CV_typ_t typind;

        /// <summary>
        /// Length-prefixed name
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
