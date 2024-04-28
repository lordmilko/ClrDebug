using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// A frame variable valid in all function scope
    /// </summary>
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, offFramePointer = {offFramePointer.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct DEFRANGESYMFRAMEPOINTERREL_FULL_SCOPE
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_DEFRANGE_FRAMEPOINTER_REL
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// offset to frame pointer
        /// </summary>
        public CV_off32_t offFramePointer;
    }
}
