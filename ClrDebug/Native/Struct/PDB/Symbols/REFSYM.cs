using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, sumName = {sumName}, ibSym = {ibSym}, imod = {imod}, usFill = {usFill}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct REFSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_PROCREF_ST, S_DATAREF_ST, or S_LPROCREF_ST
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// SUC of the name
        /// </summary>
        public int sumName;

        /// <summary>
        /// Offset of actual symbol in $$Symbols
        /// </summary>
        public int ibSym;

        /// <summary>
        /// Module containing the actual symbol
        /// </summary>
        public short imod;

        /// <summary>
        /// align this record
        /// </summary>
        public short usFill;
    }
}
