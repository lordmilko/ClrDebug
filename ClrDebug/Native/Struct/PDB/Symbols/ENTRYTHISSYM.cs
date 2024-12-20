using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, thissym = {thissym}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ENTRYTHISSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_ENTRYTHIS
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// symbol describing this pointer on entry
        /// </summary>
        public byte thissym;
    }
}
