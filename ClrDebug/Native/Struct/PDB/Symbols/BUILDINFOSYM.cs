using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, id = {id.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BUILDINFOSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_BUILDINFO
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// CV_ItemId of Build Info.
        /// </summary>
        public CV_ItemId id;
    }
}
