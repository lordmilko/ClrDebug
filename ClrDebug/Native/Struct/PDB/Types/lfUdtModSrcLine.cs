using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, type = {type.ToString(),nq}, src = {src.ToString(),nq}, line = {line}, imod = {imod}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct lfUdtModSrcLine
    {
        /// <summary>
        /// LF_UDT_MOD_SRC_LINE
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// UDT's type index
        /// </summary>
        public CV_typ_t type;

        /// <summary>
        /// index into string table where source file name is saved
        /// </summary>
        public CV_ItemId src;

        /// <summary>
        /// line number
        /// </summary>
        public int line;

        /// <summary>
        /// module that contributes this UDT definition
        /// </summary>
        public short imod;
    }
}
