using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, type = {type.ToString(),nq}, src = {src.ToString(),nq}, line = {line}")]
    public struct lfUdtSrcLine
    {
        /// <summary>
        /// LF_UDT_SRC_LINE
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// UDT's type index
        /// </summary>
        public CV_typ_t type;

        /// <summary>
        /// index to LF_STRING_ID record where source file name is saved
        /// </summary>
        public CV_ItemId src;

        /// <summary>
        /// line number
        /// </summary>
        public int line;
    }
}
