using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, typind = {typind.ToString(),nq}, value = {value}, name = {name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct CONSTSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_CONSTANT or S_MANCONSTANT
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Type index (containing enum if enumerate) or metadata token
        /// </summary>
        public CV_typ_t typind;

        /// <summary>
        /// numeric leaf containing value
        /// </summary>
        public short value;

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
