using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Symbol for describing security cookie's position and type (raw, xor'd with esp, xor'd with ebp).
    /// </summary>
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, off = {off.ToString(),nq}, reg = {reg}, cookietype = {cookietype.ToString(),nq}, flags = {flags}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct FRAMECOOKIE
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_FRAMECOOKIE
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Frame relative offset
        /// </summary>
        public CV_off32_t off;

        /// <summary>
        /// Register index
        /// </summary>
        public short reg;

        /// <summary>
        /// Type of the cookie
        /// </summary>
        public CV_cookietype_e cookietype;

        /// <summary>
        /// Flags describing this cookie
        /// </summary>
        public byte flags;
    }
}
