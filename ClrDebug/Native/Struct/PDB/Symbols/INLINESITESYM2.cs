using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, pParent = {pParent}, pEnd = {pEnd}, inlinee = {inlinee.ToString(),nq}, invocations = {invocations}, binaryAnnotations = {binaryAnnotations}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct INLINESITESYM2
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_INLINESITE2
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// pointer to the inliner
        /// </summary>
        public int pParent;

        /// <summary>
        /// pointer to this block's end
        /// </summary>
        public int pEnd;

        /// <summary>
        /// CV_ItemId of inlinee
        /// </summary>
        public CV_ItemId inlinee;

        /// <summary>
        /// entry count
        /// </summary>
        public int invocations;

        /// <summary>
        /// an array of compressed binary annotations.
        /// </summary>
        public fixed byte binaryAnnotations[1];
    }
}
