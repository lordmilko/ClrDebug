using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, typind = {typind.ToString(),nq}, attr = {attr.ToString(),nq}, reg = {reg}, name = {name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct ATTRREGSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_MANREGISTER | S_ATTR_REGISTER
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Type index or Metadata token
        /// </summary>
        public CV_typ_t typind;

        /// <summary>
        /// local var attributes
        /// </summary>
        public CV_lvar_attr attr;

        /// <summary>
        /// register enumerate
        /// </summary>
        public short reg;

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
